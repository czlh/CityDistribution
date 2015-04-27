using ClassFactory;
using IDAL;
using IDAL.SYS;
using Model.SYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BaseInfo
{
    public class UserInfoBLL : AbsBusinessBaseBLL<UserInfoEntity, IUserInfoDAL>
    {
        protected override IUserInfoDAL GetDal()
        {
            return DALFactory.GetUserInfoDAL();
        }
    }
}
