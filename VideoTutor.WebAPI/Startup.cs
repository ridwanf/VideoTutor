﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(VideoTutor.WebAPI.Startup))]

namespace VideoTutor.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           // ConfigureAuthZero(app);
        }

       
    }

   
}
