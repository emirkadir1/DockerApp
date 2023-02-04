using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DockerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Hangfire : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from hangfire");
        }
        [HttpPost]
        [Route("[action]")]
        //Fire & Forget job
        public IActionResult Welcome()
        {
            var jobId= BackgroundJob.Enqueue(() => WelcomeEmail("Welcome to our app"));
            return Ok($"Job ID:{jobId}Welcome email sent to user");
        }
        private void WelcomeEmail(string text)
        {
            Console.WriteLine(text);
        }
        //-----------------------------------------------
        //Delayed jobs
        [HttpPost]
        [Route("[action]")]
        public IActionResult Discount()
        {
            var jobId = BackgroundJob.Schedule(() => WelcomeEmail("Welcome to our app"),TimeSpan.FromSeconds(30));
            return Ok($"Job ID:{jobId} Discount email will be sent in 30 seconds!");
        }
        //-----------------------------------------------
        //Recurring jobs
        [HttpPost]
        [Route("[action]")]
        public IActionResult DatebaseUpdate()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Database updated"), Cron.Minutely);
            return Ok($"Database check job initiated");
        }

    }
}
