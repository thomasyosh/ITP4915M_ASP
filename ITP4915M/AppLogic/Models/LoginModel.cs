using ITP4915M.Data.Dto;

namespace ITP4915M.AppLogic.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginOkModel 
    {
        public class Token 
        {
            public string TokenString { get; set; }
            public DateTime ExpireAt {get; set;}
        }
        public string Status { get; set; } 
        public Token UserToken { get; set; }
        public AppInitData InitData { get; set; }
    }

    public class AppInitData 
    {
        public string DisplayName { get; set; }
        public string Position { get; set; }
        public string _StaffId { get; set; }
        public string Department { get; set; }
        //  public List<Permission> permissions {get; set;}
    }

    public class ForgetPwModel
    {
        public string UserName { get ; set ; }
        public string EmailAddress { get ; set ; }

    }

    public class Permission 
    {
        public string menu_name { get; set; }
        public bool? read { get; set; }
        public bool? write { get; set; }
        public bool? delete { get; set; }
    }
}