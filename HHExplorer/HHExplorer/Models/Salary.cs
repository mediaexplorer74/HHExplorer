using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace HHLibrary
{
    // Salary model
    public struct Salary
    {
        [JsonProperty("from")]
        public string? From { get; set; }

        [JsonProperty("to")]
        public string? To { get;  set; }

        [JsonProperty("currency")]
        public string? Currency { get; set; }

        [JsonProperty("gross")]
        public string? Gross { get; set; }

       
    }//Salary model end



}//HHLibrary namespace end

