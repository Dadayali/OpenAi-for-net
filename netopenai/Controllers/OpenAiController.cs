using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netopenai.Controllers;

namespace OpenAiController.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpenAiController : ControllerBase
    {
        IHttpClientFactory _httpClientFactory;
        public OpenAiController(IHttpClientFactory httpClient)
        {
            _httpClientFactory = httpClient;
        }
        // 短路器


        [HttpPost]
        public async Task<ResponseInfo> Call(RequestInfo info)
        {
            Console.WriteLine(info.Message);
            Console.WriteLine(info.Temperature);
            Console.WriteLine(info.MaxTokens);
            var request = new
            {
                model = "text-davinci-003",
                prompt = info.Message,
                max_tokens = info.MaxTokens,
                temperature = info.Temperature,
                top_p = 1,
                frequency_penalty = 0,
                presence_penalty = 0
            };
            
            var requestBody = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            string openAiKey = ""; // 这儿写你的openai 的key  fill in you api key
            //string openAiUrl = "https://api.openai.com/v1/completions";
            string openAiUrl = "https://api.openai.com/v1/completions";
            ResponseInfo result = new ();

            using (var client = _httpClientFactory.CreateClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + openAiKey);
                    StringContent content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(openAiUrl, content);
                    var responseBody = await response.Content.ReadAsStringAsync();
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseInfo>(responseBody);
                }
                catch(Exception ex)
                {
                    result = new() { choices = new Choise[1] { new Choise { text=ex.Message} } };
                }
            }
            return result;
            //return Ok(responseInfo);
        }
    }
}
