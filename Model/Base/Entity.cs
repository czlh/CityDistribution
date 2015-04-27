using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Entity
    {
        [NotMapped]
        private Dictionary<string, object> _dyncField;

        public Dictionary<string, object> DyncField
        {
            get
            {
                if (_dyncField == null)
                    _dyncField = new Dictionary<string, object>();
                return _dyncField;
            }
            set
            {
                _dyncField = value;
            }
        }
    }
}
