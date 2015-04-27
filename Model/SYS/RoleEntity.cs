using Model.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SYS
{
    [Table("SYS_Role")]
    public class RoleEntity : BusinessEntity
    {
        [MaxLength(20)]
        public string Name
        {
            get;
            set;
        }

        public bool Enabled
        {
            get;
            set;
        }

        public int TabIndex
        {
            get;
            set;
        }
    }
}
