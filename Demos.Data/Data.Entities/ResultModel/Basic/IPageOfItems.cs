using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{

    /// <summary>
    /// 分页返回类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPageOfItems<T> : IEnumerable<T>, IEnumerable
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalItemCount { get; }
        int TotalPageCount { get; }
    }

    public class PageOfItems<T> : List<T>, IPageOfItems<T>, IEnumerable<T>, IEnumerable
    {
        public PageOfItems(IEnumerable<T> items, int pageIndex, int pageSize, int totalItemCount)
        {
            base.AddRange(items);
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalItemCount = totalItemCount;
            this.TotalPageCount = (int)Math.Ceiling((double)totalItemCount / (double)pageSize);
        }
        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalItemCount { get; }
        public int TotalPageCount { get; }
    }

}
