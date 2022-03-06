using NetflixWebApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetflixWebApi.Api
{
    public class BingApi
    {
        private string strUrl = String.Format("https://api.reelgood.com/v3.0/content/random?availability=onAnySource&content_kind=both&nocache=true&region=us&sources=netflix");
        public BingApi()
        {

        }


        #region Get Content
        public async Task<ContentDataModel> GetContent()
        {
            ContentDataModel t = null;
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(strUrl);
            HttpResponseMessage response = await client.GetAsync(strUrl);
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                t = JsonConvert.DeserializeObject<ContentDataModel>(str);
            }
            return t;
        }
        #endregion

        

    }
}
