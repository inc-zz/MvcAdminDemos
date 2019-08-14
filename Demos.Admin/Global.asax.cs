using Autofac;
using Autofac.Integration.Mvc;
using Basic.Service;
using Common.Logging;
using Data.Repository.Repository;
using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;



namespace Demos.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            SetupResolveRules(builder);
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

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
