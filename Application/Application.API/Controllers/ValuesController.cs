using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Application.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        //GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return id.ToString();
        }

        //POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        //PUT api/values
        [HttpPut]
        public void Put([FromBody]string value)
        {
        }
    }
}
