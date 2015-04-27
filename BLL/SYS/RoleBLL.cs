using ClassFactory;
using IDAL.SYS;
using Model.SYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.SYS
{
    public class RoleBLL : AbsBusinessBaseBLL<RoleEntity, IRoleDAL>
    {
        protected override IRoleDAL GetDal()
        {
            return DALFactory.GetRoleDAL();
        }
    }
}
