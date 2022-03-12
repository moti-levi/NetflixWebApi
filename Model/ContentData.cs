using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetflixWebApi.Model
{
    public class ContentDataModel
    {
        public string id { get; set; }
        public string title { get; set; }
        public string overview { get; set; }
        public string imdb_rating { get; set; }
        public string content_type { get; set; }
        public string contentID { get; set; }
    }
}
