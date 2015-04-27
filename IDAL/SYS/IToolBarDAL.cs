using Model.SYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL.SYS
{
    public interface IToolBarDAL : IDAL<ToolBarEntity>
    {
        IQueryable<ToolBarEntity> FindByIdsIn(List<string> ids);

        IQueryable<ToolBarEntity> FindByIdsInIncludeParent(List<string> ids);
    }
}
