﻿using System.ComponentModel.DataAnnotations;

namespace ASP_NET_CORE_EF.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
