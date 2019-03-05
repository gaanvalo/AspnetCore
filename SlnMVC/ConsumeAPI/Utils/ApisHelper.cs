using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeAPI.Utils
{
    public class ApisHelper
    {
        private readonly string _baseurl;

        public ApisHelper(string Opcion)
        {
            _baseurl = Opcion;
        }

        public async Task<HttpResponseMessage> ConsumirApiGet(string nameApi, string SecondKey)
        {
            Token.TokenManager tokeManager = new Token.TokenManager();
            using (var client = new HttpClient())
            {
                //Service base url  
                client.BaseAddress = new Uri(_baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokeManager.GenerateTokenJwt(SecondKey));

                //Request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Return response  
                var res = await client.GetAsync(nameApi);

                return res;
            }
        }

        public async Task<HttpResponseMessage> ConsumirApiPut(string nameApi, string json, string SecondKey)
        {
            Token.TokenManager tokeManager = new Token.TokenManager();
            using (var client = new HttpClient())
            {
                //Service base url  
                client.BaseAddress = new Uri(_baseurl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokeManager.GenerateTokenJwt(SecondKey));
                //Request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                //Return response
                var res = await client.PutAsync(nameApi, content);

                return res;
            }
        }

        public async Task<HttpResponseMessage> ConsumirApiPost(string nameApi, string json, string SecondKey)
        {
            try
            {
                Token.TokenManager tokeManager = new Token.TokenManager();
                //CancellationTokenSource cts = new CancellationTokenSource();
                //cts.CancelAfter(2500); // para tener en cuenta si se agrega TimeOut
                using (var client = new HttpClient())
                {
                    //Service base url  
                    client.BaseAddress = new Uri(_baseurl);

                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokeManager.GenerateTokenJwt(SecondKey));
                    //Request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    //Return response
                    //var res = await client.PostAsync(nameApi, content, cts.Token);
                    var res = await client.PostAsync(nameApi, content);
                    //log.Info(res);
                    return res;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
