using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL.SYS;
using System.Data.Entity;
using Model.SYS;

namespace DAL.SYS
{
    public class ToolBarDAL : AbsBaseDAL<ToolBarEntity>, IToolBarDAL
    {
        public IQueryable<ToolBarEntity> FindByIdsIn(List<string> ids)
        {
            return CdDbContext.ToolBars.Where(t => ids.Contains(t.Id));
        }


        public IQueryable<ToolBarEntity> FindByIdsInIncludeParent(List<string> ids)
        {
            return CdDbContext.ToolBars.Include(tb=>tb.Parent).Where(t => ids.Contains(t.Id));
        }
    }
}
