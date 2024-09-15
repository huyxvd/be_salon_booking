﻿namespace Domain.Entities;
public class User : BaseEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; } = new byte[32];
    public byte[] PasswordSalt { get; set; } = new byte[32];
    public string? VerificationToken { get; set; }
    public DateTime? VerifiedAt { get; set; }
}