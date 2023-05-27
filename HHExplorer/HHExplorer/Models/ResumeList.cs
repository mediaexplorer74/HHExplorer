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
    public struct ResumeList
    {
        [JsonProperty("found")]
        public int Found { get; set; }

        [JsonProperty("pages")]
        public int Pages { get;  set; }

        [JsonProperty("per_page")]
        public int Per_Page { get; set; }

        //[JsonProperty("items")]
        public List<ResumeItem> Items { get; set; }      


    }//Salary model end



}//HHLibrary namespace end

