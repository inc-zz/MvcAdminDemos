"# MvcAdminDemos" 

项目文档=>

  代码结构图

  A_Common

    Common.Cache              --基础缓存类 
    Common.Logging            --日志 
    Common.MongoRepository    --Mongo封装类
    Common.RabbitMQ           --消息队列基础类

  B_Core 

    Core.EnumType             --枚举，常量
    Core.Utility              --底层核心、基础工具

  C_Data

    Data.Entities             --实体类
    Data.Repository           --T4生成的底层数据仓库
  D_Service 

    Basic.Service             --T4生成的中间服务层、
  E_Admin 

    Demos.Admin               --Web站点
    Demos.WebApi              --WebApi
  F_Test

    Admin.Test                --单元测试
  G_Document                  --项目相关文档

