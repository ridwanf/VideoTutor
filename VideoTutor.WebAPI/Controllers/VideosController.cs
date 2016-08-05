using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.OData;
using System.Web.UI.WebControls;
using Core;
using StructureMap.Query;
using VideoTutor.Data.Domain;
using VideoTutor.Repository;
using VideoTutor.WebAPI.Models;
using VideoTutor.WebAPI.Utility;

namespace VideoTutor.WebAPI.Controllers
{
    //[Authorize]
    [EnableCors("*", "*", "*")]
    public class VideosController : ApiController
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public VideosController(IUnitOfWorkFactory unitOfWorkFactory, IVideoRepository videoRepository)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _videoRepository = videoRepository;
        }

        // GET: api/Video
        [EnableQuery()]
        //  [ResponseType(typeof(PagerModel<Video>))]
        public IHttpActionResult Get(int pageNumber, int pageSize)
        {
            try
            {
                var total = _videoRepository.FindAll().Count();
                var data = new PagerModel<Video>
                {
                    Data = _videoRepository.FindAll().OrderBy(i=>i.Id).Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize),
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Total = total,
                };
                return Ok(data);
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        // GET: api/Products?search=GDN
        [EnableQuery()]
        public IHttpActionResult Get(string search, int pageNumber, int pageSize)
        {
            var total = _videoRepository.FindBy(p => p.Title
                .Contains(search)).Count();

             var data = new PagerModel<Video>
                {
                    Data = _videoRepository.FindBy(p => p.Title.Contains(search)).OrderBy(i=>i.Id).Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize),
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Total = total,
                };

            return Ok(data);
        }

        // GET: api/Video/5
        public IHttpActionResult Get(int id)
        {
            Video video;
            if (id > 0)
            {
                video = _videoRepository.FindBy(a => a.Id == id).First();
                if (video == null)
                    return NotFound();

                if (!string.IsNullOrEmpty(video.Technology))
                    video.TechArray = video.Technology.Split(',').ToArray();
                else
                    video.TechArray = null;
            }
            else
            {
                video = _videoRepository.Create();
            }

            return Ok(video);
        }

        // POST: api/Video
        public IHttpActionResult Post([FromBody]Video video)
        {
            try
            {
                if (video == null)
                    return BadRequest("Video cannot be null");
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Video newVideo;
                if (video.TechArray != null)
                    video.Technology = string.Join(",", video.TechArray);

                using (_unitOfWorkFactory.Create())
                    newVideo = _videoRepository.Add(video);
                if (newVideo == null)
                    return Conflict();
                return Created<Video>(Request.RequestUri + newVideo.Id.ToString(), new Video());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Video/5
        public IHttpActionResult Put(int id, [FromBody]Video video)
        {
            try
            {
                if (video == null)
                {
                    return BadRequest("Video cannot be null");
                }
                if (video.TechArray != null)
                    video.Technology = string.Join(",", video.TechArray);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }



                using (_unitOfWorkFactory.Create())
                {
                    _videoRepository.Update(video);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Video/5
        public IHttpActionResult Delete(int id)
        {
            return InternalServerError();
        }
    }
}
