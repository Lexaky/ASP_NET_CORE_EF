using System.ComponentModel.DataAnnotations;

namespace ASP_NET_CORE_EF.DTO
{
    public class UserDTO
    {
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
    }
}
