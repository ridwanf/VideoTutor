// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Security.Principal;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Core;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Microsoft.Owin.Security.DataProtection;
using VideoTutor.Data.Repositories;
using VideoTutor.Repository;
using VideoTutor.WebAPI.Models;

namespace VideoTutor.WebAPI.DependencyResolution
{
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;

    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                 //   scan.AssembliesFromApplicationBaseDirectory();
                    scan.TheCallingAssembly();
                   // scan.AssembliesFromApplicationBaseDirectory(assembly => !assembly.FullName.StartsWith("System.Web"));
                    scan.WithDefaultConventions();
                });
            For<IUnitOfWorkFactory>().Use<EFUnitOfWorkFactory>();
            For<IVideoRepository>().Use<VideoRepository>();
            //For<BundleCollection>().Use(BundleTable.Bundles);
            //For<RouteCollection>().Use(RouteTable.Routes);
            For<ISecureDataFormat<AuthenticationTicket>>().Use<SecureDataFormat<AuthenticationTicket>>();
            For<IDataSerializer<AuthenticationTicket>>().Use<TicketSerializer>();
            For<IDataProtector>().Use(() => new DpapiDataProtectionProvider().Create("ASP.NET Identity"));
            For<ITextEncoder>().Use<Base64UrlTextEncoder>();

            For<Microsoft.AspNet.Identity.IUserStore<ApplicationUser>>().Use<Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>>();
            For<System.Data.Entity.DbContext>().Use(() => new ApplicationDbContext());
            //For<HttpSessionStateBase>()
            //    .Use(() => new HttpSessionStateWrapper(HttpContext.Current.Session));
            //For<HttpContextBase>()
            //    .Use(() => new HttpContextWrapper(HttpContext.Current));
            //For<HttpServerUtilityBase>()
            //     .Use(() => new HttpServerUtilityWrapper(HttpContext.Current.Server));
        }

        #endregion
    }
}