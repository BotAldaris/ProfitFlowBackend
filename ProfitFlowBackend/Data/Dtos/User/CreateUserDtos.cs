using System.ComponentModel.DataAnnotations;

namespace ProfitFlowBackend.Data.Dtos.User;

public class CreateUserDtos
{
    [Required]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }
}
