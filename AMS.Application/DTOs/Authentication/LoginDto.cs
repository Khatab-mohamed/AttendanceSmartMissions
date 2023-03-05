﻿namespace AMS.Application.DTOs.Authentication;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    public  string DeviceSerialNumber { get; set; }

}