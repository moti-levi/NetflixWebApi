using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetflixWebApi.Api;
using NetflixWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetflixWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentBingDataController : ControllerBase
    {
        //// GET: api/<ContentBingDataController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ContentDataModel>>> Get()//string UserId,int ContentType
        {
            BingApi bingApi = new BingApi();
            var response = await bingApi.GetContent();
            return Ok(response);
        }

        //// GET api/<ContentBingDataController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ContentBingDataController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ContentBingDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContentBingDataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
