using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoTutor.Data.Domain;
using VideoTutor.ViewModel;

namespace VideoTutor.Mapper
{
    public static class VideoMapper
    {
        public static Video ConvertToData(this VideoViewModel model)
        {
            var data = new Video();
            data.Author = model.Author;
            data.CreatedDate = model.CreatedDate;
            data.Id = model.Id;
            data.IsActive = model.IsActive;
            data.IsHaveSub = model.IsHaveSub;
            data.Level = model.Level;
            data.Rating = model.Rating;
            data.ReleaseDate = model.ReleaseDate;
            data.Size = model.Size;
            data.Source = model.Source;
            data.Technology = model.Technology.ToString();
            data.Title = model.Title;

            return data;
        }

        public static IEnumerable<Video> ConvertToListData(this IEnumerable<VideoViewModel> listModel)
        {
            return listModel.Select(m => m.ConvertToData()).ToList();

        }

        public static VideoViewModel ConvertToModel(this Video data)
        {
            var model = new VideoViewModel();
            model.Author = data.Author;
            model.CreatedDate = data.CreatedDate;
            model.Id = data.Id;
            model.IsActive = data.IsActive;
            model.IsHaveSub = data.IsHaveSub;
            model.Level = data.Level;
            model.Rating = data.Rating;
            model.ReleaseDate = data.ReleaseDate;
            model.Size = data.Size;
            model.Source = data.Source;
            model.Technology = data.Technology.Split(',').ToArray();
            model.Title = data.Title;

            return model;
        }

        public static IEnumerable<VideoViewModel> ConvertToListModel(this IEnumerable<Video> listData)
        {
            return listData.Select(m => m.ConvertToModel()).ToList();

        }
    }
}
