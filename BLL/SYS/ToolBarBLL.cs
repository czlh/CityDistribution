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
    public class ToolBarBLL : AbsBusinessBaseBLL<ToolBarEntity, IToolBarDAL>
    {

        protected override IToolBarDAL GetDal()
        {
            return DALFactory.GetToolBarDAL();
        }
    }
}
