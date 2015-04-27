using Model.SYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL.SYS
{
    public interface IMenuDAL : IDAL<MenuEntity>
    {
        IQueryable<MenuEntity> FindByMenuIdsIn(List<string> menuIds);
    }
}
