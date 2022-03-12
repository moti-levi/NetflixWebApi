using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetflixWebApi.Model
{

    public class ContactRequest
    {
        public string userId { get; set; }
        public int contentType { get; set; }
    }
}
