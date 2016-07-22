using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.OData;
using VideoTutor.Data.Domain;

namespace VideoTutor.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class LevelsController : ApiController
    {
        // GET: api/Levels
        [EnableQuery()]
        [ResponseType(typeof(Level))]
        public IHttpActionResult Get()
        {
            var levels = Enum.GetValues(typeof (Level))
                .Cast<Level>()
                .Select(v => v.ToString());
            try
            {
                return Ok(levels);
            }
            catch (Exception)
            {
                return InternalServerError();

            }
        }

        //[EnableQuery()]
        //public IHttpActionResult Get(string search)
        //{
        //    return Ok(Level.(p => p.Title
        //        .Contains(search)).AsQueryable());
        //}

        // GET: api/Levels/5
        public IHttpActionResult Get(int id)
        {
            return InternalServerError();
        }

        // POST: api/Levels
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Levels/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Levels/5
        public void Delete(int id)
        {
        }
    }
}
