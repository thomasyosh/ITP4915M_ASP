/*
 *  Creator         : Ken
 *  Create At       : 01/06/2022
 *  Last Updated    : 06/06/2022
 *
 *  Description     : The DTO for the GET/POST order 
 * 
 *  Change Logs     : X Add Delivery & Installation appointment and Customer Info
 */
using ITP4915M.Data.Entity;

namespace ITP4915M.Data.Dto
{
    public class OrderOutDto 
    {
        public List<SalesOrderItemOutDto> orderItems { get; set; }
        public string _creatorId { get; set; }
        public string _operatorId { get; set; }
        public Store store { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }
        public string status { get; set; }
        public decimal total { get; set; }
        public decimal paid { get; set; }
        public string Id { get ; set; }


        public AppointmentOutDto? Delivery { get; set; }
        public AppointmentOutDto? Installation { get; set; }
        public Customer? Customer { get; set; }
        public string? BookingRecord { get; set; }
    }

    public class AppointmentOutDto 
    {
        public string AppointmentId { get; set; }
        public DateTime Date { get; set;}
        public DateTime StartTime { get; set;}
        public DateTime EndTime { get; set;}
        public List<SalesOrderItem_AppointmentOutDto>? Items { get; set; }
    }

    public class SalesOrderItem_AppointmentOutDto
    {
        public string ItemNames { get; set; }
        public string ItemsId { get; set; }
    }




    public class OrderInDto
    {
        public List<SalesOrderItemInDto> SalesOrderItems { get; set;}
        public List<AppointmentDto>? Appointments { get; set; }
        public int? BookingDeposit { get; set; }
        public CustomerDto? Customer { get; set; }
    }



    public class SalesOrderItemInDto
    {
        public string SupplierGoodsStockId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool NeedDelivery { get; set; }
        public bool NeedInstall { get; set; }
        public bool NeedBooking { get; set; }
    }
    public class SalesOrderItemOutDto : SalesOrderItemInDto
    {
        public string Name { get; set; }
        public int NormalQuantity { get; set; } // the quantity of the item which is not a defect
        public List<DefectItemRecordOutDto>? DefectItemRecords { get; set; }
    }

    public class DefectItemRecordOutDto
    {
        public string Id { get; set; }
        public string HandleStatus { get; set; }
        public int qty { get; set; }
        public string OrderStatus { get; set; }

    }

    public class AppointmentDto
    {
        public string SessionId { get; set; }
        public string DepartmentId { get; set; }
    }

    public class CustomerDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}