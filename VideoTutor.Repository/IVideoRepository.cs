using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using VideoTutor.Data.Domain;
using VideoTutor.Data.Repositories;

namespace VideoTutor.Repository
{
    public interface IVideoRepository : IBaseRepository<Video>
    {
        Video Create();
    }

    public class VideoRepository : BaseRepository<Video>, IVideoRepository
    {
        public override void SoftDelete(Video entity)
        {
            entity.IsActive = false;
            Update(entity);
        }

        public Video Create()
        {
            Video video = new Video()
            {
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            return video;
        }
    }
}
