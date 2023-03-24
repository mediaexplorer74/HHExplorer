using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace HHLibrary
{
    // Vacancy model
    public class Vacancy
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get;  set; }

        [JsonProperty("salary")]
        public Salary? Salary { get; set; }

        [JsonProperty("employer")]
        public Employer? Employer { get; set; }

        [JsonProperty("address")]
        public Address? Address { get; set; }

        [JsonProperty("published_at")]
        public string? Published_at { get; set; }

        [JsonProperty("alternate_url")]
        public string? Alternate_url { get; set; }

        [JsonProperty("schedule")]
        public Schedule? Schedule { get; set; }

        [JsonProperty("salary_from")]
        public string? Salary_from { get; set; }

        [JsonProperty("salary_to")]
        public string? Salary_to { get; set; }


    }//Vacancy model end



}//HHLibrary namespace end

