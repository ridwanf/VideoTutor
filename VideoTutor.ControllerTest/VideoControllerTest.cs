using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoTutor.Data.Repositories;
using VideoTutor.Repository;
using VideoTutor.WebAPI.Controllers;

namespace VideoTutor.ControllerTest
{
    [TestClass]
    public class VideoControllerTest
    {
        IVideoRepository repo = new VideoRepository();

        IUnitOfWorkFactory unitOfWorkFactory = new EFUnitOfWorkFactory();

        [TestMethod]
        public void ControllerCanGetData()
        {
            var controler = new VideosController(unitOfWorkFactory, repo);
            var data = controler.Get(1,10);
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void ControllerCanGetDataById()
        {
            var controler = new VideosController(unitOfWorkFactory, repo);
            var data = controler.Get(1);
            Assert.IsNotNull(data);
        }
    }
}
