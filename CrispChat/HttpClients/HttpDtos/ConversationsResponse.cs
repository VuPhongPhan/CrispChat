using System.Text.Json.Serialization;

namespace CrispChat.HttpClients.HttpDtos
{
    public class ConversationsResponse
    {
        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("data")]
        public List<ConversationData> ConversationData { get; set; }
    }

    public partial class ConversationData
    {
        [JsonPropertyName("session_id")]
        public string SessionId { get; set; }

        [JsonPropertyName("active")]
        public Active Active { get; set; }

        [JsonPropertyName("availability")]
        public string Availability { get; set; }

        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }

        [JsonPropertyName("is_blocked")]
        public bool IsBlocked { get; set; }

        [JsonPropertyName("mentions")]
        public List<string> Mentions { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("participants")]
        public List<string> Participants { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("status")]
        public long Status { get; set; }

        [JsonPropertyName("unread")]
        public Unread Unread { get; set; }

        [JsonPropertyName("updated_at")]
        public long UpdatedAt { get; set; }

        [JsonPropertyName("website_id")]
        public string WebsiteId { get; set; }

        [JsonPropertyName("last_message")]
        public string LastMessage { get; set; }

        [JsonPropertyName("people_id")]
        public string PeopleId { get; set; }

        [JsonPropertyName("compose")]
        public Compose Compose { get; set; }

        [JsonPropertyName("assigned")]
        public Assigned Assigned { get; set; }
    }

    public partial class Active
    {
        [JsonPropertyName("last")]
        public long Last { get; set; }

        [JsonPropertyName("now")]
        public bool Now { get; set; }
    }

    public partial class Assigned
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }

    public partial class Compose
    {
        [JsonPropertyName("operator")]
        public Dictionary<string, Tor> Operator { get; set; }

        [JsonPropertyName("visitor")]
        public Tor Visitor { get; set; }
    }

    public partial class Tor
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("excerpt")]
        public object Excerpt { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }
    }

    public partial class User
    {
        [JsonPropertyName("nickname")]
        public string Nickname { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }

    public partial class Meta
    {
        [JsonPropertyName("nickname")]
        public string Nickname { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        //[JsonPropertyName("data")]
        //public string Data { get; set; }

        //[JsonPropertyName("device")]
        //public Device Device { get; set; }

        [JsonPropertyName("segments")]
        public List<string> Segments { get; set; }
    }
    

    public partial class Device
    {
        [JsonPropertyName("geolocation")]
        public Geolocation Geolocation { get; set; }

        [JsonPropertyName("capabilities")]
        public List<string> Capabilities { get; set; }

        [JsonPropertyName("locales")]
        public List<string> Locales { get; set; }

        [JsonPropertyName("timezone")]
        public long Timezone { get; set; }

        [JsonPropertyName("system")]
        public SystemClass System { get; set; }
    }

    public partial class Geolocation
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("coordinates")]
        public Coordinates Coordinates { get; set; }
    }

    public partial class Coordinates
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }

    public partial class SystemClass
    {
        [JsonPropertyName("os")]
        public Engine Os { get; set; }

        [JsonPropertyName("engine")]
        public Engine Engine { get; set; }

        [JsonPropertyName("browser")]
        public Browser Browser { get; set; }

        [JsonPropertyName("useragent")]
        public string Useragent { get; set; }
    }

    public partial class Browser
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("major")]
        public long Major { get; set; }
    }

    public partial class Engine
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }

    public partial class Unread
    {
        [JsonPropertyName("operator")]
        public long Operator { get; set; }

        [JsonPropertyName("visitor")]
        public long Visitor { get; set; }
    }
}
