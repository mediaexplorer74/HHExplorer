using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace HHLibrary
{
    // Employer model
    public struct Employer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get;  set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("alternate_url")]
        public string Alternate_url { get; set; }

        [JsonProperty("vacancies_url")]
        public string Vacancies_url { get; set; }

        [JsonProperty("trusted")]
        public string Trusted { get; set; }


    }//Salary model end



}//HHLibrary namespace end

