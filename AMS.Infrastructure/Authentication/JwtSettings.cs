﻿namespace AMS.Infrastructure.Authentication;

public class JwtSettings
{
    public static string SectionName = "JwtSettings";
    public string SecretKey { get; init; }
    public int ExpireInHours { get; init; }
    public string Issuer { get; init; }
    public string Audience { get; init; }


}