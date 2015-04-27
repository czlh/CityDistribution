using DAL;
using DAL.SYS;
using IDAL.SYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassFactory
{
    public class DALFactory
    {
        public static IUserInfoDAL GetUserInfoDAL()
        {

            return new UserInfoDAL();
        }

        public static IMenuDAL GetMenuDAL()
        {
            return new MenuDAL();
        }

        public static IRoleDAL GetRoleDAL()
        {
            return new RoleDAL();
        }

        public static IRolePermissionDAL GetRolePermissionDAL()
        {
            return new RolePermissionDAL();
        }

        public static IToolBarDAL GetToolBarDAL()
        {
            return new ToolBarDAL();
        }
    }
}
