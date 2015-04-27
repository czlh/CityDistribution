using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Test
{
    public class TestEntity : BusinessEntity
    {
        public string Name
        {
            get;
            set;
        }

        public string Desc
        {
            get;
            set;
        }
    }
}
