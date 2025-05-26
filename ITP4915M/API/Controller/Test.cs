﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ITP4915M.Helpers.File;
using ITP4915M.Helpers;
using ITP4915M.Helpers.Secure;
using ITP4915M.Data;
using ITP4915M.API.Filters;
using MailKit.Net.Smtp;
using MimeKit;
using System.Data;
using ITP4915M.AppLogic;
using ITP4915M.AppLogic.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using QRCoder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITP4915M.API.Controllers
{
    [Route("api/[controller]")]

    public class Test : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ITP4915M.AppLogic.Controllers.TestController _testController;
        private readonly ITP4915M.Data.Repositories.AccountRepository _accountRepository;
        private readonly ITP4915M.Data.DataContext db;

        public Test(IConfiguration config, DataContext data )
        {
            _config = config;
            db = data;
            _testController = new AppLogic.Controllers.TestController(data);
            _accountRepository = new Data.Repositories.AccountRepository(data);
        }

        [HttpGet("testref")]
        public void Getdafsdf()
        {
            ITP4915M.Data.Entity.Account account = new ITP4915M.Data.Entity.Account();
        }


        [HttpGet("testlogaccess")]
        public IActionResult TestLogAccess()
        {
            return Ok("LogAccess");
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(id);
        }

        [HttpPost("asd")]
        public IActionResult Post()
        {
            string str = @"{'Ken' : 'A'}";
            return Ok(JObject.Parse(str));
        }

        [HttpGet("tmp")]
        public IActionResult GetAsync()
        {
            String str = "";
            TempFile tmp = TempFileManager.Create();
            tmp.WriteAllText("SDFSDF");
            tmp.WriteAllText("sdfdf");
            str = tmp.ReadAllText();

            return Ok(str);
        }

        [HttpGet("login")]
        public IActionResult GetKey()
        {
            Data.Entity.Account user = new Data.Entity.Account
            {
                Password = "ASD",
                UserName = "ASD"
            };
            var key = Helpers.Secure.JwtToken.Issue(user);
            return Ok(key);
        }

        [HttpGet("Auth"), Authorize(Roles = "Admin")]
        public IActionResult GetAuth()
        {
            return Ok();
        }

#if DEBUG
        [HttpGet("check/{plainText}")]
        public IActionResult Getasd(string plainText)
        {
            return Ok(Hasher.Hash(plainText));
        }
#endif

        [HttpGet("enum/entity")]
        public IEnumerable<Data.Entity.Account> GetEntity()
        {
            return Enumerable.Range(1, 5).Select(index => new Data.Entity.Account
            {
                UserName = "ASD",
                Password = "ASD"
            }).ToArray();
        }

        [HttpGet("json/entity")]
        public IActionResult GetJsonEntity()
        {
            JArray arr = new JArray();
            arr.Add(JObject.FromObject(new Data.Entity.Account
            {
                UserName = "1",
                Password = "SDF"
            }));
            arr.Add(JObject.FromObject(new Data.Entity.Account
            {
                UserName = "2",
                Password = "akj"
            }));
            arr.Add(JObject.FromObject(new Data.Entity.Account
            {
                UserName = "3",
                Password = "akj"
            }));
            arr.Add(JObject.FromObject(new Data.Entity.Account
            {
                UserName = "4",
                Password = "akj"
            }));
            arr.Add(JObject.FromObject(new Data.Entity.Account
            {
                UserName = "5",
                Password = "akj"
            }));
            arr.Add(JObject.FromObject(new Data.Entity.Account
            {
                UserName = "6",
                Password = "akj"
            }));

            return Ok(arr);
        }


        [HttpGet]
        public ContentResult Index()
        {
            return base.Content("<h1>Hello World</h1>", "text/html");
        }


        // https://stackoverflow.com/questions/39177576/how-to-to-return-an-image-with-web-api-get-method
        [HttpGet("image")]
        public IActionResult GetIamge(string filename)
        {
            byte[] ImgFile = System.IO.File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + $"/img/{filename}");
            return File(ImgFile, "image/jpeg");
        }

        [HttpGet("pdf")]
        public IActionResult GetPDF(string filename)
        {
            try
            {
                byte[] pdfFile = System.IO.File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + $"/img/{filename}");
                return File(pdfFile, "application/pdf");

            }
            catch (FileNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        // [HttpGet("email")]
        // public IActionResult SendEmail()
        // {
        //     //Helpers.EmailSender.SendEmail("Ken", "210339487@stu.vtc.edu.hk", "This is a test", MimeKit.Text.TextFormat.Html, DynamicFile.UpdatePlaceFolder("test.html", "name=Ken;pw=asdf"));
        //     Helpers.EmailSender.SendEmail(
        //         recevier: "Ken",
        //         receiverAddress: "210339487@stu.vtc.edu.hk",
        //         subject: "test",
        //         msg: DynamicFile.UpdatePlaceHolder("test.html", "name=Ken;pw=sdf")
        //     );

        //     // return Ok(Helpers.SecretConfig.Instance.GetEmailDetail().);
        //     return Ok();
        // }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("pong");
        }

        [HttpGet("qrcode")]
        public FileContentResult GetQRCode(string str)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(20);

            return File(qrCodeAsPngByteArr , "image/png");
        }

        [HttpGet("primarykey")]
        public IActionResult GetPrimaryKey()
        {
            return Ok(ITP4915M.Helpers.Sql.PrimaryKeyGenerator.Get<Data.Entity.Catalogue>(db));
        }


        //[HttpGet("Acc")]
        //public IActionResult GetAccs()
        //{
        //    return Ok(_testController.GetSth());
        //}

        //[HttpPost("Acc")]
        //public async Task<IActionResult> CreateAccsAsync(Data.Dto.Acc acc)
        //{
        //    try
        //    {
        //        _testController.CreateSth(acc);
        //        return Ok();

        //    } catch(Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }

        //}


        // https://stackoverflow.com/questions/43678963/send-and-receive-large-file-over-streams-in-asp-net-web-api-c-sharp


    }

}

