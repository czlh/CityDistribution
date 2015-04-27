/* ==============================================================================
* 创 建 者：Administrator
* 创建日期：2014/3/28 10:45:49
* ==============================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Search
{
    public class QueryResult
    {
        public QueryResult(object data, int recordCount, QueryModel query)
            : this(data, recordCount, query.Page, query.Pagesize)
        {

        }

        public QueryResult(object data, int recordCount, int page, int pagesize)
        {
            RecordCount = recordCount;
            Data = data;
            CurrentPage = page;
            ShowPages = CalcPages(recordCount, page, pagesize);
        }

        private List<int> CalcPages(int recordCount, int currentPageIndex, int pagesize)
        {
            List<int> result = new List<int>();

            int totalPage = recordCount / pagesize;

            if (recordCount % pagesize>0)
            {
                totalPage++;
            }

            int pages = 5;

            //每到6页时，重新加载5页
            //开始页
            int start = currentPageIndex - 5;

            if (start < 1)
            {
                start = 1;
            }

            for (int i = 0; i < totalPage; i++)
            {
                if ((i * pages + 1) > currentPageIndex)
                {
                    start = (i - 1) * pages + 1;

                    break;
                }
            }

            //结束页
            int end = start + pages;

            //结束页不能大与总页数
            if (end > totalPage)
            {
                end = totalPage;
            }

            for (int i = start; i <= end; i++)
            {
                result.Add(i);
            }

            return result;
        }

        public int RecordCount
        {
            get;
            set;
        }

        public object Data
        {
            get;
            set;
        }

        public int CurrentPage
        {
            get;
            set;
        }

        public List<int> ShowPages
        {
            get;
            set;
        }
    }
}
