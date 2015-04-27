using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    //[Newtonsoft.Json.JsonIgnore]
    //[JsonProperty("nnnn")]

    public class BusinessEntity:Entity
    {
        [Key]
        [MaxLength(36)]
        public string Id
        {
            get;
            set;
        }

        [MaxLength(50)]
        public string CreatedBy
        {
            get;
            set;
        }

        public DateTime? CreatedTime
        {
            get;
            set;
        }

        [MaxLength(50)]
        public string UpdatedBy
        {
            get;
            set;
        }

        public DateTime? UpdatedTime
        {
            get;
            set;
        }
    }
}
