using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL.SYS;
using Model.SYS;

namespace DAL.SYS
{
    public class MenuDAL : AbsBaseDAL<MenuEntity>, IMenuDAL
    {
        public IQueryable<MenuEntity> FindByMenuIdsIn(List<string> menuIds)
        {
            return CdDbContext.Menus.Where(m => menuIds.Contains(m.Id));
        }
    }
}
