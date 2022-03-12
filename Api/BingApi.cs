using Firebase.Database;
using Firebase.Database.Query;
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
        enum ContentType
        {
            s = 1,
            m = 2,
            any = 3
        }


        private string strUrl = String.Format("https://api.reelgood.com/v3.0/content/random?availability=onAnySource&content_kind=both&nocache=true&region=us&sources=netflix");
        public BingApi()
        {

        }


        #region Get Content
        public async Task<ContentDataModel> GetContent(string UserId, int ContentType)
        {
            bool foundContent = true;

            string typeC = ConvertContentType(ContentType);

            ContentDataModel t = null;

            HttpClient client = new HttpClient();

            //get user history wathing data from FB
            IReadOnlyCollection<FirebaseObject<UserHistoryContent>> histContent = await GetdataAsync(UserId);

            while (foundContent)
            {
                //cnt++;
                HttpResponseMessage response = await client.GetAsync(strUrl);

                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    t = JsonConvert.DeserializeObject<ContentDataModel>(str);
                }

                if (!existHistoryContent(histContent, t.id))
                {
                    if (ContentType != 3)
                    {
                        if ((t.content_type).Trim() == typeC)
                            foundContent = false;
                    }
                    else
                        foundContent = false;
                }

            }
            return t;
        }



        private bool existHistoryContent(IReadOnlyCollection<FirebaseObject<UserHistoryContent>> histContent,
            string contentID)
        {
            foreach (var Item in histContent)
            {
                if (Item.Object.contentID == contentID)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<ContentDataModel> GetContent()
        {
            bool foundContent = true;
            ContentDataModel t = null;
            HttpClient client = new HttpClient();

            while (foundContent)
            {
                //cnt++;
                HttpResponseMessage response = await client.GetAsync(strUrl);
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    t = JsonConvert.DeserializeObject<ContentDataModel>(str);
                    foundContent = false;
                }

            }
            return t;

        }

        private string ConvertContentType(int contentType)
        {
            switch (contentType)
            {
                case 1:
                    return "s";
                case 2:
                    return "m";
            }
            return "any";
        }
        #endregion

        public async Task<IReadOnlyCollection<FirebaseObject<UserHistoryContent>>> GetdataAsync(string userId)
        {
            var firebase = new FirebaseClient("https://reactdb-f0ba3-default-rtdb.firebaseio.com/");
            var historyContents = await firebase.Child("userRank").OrderBy("userid")
            .EqualTo(userId) //("zMbDMFd0nvMTqFOLHrohj82aLz32")
            .OnceAsync<UserHistoryContent>();

            return historyContents;
        }
    }

    public class UserHistoryContent
    {
        public string contentID { get; set; }
    }
}
