using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HovedOpgaveWebAPI.Models
{
    public class GameData
{
    [Required]
    public string UserId { get; set; } = string.Empty; 

    [Required]
    public string GameId { get; set; } = "1"; 

    [Required]
    [Column(TypeName = "jsonb")]
    public string Body { get; set; } = "{}"; // Stores JSON data as string
}
}
