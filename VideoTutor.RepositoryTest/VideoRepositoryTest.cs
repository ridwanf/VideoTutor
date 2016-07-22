using System;
using System.Linq;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoTutor.Data.Domain;
using VideoTutor.Data.Repositories;
using VideoTutor.Repository;

namespace VideoTutor.RepositoryTest
{
    [TestClass]
    public class VideoRepositoryTest
    {
        IVideoRepository repo = new VideoRepository();

        IUnitOfWorkFactory unitOfWorkFactory = new EFUnitOfWorkFactory();

        [TestMethod]
        public void RepoCanSaveData()
        {
        

            var video = new Video
            {
                Author = "RIDWAN",
                CreatedDate = DateTime.Now,
                Id = 0,
                IsActive = true,
                IsHaveSub = false,
                Level = Level.Advanced.ToString(),
                Rating = 7,
                ReleaseDate = DateTime.Now.AddDays(-9),
                Source = "Udemy",
               // Technology = new string[] { "java" },
                Title = "Learn Java",

            };

            var data = new Video() ;
            using (unitOfWorkFactory.Create())
            {
               data = repo.Add(video);
            }
           
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void RepoCanGetByAuthor()
        {
            var data = repo.FindBy(a => a.Author == "RIDWAN").FirstOrDefault();
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void RepoCanUpdate()
        {
            var data = repo.FindBy(a => a.Author == "RIDWAN").FirstOrDefault();
            data.Author = "RidwanEdit";

            var dataUpdate = new Video();
            using (unitOfWorkFactory.Create())
            {
                repo.Update(data);
            }

            Assert.IsNotNull(dataUpdate);
        }

        [TestMethod]
        public void RepoCanDelete()
        {
            var data = repo.FindBy(a => a.Author == "RidwanEdit").FirstOrDefault();

            using (unitOfWorkFactory.Create())
            {
                repo.SoftDelete(data);
            }

            Assert.AreEqual(data.IsActive,false);
        }

    
    }
}
