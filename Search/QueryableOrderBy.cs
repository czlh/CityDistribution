using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Search
{


    public class QueryableOrderBy<T>
    {
        public QueryableOrderBy()
        {
            Init();
        }
        public QueryableOrderBy(IQueryable<T> table, IEnumerable<ConditionItem> items)
            : this()
        {
            Table = table;
            Items = items;
        }
        private void Init()
        {
            
        }



        public List<ITransformProvider> TransformProviders
        {
            get;
            set;
        }
        protected IEnumerable<ConditionItem> Items
        {
            get;
            set;
        }

        protected IQueryable<T> Table
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> OrderBy()
        {
            if (Items == null || Items.Count() == 0)
            {
                return Table;
            }

            //构建
            List<dynamic> expressions = GetExpressoin(Items);

            foreach (dynamic expression in expressions)
            {
                Table = Queryable.OrderBy(Table, expression);
            }

            //传到OrderBy中当做参数
            return Table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> OrderByDescending()
        {
            if (Items == null || Items.Count() == 0)
            {
                return Table;
            }

            //构建
            List<dynamic> expressions = GetExpressoin(Items);

            foreach (dynamic expression in expressions)
            {
                Table = Queryable.OrderByDescending(Table, expression);
            }

            //传到OrderBy中当做参数
            return Table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> ThenBy()
        {
            if (Items == null || Items.Count() == 0)
            {
                return Table;
            }

            //构建
            List<dynamic> expressions = GetExpressoin(Items);

            foreach (dynamic expression in expressions)
            {
                Table = Queryable.ThenBy(Table, expression);
            }

            //传到OrderBy中当做参数
            return Table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> ThenByDescending()
        {
            if (Items == null || Items.Count() == 0)
            {
                return Table;
            }

            //构建
            List<dynamic> expressions = GetExpressoin(Items);

            foreach (dynamic expression in expressions)
            {
                Table = Queryable.ThenByDescending(Table, expression);
            }

            //传到OrderBy中当做参数
            return Table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private dynamic GetExpressoin(ConditionItem item)
        {
            ParameterExpression para = Expression.Parameter(typeof(T), "O");
            dynamic exp = GetPropertyLambdaExpression(item, para);

            //dynamic keys = Expression.Lambda(exp, para);

            return exp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private List<dynamic> GetExpressoin(IEnumerable<ConditionItem> items)
        {
            List<dynamic> returnValue = new List<dynamic>();

            foreach (ConditionItem item in items)
            {
                returnValue.Add(GetExpressoin(item));
            }

            return returnValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private LambdaExpression GetPropertyLambdaExpression(ConditionItem item, ParameterExpression param)
        {
            //获取每级属性如c.Users.Proiles.UserId
            var props = item.Value.ToString().Split('.');
            Expression propertyAccess = param;
            var typeOfProp = typeof(T);
            int i = 0;
            do
            {
                PropertyInfo property = typeOfProp.GetProperty(props[i]);
                if (property == null)
                    return null;
                typeOfProp = property.PropertyType;
                propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                i++;
            } while (i < props.Length);

            return Expression.Lambda(propertyAccess, param);
        }
    }
}