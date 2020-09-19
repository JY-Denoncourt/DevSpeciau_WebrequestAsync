using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumerDemo
{
    public class DogProcessor
    {
        public static async Task<DogResultModel> LoadDog()
        {
            string url;
            DogResultModel dogImgs = new DogResultModel();

            url = $"https://dog.ceo/api/breeds/image/random";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {

                if (response.IsSuccessStatusCode)
                {
                    dogImgs.Dog1 = await response.Content.ReadAsAsync<DogModel>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {

                if (response.IsSuccessStatusCode)
                {
                    dogImgs.Dog2 = await response.Content.ReadAsAsync<DogModel>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

            return dogImgs;
        }
    }
}
