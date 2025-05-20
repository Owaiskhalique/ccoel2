using System;
using System.Collections.Generic;

namespace SensitiveDataDetection.Data
{
    public static class SensitivePatternsData
    {
        public static List<string> SensitiveCaseNumbers = new List<string>
        {
            "SENSITIVE123",
            "SECURITY456"
        };

        public static List<string> SensitivePatterns = new List<string>
        {
            @"\d{9}",            
            @"[A-Za-z]{3}-\d{3}" 
        };
    }
}

