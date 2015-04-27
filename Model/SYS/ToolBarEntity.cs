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
    [Table("SYS_ToolBar")]
    public class ToolBarEntity : BusinessEntity
    {
        [MaxLength(20)]
        public string Title
        {
            get;
            set;
        }

        [MaxLength(20)]
        public string Code
        {
            get;
            set;
        }

        public bool Enabled
        {
            get;
            set;
        }

        public bool IsAuthControl
        {
            get;
            set;
        }

        public int ViewType
        {
            get;
            set;
        }

        public bool IsShow
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

        [ForeignKey("ParentId")]
        public ToolBarEntity Parent
        {
            get;
            set;
        }

        public int TabIndex
        {
            get;
            set;
        }

        [MaxLength(36)]
        public string MenuId
        {
            get;
            set;
        }

        [ForeignKey("MenuId")]
        public MenuEntity Menu
        {
            get;
            set;
        }
    }
}
