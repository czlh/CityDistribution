using Model.BaseInfo;
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
    [Table("SYS_UserInfo")]
    public class UserInfoEntity : BusinessEntity
    {
        [MaxLength(50)]
        public string UserName
        {
            get;
            set;
        }

        [MaxLength(50)]
        public string PassWord
        {
            get;
            set;
        }

        public bool Enabled
        {
            get;
            set;
        }

        [MaxLength(36)]
        public string RoleId
        {
            get;
            set;
        }

        public bool IsAdmin
        {
            get;
            set;
        }

        public bool IsSystem
        {
            get;
            set;
        }

        //[ForeignKey("SiteId")]
        //public SiteEntity Site
        //{
        //    get;
        //    set;
        //}

        //[MaxLength(36)]
        //public String SiteId
        //{
        //    get;
        //    set;
        //}
    }
}
