using ITP4915M.AppLogic.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ITP4915M.Data.Repositories
{
    public class UserInfoRepository
    {
        private DbSet<Data.Entity.Account> _accounts;
        private DbSet<Data.Entity.Staff> _staffs;
        private DataContext _db;
        public UserInfoRepository(Data.DataContext db)
        {
            _db = db;
            _accounts = db.Set<Data.Entity.Account>();
            _staffs = db.Set<Data.Entity.Staff>();
        }

        public Data.Entity.Staff GetStaffFromUserName(string username)
        {
            username = username.Replace("\"" , "");
            Data.Entity.Account? res = _accounts.FromSqlRaw(
                $"SELECT * FROM Account WHERE `username` = \"{username}\""
            ).FirstOrDefault();
            if (res == null)
                throw new BadArgException("The username is not valid.");
            return res.Staff;
        }

        public bool IsAdmin(string username)
        {
            username = username.Replace("\"" , "");
            Data.Entity.Account? res = _accounts.FromSqlRaw(
                $"SELECT * FROM Account WHERE `username` = \"{username}\""
            ).FirstOrDefault();
            if (res == null)
                throw new BadArgException("The username is not valid.");
            return AppLogic.Constraint.AdminDepartmentId.Contains(res.Staff._departmentId);
        }


        public bool IsWarehouseStaff(string username)
        {
            username = username.Replace("\"" , "");
            Data.Entity.Account? res = _accounts.FromSqlRaw(
                $"SELECT * FROM Account WHERE `username` = \"{username}\""
            ).FirstOrDefault();
            if (res == null)
                throw new BadArgException("The username is not valid.");
            return res.Staff._departmentId == "300";
        }

        public bool IsSales(string username)
        {
            username = username.Replace("\"" , "");
            Data.Entity.Account? res = _accounts.FromSqlRaw(
                $"SELECT * FROM Account WHERE `username` = \"{username}\""
            ).FirstOrDefault();
            if (res == null)
                throw new BadArgException("The username is not valid.");
            return res.Staff._departmentId == "200";
        }

    }
}