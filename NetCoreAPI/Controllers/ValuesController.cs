using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace coreapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public ValuesController(ILogger<ValuesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            var Message = $"About page visited at {DateTime.UtcNow.ToLongTimeString()}";
            _logger.LogInformation("_configuration.", Message);
            var output =  
                @"ExtraSettingNotInSettingsFile:"
                +_configuration.GetValue<string>("ExtraSettingNotInSettingsFile")
                +"CUSTOMCONNSTR_MONGO:"
                +_configuration.GetConnectionString("CUSTOMCONNSTR_MONGO")
                + "webAPI2: {class: classname, _objectId:webapi2 with file writing and checking new container refresh, msg: we then have output from api2}";

            System.IO.Directory.CreateDirectory("./vol/");
            System.IO.File.AppendAllText(@"./vol/WriteText.txt", output);
            System.IO.File.AppendAllText(@"./vol/WriteText.txt", Environment.NewLine);
            return output;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }      

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
