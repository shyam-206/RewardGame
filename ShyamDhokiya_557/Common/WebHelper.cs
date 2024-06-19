using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShyamDhokiya_557.Common
{
    public class WebHelper
    {
        public static async Task<string> HttpRequestResponse(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var token = HttpContext.Current.Request.Cookies["jwt"]?.Value;
                    client.BaseAddress = new Uri("http://localhost:61159/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    if (token != null)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
                    }

                    HttpResponseMessage resonse = await client.GetAsync(url);

                    if (resonse.IsSuccessStatusCode)
                    {
                        return resonse.Content.ReadAsStringAsync().Result;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static async Task<string> HttpPostRequestResponse(string url,string content)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:61159/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage resonse = await client.PostAsync(url,new StringContent(content,Encoding.UTF8,"application/json"));

                    resonse.EnsureSuccessStatusCode();

                    if (resonse.IsSuccessStatusCode)
                    {
                        return await resonse.Content.ReadAsStringAsync();
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}