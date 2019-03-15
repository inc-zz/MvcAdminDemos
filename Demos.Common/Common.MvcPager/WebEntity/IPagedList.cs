using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webdiyer.WebControls.Mvc
{

    ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/Interfaces/Interface[@name="IPagedList"]/*'/>
    public interface IPagedList : IEnumerable
    {
        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/IPagedList/Property[@name="CurrentPageIndex"]/*'/>
        int CurrentPageIndex { get; set; }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/IPagedList/Property[@name="PageSize"]/*'/>
        int PageSize { get; set; }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/IPagedList/Property[@name="TotalItemCount"]/*'/>
        int TotalItemCount { get; set; }
    }

    ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/Interfaces/Interface[@name="IPagedList2"]/*'/>
    public interface IPagedList<T> : IEnumerable<T>, IPagedList { }
}
