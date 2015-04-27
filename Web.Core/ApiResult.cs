using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Core
{
    public class ApiResult
    {
        public ApiResult(object data)
        {
            Code = 200;
            Data = data;
        }

        public ApiResult(int code, Exception e)
        {
            Code = code;
            Desc = e.Message;
            ExceptionType = e.GetType().Name;
        }

        public int Code
        {
            get;
            set;
        }

        public object Data
        {
            get;
            set;
        }

        public string ExceptionType
        {
            get;
            set;
        }

        public string Desc
        {
            get;
            set;
        }
    }
}
