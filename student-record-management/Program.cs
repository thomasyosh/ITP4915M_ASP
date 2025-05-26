using myWebApp.Data;
using myWebApp.Helpers.LogHelper;
using Microsoft.AspNetCore.Authentication;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddControllers()
            .AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        // builder.Services.AddDbContext<DataContext>(options =>
        // {
        //     var ConnString = _Secret["ConnectionString"];
        //     options.UseMySql(
        //         ConnString,
        //         ServerVersion.AutoDetect(ConnString)
        //     );
        // });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(_Secret["Token"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Auth using the bearer",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });
        builder.Services.AddCors(
            options =>
            {
                options.AddPolicy("default",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            }
        );
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.UseCors("default");
        Console.Title = "The Better Limited Server";

        string ConnStringParts = "";
        // using (var conn = new MySqlConnection(TestConnString.ToString()))
        // {
        //     try // test the connection with sql server
        //     {
        //         conn.Open();
        //     }
        //     catch (MySqlException e)
        //     {
        //         Console.ForegroundColor = ConsoleColor.Red;
        //         Console.WriteLine($"Timeout: {conn.ConnectionTimeout}s\nError occur during create a connection with MySQL server");
        //         Console.WriteLine("\t-Make sure you start the MySQL server");
        //         Console.WriteLine("\t-Make sure your connection string is correct");
        //         Console.WriteLine("\t-Make sure you have the right permissions");
        //         return;
        //     }
        //     finally
        //     {
        //         conn.Close();
        //         Console.ResetColor();
        //     }
        // }

// #if DEBUG
//         using (var serviceScope = app.Services.CreateScope())
//         {
//             var dbContext = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
//             // drop the database if it exists
//             dbContext.Database.ExecuteSqlRaw(
//                 "DROP DATABASE IF EXISTS `TheBetterLimitedDev`;"
//             );
//             // create the database
//             dbContext.Database.Migrate();
//             // insert some dummy data
//             ITP4915M.Data.DummyDataFactory.Create(dbContext).GetAwaiter().GetResult();
//         }
// #endif

        ConsoleLogger.Debug("Version");

        app.Run();

        TempFileManager.CloseAllTempFile();
        ITP4915M.Helpers.File.PDFFactory.Instance.Dispose();
    }
}