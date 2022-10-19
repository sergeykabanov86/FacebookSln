using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookNF.Models
{
    internal class UserModel
    {
        public string id { get; set; }
        public string name { get; set; }

        public string last_name { get; set; }

        public override string ToString()
        {
            return string.Format("{0} (Id:{1})", name, id);
        }
    }
}
