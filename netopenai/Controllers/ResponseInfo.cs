using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netopenai.Controllers
{
    public class ResponseInfo
    {
        public string id { get; set; }
        public string @object { get; set; }
        public int created { get; set; }
        public string model { get; set; }
        public Choise[] choices { get; set; }
        public Usage usage { get; set; }
    }
    public class Choise
    {
        public string text { get; set; }
        public int index { get; set; }
        public object logprobs { get; set; }
        public string finish_reason { get; set; }
    }

    public class Usage
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
    }
}