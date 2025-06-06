﻿namespace Application.Common.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public int ExpireDays { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
