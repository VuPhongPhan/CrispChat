using System.Text.Json.Serialization;

namespace CrispChat.HttpClients.HttpDtos
{
    public class PeopleResponse
    {
        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("data")]
        public List<PeopleData> Data { get; set; }
    }
    public partial class PeopleData
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }

        [JsonPropertyName("people_id")]
        public string PeopleId { get; set; }

        [JsonPropertyName("person")]
        public Person Person { get; set; }

        [JsonPropertyName("segments")]
        public List<string> Segments { get; set; }

        [JsonPropertyName("updated_at")]
        public long UpdatedAt { get; set; }

        [JsonPropertyName("active")]
        public Active Active { get; set; }

        [JsonPropertyName("company")]
        public Company Company { get; set; }

        [JsonPropertyName("score")]
        public long? Score { get; set; }
    }

    public partial class Company
    {
        [JsonPropertyName("legal_name")]
        public string LegalName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("domain")]
        public string Domain { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("metrics")]
        public Metrics Metrics { get; set; }
    }

    public partial class Metrics
    {
        [JsonPropertyName("employees")]
        public long Employees { get; set; }

        [JsonPropertyName("market_cap")]
        public long MarketCap { get; set; }

        [JsonPropertyName("raised")]
        public long Raised { get; set; }

        [JsonPropertyName("arr")]
        public long Arr { get; set; }
    }

    public partial class Person
    {
        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        [JsonPropertyName("geolocation")]
        public Geolocation Geolocation { get; set; }

        [JsonPropertyName("locales")]
        public List<string> Locales { get; set; }

        [JsonPropertyName("nickname")]
        public string Nickname { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("timezone")]
        public long? Timezone { get; set; }

        [JsonPropertyName("profiles")]
        public List<Profile> Profiles { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("website")]
        public Uri Website { get; set; }

        [JsonPropertyName("employment")]
        public Employment Employment { get; set; }
    }

    public partial class Employment
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("domain")]
        public string Domain { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
   
    public partial class Profile
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("handle")]
        public string Handle { get; set; }
    }
}
