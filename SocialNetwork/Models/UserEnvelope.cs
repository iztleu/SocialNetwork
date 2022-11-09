using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models;

public record UserEnvelope<T>([Required] T User);