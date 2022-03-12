using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetflixWebApi.Api;
using NetflixWebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NetflixWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    public class bing : ControllerBase
    {

        //// GET: api/<ContentBingDataController>
        [AllowAnonymous]        
        [HttpGet("{userid}/{contentType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ContentDataModel>>> Get(string userid, int contentType)
        {
            BingApi bingApi = new BingApi();
            var response = await bingApi.GetContent(userid, contentType);
            return Ok(response);
        }

        //// GET: api/<ContentBingDataController>
        [HttpGet]
        //[HttpGet("getapprove/{Email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ContentDataModel>>> Get()
        {
            BingApi bingApi = new BingApi();
            var response = await bingApi.GetContent();
            return Ok(response);
        }

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
