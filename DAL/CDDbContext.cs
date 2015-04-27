using Model.SYS;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace DAL
{
    public class CDDbContext:DbContext
    {
        public CDDbContext()
            : base("CDConnection")
        {
        }
        public DbSet<UserInfoEntity> UserInfos
        {
            get;
            set;
        }

        public DbSet<RoleEntity> Roles
        {
            get;
            set;
        }

        public DbSet<RolePermissionEntity> RolePermissions
        {
            get;
            set;
        }

        public DbSet<MenuEntity> Menus
        {
            get;
            set;
        }

        public DbSet<ToolBarEntity> ToolBars
        {
            get;
            set;
        }
    }
}
