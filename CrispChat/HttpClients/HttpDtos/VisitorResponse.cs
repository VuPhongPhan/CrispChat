﻿using System.Text.Json.Serialization;

namespace CrispChat.HttpClients.HttpDtos
{
    public class VisitorResponse
    {
        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("data")]
        public List<VisitorData> Data { get; set; }
    }

    public partial class VisitorData
    {
        [JsonPropertyName("session_id")]
        public string SessionId { get; set; }

        [JsonPropertyName("initiated")]
        public bool Initiated { get; set; }

        [JsonPropertyName("nickname")]
        public string Nickname { get; set; }

        [JsonPropertyName("email")]
        public object Email { get; set; }

        [JsonPropertyName("avatar")]
        public object Avatar { get; set; }

        [JsonPropertyName("geolocation")]
        public Geolocation Geolocation { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("last_page")]
        public LastPage LastPage { get; set; }

        [JsonPropertyName("useragent")]
        public string Useragent { get; set; }

        [JsonPropertyName("timezone")]
        public long Timezone { get; set; }

        [JsonPropertyName("capabilities")]
        public List<string> Capabilities { get; set; }

        [JsonPropertyName("locales")]
        public List<string> Locales { get; set; }
    }

    public partial class LastPage
    {
        [JsonPropertyName("page_title")]
        public string PageTitle { get; set; }

        [JsonPropertyName("page_url")]
        public Uri PageUrl { get; set; }
    }
}