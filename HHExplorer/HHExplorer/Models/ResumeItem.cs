using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace HHLibrary.Models
{
    // ResumeList model
    public struct ResumeItem
    {
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get;  set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }


    }//Salary model end



}//HHLibrary namespace end

