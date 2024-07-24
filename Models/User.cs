using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MTGCollectionApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string DiscordId { get; set; }

        [MaxLength(255)]
        public string DiscordUsername { get; set; }

        [MaxLength(255)]
        public string DiscordDiscriminator { get; set; }

        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string AccessToken { get; set; }

        [MaxLength(255)]
        public string RefreshToken { get; set; }

        // Navigation property
        public ICollection<Collection> Collections { get; set; }

    }
}
