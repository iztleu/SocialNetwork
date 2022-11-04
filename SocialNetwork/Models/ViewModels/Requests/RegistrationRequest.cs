using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models.ViewModels.Requests;

public record RegistrationRequest
{
   public string Name { get; set; }
   public string Surname { get; set; }
   [Required]
   [Range(1, uint.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
   public uint Age { get; set; }
   public string? Floor { get; set; }
   public string? Interests { get; set; }
   public string? City { get; set; }
}