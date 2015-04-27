using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Search
{


    /// <summary>
    /// 对IQueryable的扩展方法
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// zoujian add , 使IQueryable支持QueryModel
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="table">IQueryable的查询对象</param>
        /// <param name="model">QueryModel对象</param>
        /// <param name="prefix">使用前缀区分查询条件</param>
        /// <returns></returns>
        public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> table, QueryModel model, string prefix = "") where TEntity : class
        {
            Contract.Requires(table != null);
            return Where<TEntity>(table, model.Items, prefix);
        }

        private static IQueryable<TEntity> Where<TEntity>(IQueryable<TEntity> table, IEnumerable<ConditionItem> items, string prefix = "")
        {
            Contract.Requires(table != null);
            IEnumerable<ConditionItem> filterItems =
                string.IsNullOrWhiteSpace(prefix)
                    ? items.Where(c => string.IsNullOrEmpty(c.Prefix) && (c.Method < QueryMethod.OrderBy || c.Method > QueryMethod.ThenByDescending))
                    : items.Where(c => c.Prefix == prefix && (c.Method < QueryMethod.OrderBy || c.Method > QueryMethod.ThenByDescending));
            if (filterItems.Count() == 0)
                return table;
            return new QueryableSearcher<TEntity>(table, filterItems).Search();
        }

        #region 排序
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> table, QueryModel model, string prefix = "") where TEntity : class
        {
            Contract.Requires(table != null);

            IEnumerable<ConditionItem> filterItems =
                string.IsNullOrWhiteSpace(prefix)
                    ? model.Items.Where(c => string.IsNullOrEmpty(c.Prefix) && c.Method == QueryMethod.OrderBy)
                    : model.Items.Where(c => c.Prefix == prefix && c.Method >= QueryMethod.OrderBy);
            if (filterItems.Count() == 0)
                return table;

            return new QueryableOrderBy<TEntity>(table, filterItems).OrderBy();
        }

        public static IQueryable<TEntity> OrderByDescending<TEntity>(this IQueryable<TEntity> table, QueryModel model, string prefix = "") where TEntity : class
        {
            Contract.Requires(table != null);

            IEnumerable<ConditionItem> filterItems =
                string.IsNullOrWhiteSpace(prefix)
                    ? model.Items.Where(c => string.IsNullOrEmpty(c.Prefix) && c.Method == QueryMethod.OrderByDescending)
                    : model.Items.Where(c => c.Prefix == prefix && c.Method >= QueryMethod.OrderByDescending);
            if (filterItems.Count() == 0)
                return table;

            return new QueryableOrderBy<TEntity>(table, filterItems).OrderByDescending();
        }

        public static IQueryable<TEntity> ThenBy<TEntity>(this IQueryable<TEntity> table, QueryModel model, string prefix = "") where TEntity : class
        {
            Contract.Requires(table != null);

            IEnumerable<ConditionItem> filterItems =
                string.IsNullOrWhiteSpace(prefix)
                    ? model.Items.Where(c => string.IsNullOrEmpty(c.Prefix) && c.Method == QueryMethod.ThenBy)
                    : model.Items.Where(c => c.Prefix == prefix && c.Method >= QueryMethod.ThenBy);
            if (filterItems.Count() == 0)
                return table;

            return new QueryableOrderBy<TEntity>(table, filterItems).ThenBy();
        }

        public static IQueryable<TEntity> ThenByDescending<TEntity>(this IQueryable<TEntity> table, QueryModel model, string prefix = "") where TEntity : class
        {
            Contract.Requires(table != null);

            IEnumerable<ConditionItem> filterItems =
                string.IsNullOrWhiteSpace(prefix)
                    ? model.Items.Where(c => string.IsNullOrEmpty(c.Prefix) && c.Method == QueryMethod.ThenByDescending)
                    : model.Items.Where(c => c.Prefix == prefix && c.Method >= QueryMethod.ThenByDescending);
            if (filterItems.Count() == 0)
                return table;

            return new QueryableOrderBy<TEntity>(table, filterItems).ThenByDescending();
        }
        #endregion
    }
}
