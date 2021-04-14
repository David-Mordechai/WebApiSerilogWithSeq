using System;
using System.Collections.Generic;
using System.Web.Http;
using Tools.Logger;

namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ILoggerAdapter<ValuesController> _logger;

        public ValuesController(ILoggerAdapter<ValuesController> logger)
        {
            _logger = logger;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            var result = new string[] { "value1", "value2" };
            _logger.LogInformation("ValuesController.Get was called, and returned result {result}.", result);
            return result;
        }

        // GET api/values/5
        public string Get(int id)
        {
            if(id < 0)
            {
                var ex = new ArgumentException("Id must be grater then 0");
                _logger.LogError(ex, "ValueController.Get by id failed, id: {id}", id);
                throw ex;
            }
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
