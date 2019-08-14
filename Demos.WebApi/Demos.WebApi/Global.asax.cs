using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Basic.Service;
using Common.Logging;
using Data.Repository.Repository;
using System;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Demos.WebApi
{

    /// <summary>
    /// 
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 
        /// </summary>
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            SetupResolveRules(builder);
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();//ApiController　WebApi注入 
            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);//ApiController　WebApi注入 
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(Object sender, EventArgs e)
        {
            try
            {
                string url = string.Empty;
                string message = string.Empty;
                url = HttpContext.Current.Request.RawUrl;//错误发生地址
                Exception ex = Server.GetLastError().GetBaseException();
                message = ex.Message;//错误信息
                Log.Error($"异常地址:{url} 错误信息:{message}");
            }
            catch
            {
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        private void SetupResolveRules(ContainerBuilder builder)
        {
            #region 数据仓库
            builder.RegisterType<PubCodesRepository>().As<IPubCodesRepository>().InstancePerLifetimeScope();

            #endregion


            #region 服务
            //builder.RegisterType<BasicDataService>().As<IBasicDataService>().InstancePerLifetimeScope();

            #endregion

        }

    }
}
