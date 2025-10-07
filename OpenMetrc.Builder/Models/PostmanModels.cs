using System.Text.Json.Serialization;

namespace Postman.Collection.Models
{
    /// <summary>
    /// Represents the root of a Postman collection JSON structure.
    /// </summary>
    public class PostmanCollection
    {
        [JsonPropertyName("auth")]
        public Auth Auth { get; set; }

        [JsonPropertyName("info")]
        public Info Info { get; set; }

        [JsonPropertyName("item")]
        public List<Item> Item { get; set; }

        [JsonPropertyName("variable")]
        public List<Variable> Variable { get; set; }
    }

    /// <summary>
    /// Represents the authentication details for the collection.
    /// </summary>
    public class Auth
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("basic")]
        public List<BasicAuth> Basic { get; set; }
    }

    /// <summary>
    /// Represents a key-value pair for basic authentication.
    /// </summary>
    public class BasicAuth
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    /// <summary>
    /// Represents the metadata of the Postman collection.
    /// </summary>
    public class Info
    {
        [JsonPropertyName("_postman_id")]
        public string PostmanId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("schema")]
        public string Schema { get; set; }
    }

    /// <summary>
    /// Represents an item in a Postman collection, which can be a folder or a request.
    /// </summary>
    public class Item
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("item")]
        public List<Item> Items { get; set; }

        [JsonPropertyName("request")]
        public Request Request { get; set; }
    }

    /// <summary>
    /// Represents an API request within a Postman collection item.
    /// </summary>
    public class Request
    {
        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("header")]
        public List<object> Header { get; set; }

        [JsonPropertyName("url")]
        public Url Url { get; set; }
    }

    /// <summary>
    /// Represents the URL structure for a request.
    /// </summary>
    public class Url
    {
        [JsonPropertyName("host")]
        public List<string> Host { get; set; }

        [JsonPropertyName("path")]
        public List<string> Path { get; set; }

        [JsonPropertyName("query")]
        public List<Query> Query { get; set; }
    }

    /// <summary>
    /// Represents a query parameter for a URL.
    /// </summary>
    public class Query
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    /// <summary>
    /// Represents a variable defined in the Postman collection.
    /// </summary>
    public class Variable
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
