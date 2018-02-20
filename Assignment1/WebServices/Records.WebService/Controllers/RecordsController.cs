using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Records.WebService.Controllers
{
    public class RecordsController : ApiController
    {
        // GET: api/Records
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Records/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Records
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Records/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Records/5
        public void Delete(int id)
        {
        }
    }
}
