using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HovedOpgaveWebAPI.Models
{
    public class GameData
    {
        [Key]
        public int UserId { get; set; } // Primary key

        [Required]
        public int GameId { get; set; } = 1; // Always 1 for now

        [Required]
        [Column(TypeName = "jsonb")] // PostgreSQL-specific type for JSON
        public string Body { get; set; } = "{}"; // Stores JSON data as string
    }
}
