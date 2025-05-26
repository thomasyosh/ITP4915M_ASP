using Microsoft.AspNetCore.Mvc;
using ITP4915M.Data.Repositories;
using ITP4915M.Data;
using ITP4915M.Helpers.Extension;

namespace ITP4915M.API.Controller
{
    [Route("api/pos/session")]
    public class POSSession : ControllerBase
    {

        private readonly Repository<Data.Entity.Session> repository;
        public POSSession(DataContext db)
        {
            repository = new Repository<Data.Entity.Session>(db);
        }

        [HttpGet]
        public IActionResult Get(int month , int day,  string departmentId)
        {
            // from a day format from month and day to match mysql date format
            string date = 2022 + "-" + month.ToString("D2") + "-" + day.ToString("D2");
            var entries = repository.GetBySQL(
                //SELECT * FROM session WHERE Date(`Date`) = "2022-06-04";
                "SELECT * FROM Session WHERE Date(`Date`) = \"" + date + "\" AND _departmentId = '" + departmentId + "'"
            );
            return Ok(entries.MapToDto());
        }
        
    }
}