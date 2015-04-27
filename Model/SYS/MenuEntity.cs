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
    [Table("SYS_Menu")]
    public class MenuEntity : BusinessEntity
    {
        [MaxLength(50)]
        public string Title
        {
            get;set;
        }

        [MaxLength(20)]
        public string Code
        {
            get;
            set;
        }

        [MaxLength(200)]
        public string Uri
        {
            get;
            set;
        }

        [MaxLength(20)]
        public string ShortCut
        {
            get;
            set;
        }

        [MaxLength(36)]
        public string ParentId
        {
            get;
            set;
        }

        public int TabIndex
        {
            get;
            set;
        }

        public bool IsAuthControl
        {
            get;
            set;
        }

        public bool IsShow
        {
            get;
            set;
        }
    }
}
