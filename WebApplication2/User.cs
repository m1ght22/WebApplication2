using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;
using System.Reflection;
using Newtonsoft.Json;

namespace WebApplication2
{
    [Table("users")]
    public class User : BaseModel
    {
        [PrimaryKey]
        public int id { get; set; }

        [Column("name")]
        public string name { get; set; }

        [Column("age")]
        public int age { get; set; }

        [Column("password")]
        public string password { get; set; }

        [Column("email")]
        public string email { get; set; }
    }

    public class updatingName
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }

    }

    public class updatingEmail
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("email")]
        public string email { get; set; }

    }

    public class updatingPassword
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }

    }

    public class deleteUser
    {
        [JsonProperty("id")]
        public int id { get; set; }
    }
}