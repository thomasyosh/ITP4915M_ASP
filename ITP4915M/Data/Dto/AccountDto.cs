using ITP4915M.Data.Entity;
namespace ITP4915M.Data.Dto;

public class AccountDto
{

    public string Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string EmailAddress { get; set; }
    public string Status { get; set; }
    public string _StaffId {get; set; }
}

public class AccountOutDto
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string StaffName {get; set; }
    public string EmailAddress { get; set; }
    public string Status { get; set; }
    public string _StaffId {get; set; }
    public string? Remarks { get; set; }
}