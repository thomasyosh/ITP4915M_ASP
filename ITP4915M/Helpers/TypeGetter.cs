namespace ITP4915M.Helpers
{
    using System.Reflection;
    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    public static class TypeGetter
    {
        public static Type GetType( string Name )
        {
            var currentlyLoadedModuleNames = AppDomain.CurrentDomain.GetAssemblies().SelectMany<Assembly,string>( a => a.GetModules().Select<Module,string>( m => m.FullyQualifiedName )).ToArray();
            var csc = new CSharpCodeProvider();
            CompilerResults results = csc.CompileAssemblyFromSource(
                new CompilerParameters( currentlyLoadedModuleNames, "temp.dll", false) {
                    GenerateExecutable = false, GenerateInMemory = true, TreatWarningsAsErrors = false, CompilerOptions = "/optimize"
                },
                @"public static class TypeInfo {
                    public static System.Type GetEmbeddedType() {
                        return typeof(" + Name + @");
                    }
                }");
            if (results.Errors.Count > 0)
                throw new Exception( "Error compiling type name." );
            Type[] type = results.CompiledAssembly.GetExportedTypes();
            return (Type)type[0].GetMethod("GetEmbeddedType").Invoke( null, System.Reflection.BindingFlags.Static, null, null, null );
        }
    }
}