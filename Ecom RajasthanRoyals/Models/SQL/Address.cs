using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ecom_RajasthanRoyals.Models.SQL
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}