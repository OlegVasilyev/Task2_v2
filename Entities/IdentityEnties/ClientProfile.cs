﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.IdentityEnties
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
