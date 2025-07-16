using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Ecom_RajasthanRoyals.Models.SQL
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
