﻿using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.UserDTO;
public class RegisterUserDTO
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required, MinLength(6)]
    public string Password { get; set; } = string.Empty;
    [Required, Compare("Password")]
    public string ConfirmPassword {  get; set; } = string.Empty;
}