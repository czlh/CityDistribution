using DAL;
using Model.SYS;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taocz.CVS.Common.Context
{
    public sealed class CDDbMigrationsConfiguration : DbMigrationsConfiguration<CDDbContext>
    {
        public CDDbMigrationsConfiguration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CDDbContext context)
        {
            AddMenu(context);
            AddToolBar(context);
            AddAdministrator(context);

            context.SaveChanges();
            base.Seed(context);
        }

        void AddMenu(CDDbContext context)
        {

        }

        void AddToolBar(CDDbContext context)
        {

        }

        void AddAdministrator(CDDbContext context)
        {

            UserInfoEntity admin = new UserInfoEntity()
            {
                CreatedTime = DateTime.Now,
                Enabled = true,
                Id = "A65A5C10-0807-4802-BB48-DCAB603CA5D3",
                UserName = "admin",
                IsAdmin = true,
                PassWord = ""
            };
            if (context.UserInfos.Count(user => user.Id == admin.Id) == 0)
            {
                context.UserInfos.Add(admin);
            }

        }
    }
}
