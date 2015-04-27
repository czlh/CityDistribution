using Model.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BaseInfo
{
    [Table("AA_Site")]
    public class SiteEntity : BusinessEntity
    {
        [MaxLength(50)]
        public string Name
        {
            get;
            set;
        }
    }
}
