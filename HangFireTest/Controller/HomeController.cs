using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HangFireTest.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet()]
        [Route("[action]")]
        public IActionResult Signup()
        {

            // fire & forget job
            BackgroundJob.Enqueue(() => Console.WriteLine("Signup"));
            return Ok();
        }


        [HttpGet()]
        [Route("[action]")]
        public IActionResult Discount()
        {
            // Delayed job
            BackgroundJob.Schedule(() => Console.WriteLine("DiscountFromSeconds"), TimeSpan.FromSeconds(30));
            return Ok();
        }



        [HttpGet()]
        [Route("[action]")]
        public IActionResult EverDay()
        {
            //RecurringJob
            RecurringJob.AddOrUpdate(() => Console.WriteLine("EverDay"),Cron.Daily());
            return Ok();
        }
    }
}
