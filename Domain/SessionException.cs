using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SessionException:Exception
    {
        public SessionException():
            base("登录超时或尚未登录")
        {

        }
    }
}
