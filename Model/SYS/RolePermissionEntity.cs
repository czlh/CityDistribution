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
    [Table("SYS_RolePermission")]
    public class RolePermissionEntity : BusinessEntity
    {
        [MaxLength(36)]
        [Required(ErrorMessage="角色不能为空")]
        public string RoleId
        {
            get;
            set;
        }

        [ForeignKey("RoleId")]
        public RoleEntity Role
        {
            get;
            set;
        }

        [MaxLength(36)]
        [Required(ErrorMessage="权限不能为空")]
        public string ToolBarId
        {
            get;
            set;
        }

        [ForeignKey("ToolBarId")]
        public ToolBarEntity ToolBar
        {
            get;
            set;
        }
    }
}
