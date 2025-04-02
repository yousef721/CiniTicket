using System.ComponentModel.DataAnnotations;

namespace CineTicket.Application.ViewModels.IdentityViewModels;

public class LoginVM
{
    [Required(ErrorMessage = "Email or Username is required")]
    [Display(Name = "Email or Username")]
    public string Account { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; } = false;
}
