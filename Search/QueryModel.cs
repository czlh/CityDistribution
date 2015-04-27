/* ==============================================================================
* 创 建 者：Administrator
* 创建日期：2014/3/25 19:35:52
* ==============================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.ModelBinding;

namespace Search
{
    [ModelBinder(typeof(SearchModelBinder))]
    public class QueryModel
    {
        public QueryModel()
        {
        }

        public QueryModel(int? page,int? pagesize,List<ConditionItem> items)
        {
            _Page = page;
            _Pagesize = pagesize;
            Items = items;
        }

        int? _Page;
        public int Page
        {
            get
            {
                return _Page ?? 1;
            }
            set
            {
                _Page = value;
            }
        }

        int? _Pagesize;
        public int Pagesize
        {
            get
            {
                return _Pagesize ?? 10;
            }
            set
            {
                _Pagesize = value;
            }
        }

        public int SkipCount(int recordCount)
        {
            int totalPage = recordCount / Pagesize;

            if (recordCount % Pagesize > 0)
            {
                totalPage++;
            }

            if (Page > totalPage)
            {
                Page = totalPage;
            }

            if (Page < 1)
            {
                Page = 1;
            }

            return (Page - 1) * Pagesize;
        }

        public Dictionary<string, object> Conditions
        {
            get;
            set;
        }

        List<ConditionItem> _Items;
        public List<ConditionItem> Items
        {
            get
            {
                if (_Items==null)
                {
                    _Items = new List<ConditionItem>();
                }
                return _Items;
            }
            set
            {
                _Items = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="field"></param>
		/// <returns></returns>
		public ConditionItem Pop(string field)
		{
			ConditionItem result = Items.SingleOrDefault(ci => ci.Field == field);
			if (result != null)
			{
				Items.Remove(result);
			}

			return result;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filed"></param>
        /// <returns></returns>
        public bool Contains(string field)
        {
            ConditionItem result = Items.SingleOrDefault(ci => ci.Field == field);
            if (result != null)
            {
                return true;
            }

            return false;
        }
    }
}
