using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;
using System.Configuration;

[assembly: OwinStartup(typeof(Demos.Admin.Startup))]

namespace Demos.Admin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            #region hangFire 
            //指定Hangfire使用内存存储后台任务信息
            var conn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //使用sqlserver持久化 
            GlobalConfiguration.Configuration.UseSqlServerStorage(conn);
            //启用HangfireServer这个中间件（它会自动释放）
            app.UseHangfireServer();
            //启用Hangfire的仪表盘（可以看到任务的状态，进度等信息）
            app.UseHangfireDashboard();

            #endregion

            app.MapSignalR();
        }
    }
}
