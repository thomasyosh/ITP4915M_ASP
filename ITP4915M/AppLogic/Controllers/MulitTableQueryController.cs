using ITP4915M.Data;
using ITP4915M.Helpers.Extension;
using ITP4915M.AppLogic.Exceptions;
namespace ITP4915M.AppLogic.Controllers
{
    public class MulitTableQueryController
    {
        private readonly DataContext db;
        public MulitTableQueryController(DataContext db)
        {
            this.db = db;
        }
        // perform a query on two tables
        public async Task<List<Dictionary<object, object>>> Get(List<string> tables , string quertString , string lang = "en")
        {
            
            // example: SELECT * FROM [Table1] , [Table2] , [Table3]
            string sql = Helpers.Sql.QueryStringBuilder.CreateCrossTableSQLQuery(quertString , tables);
            
            // excute the query and store the result in a list of Dictionary<object, object>s or DataTables
            // var list = await db.QueryAsync<Dictionary<object, object>>(sql); // wrong !!!  this method not exist

            List<Dictionary<object, object>> res = new List<Dictionary<object, object>>();
            using (var conn = db.Database.GetDbConnection())
            {
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    try
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            int  tableCounter = 0;
                            while(await reader.ReadAsync())
                            {
                                var entry = new Dictionary<object, object>();
                                for (var i = 0 ; i < reader.FieldCount ; i++)
                                {
                                    ConsoleLogger.Debug(reader.GetName(i) + " : " + reader.GetValue(i));
                                    if (reader.GetName(i).ToLower() == "id")
                                    {
                                        entry.Add(tables[tableCounter++] + " " + reader.GetName(i) , reader.GetValue(i));
                                    }
                                    else
                                    {
                                        entry.Add(reader.GetName(i) , reader.GetValue(i));
                                    }
                                }
                                res.Add(entry);
                            }
                        }
                    }catch(Exception e)
                    {
                        throw new BadArgException(e.Message);
                    }
                    
                }
            }

            return res;


            // now add match the query string
        }
    }

}