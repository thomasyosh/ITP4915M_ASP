namespace ITP4915M.API.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using ITP4915M.API.Controllers;
    using ITP4915M.AppLogic.Controllers;

    [Route("api/[controller]")]
    // [Authorize]
    public class Payment : ControllerBase
    {
        private readonly PaymentController controller;

        public Payment(Data.DataContext db)
        {
            controller = new PaymentController(db);
        }

        [HttpPost("cash/create")]
        public async Task<IActionResult> CreatePayment( [FromBody] Data.Dto.TransactionDto req)
        {
            Data.Dto.TransactionResDto res = await controller.CreatePayment(req);
            return Ok(res);
        }

        [HttpPost("creditcard/create")]
        public async Task<IActionResult> CreateCreditCard( [FromBody] Data.Dto.CreditCardTransactionDto req)
        {
            Data.Dto.TransactionResDto res = await controller.CreateCreditCardPayment(req);
            return Ok(res);
        }

        [HttpPost("qrcode")]
        public async Task<IActionResult> GetPaymentQRCode()
        {
            return File(await controller.GetPaymentQRCode() , "image/png");
        }
    }
}