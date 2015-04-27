using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL.SYS;
using Model.SYS;

namespace DAL.SYS
{
    public class RolePermissionDAL : AbsBaseDAL<RolePermissionEntity>, IRolePermissionDAL
    {
        public IQueryable<RolePermissionEntity> FindByRoleId(string roleId)
        {
            return CdDbContext.RolePermissions.Where(r => r.RoleId == roleId);
        }
    }
}
