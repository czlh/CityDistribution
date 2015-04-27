using ClassFactory;
using IDAL.SYS;
using Model.SYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.SYS
{
    public class MenuBLL : AbsBusinessBaseBLL<MenuEntity, IMenuDAL>
    {
        protected override IMenuDAL GetDal()
        {
            return DALFactory.GetMenuDAL();
        }
    }
}
