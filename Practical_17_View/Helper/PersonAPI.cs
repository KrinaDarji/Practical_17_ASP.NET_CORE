using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Practical_17_View.Helper
{
    public class PersonAPI
    {
        public HttpClient Initial()
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44387/");
            return client;
        }
    }
}
