using ITP4915M.Data.Entity;
using ITP4915M.Data;
using ITP4915M.AppLogic.Models;

namespace ITP4915M.AppLogic.Controllers
{
    public class SessionSetttingController
    {
        private readonly Data.Repositories.Repository<SessionSetting> repository;
        private readonly Data.Repositories.Repository<Session> _SessionTable;
        private readonly Data.DataContext db;
        public SessionSetttingController(DataContext db)
        {
            repository = new Data.Repositories.Repository<SessionSetting>(db);
            _SessionTable = new Data.Repositories.Repository<Session>(db);
            this.db = db;
        }

        public List<SessionSetting> GetAll(string Language)
        {
            return repository.GetAll();
        }
        public void UpdateSessionSetting( List<SessionSetting> content)
        {
            var oldVersion = repository.GetAll();
            foreach (var item in oldVersion)
            {
                repository.Delete(item);
            }

            foreach (var item in content)
            {
                var newObject = new SessionSetting()
                {
                    ID = Helpers.Sql.PrimaryKeyGenerator.Get<SessionSetting>(db),
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    NumOfAppointments = item.NumOfAppointments
                };
                repository.Add(item);
            }

            var newVersion = repository.GetAll();
  
           // generate sesion for next month, and did not delete the old session
            var nextMonth = DateTime.Now.AddMonths(1);

            for (int i = 0 ; i < newVersion.Count() ; i ++ )
            {
                var DSession = new Session
                {
                    ID = Helpers.Sql.PrimaryKeyGenerator.Get<Session>(db),
                    _departmentId = "300",
                    StartTime = newVersion[i].StartTime,
                    EndTime = newVersion[i].EndTime,
                    Date = nextMonth,
                    NumOfAppointments =  newVersion[i].NumOfAppointments
                };
                _SessionTable.Add(DSession);

                var ESession = new Session
                {
                    ID = Helpers.Sql.PrimaryKeyGenerator.Get<Session>(db),
                    _departmentId = "700",
                    StartTime = newVersion[i].StartTime,
                    EndTime = newVersion[i].EndTime,
                    Date = nextMonth,
                    NumOfAppointments = newVersion[i].NumOfAppointments
                };
                _SessionTable.Add(ESession);
            }

        }


    }
}