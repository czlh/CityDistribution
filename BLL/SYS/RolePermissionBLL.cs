using IDAL.SYS;
using Model.SYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassFactory;

namespace BLL.SYS
{
    public class RolePermissionBLL : AbsBusinessBaseBLL<RolePermissionEntity, IRolePermissionDAL>
    {
        protected override IRolePermissionDAL GetDal()
        {
            return DALFactory.GetRolePermissionDAL();
        }
    }
}
