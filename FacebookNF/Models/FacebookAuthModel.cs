using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookNF.Models
{
    public class FacebookAuthModel
    {
        public string access_token { get; set; }

        public long data_access_expiration_time { get; set; }

        public long expires_in { get; set; }

    }
}
