using SensitiveDataDetection.Models;
using SensitiveDataDetection.Helpers;
using System;
using System.Collections.Generic;

namespace SensitiveDataDetection.Services
{
    public class SensitivityCheckService
    {
        private readonly List<string> sensitiveCaseNumbers = SensitivePatternsData.SensitiveCaseNumbers;
        private readonly List<string> sensitivePatterns = SensitivePatternsData.SensitivePatterns;

        public SensitivityStatus CheckFieldSensitivity(string field, string value)
        {
            if (string.IsNullOrEmpty(value)) return new SensitivityStatus { Field = field, Status = "Safe" };

            // Check if the value matches any predefined sensitive patterns
            foreach (var pattern in sensitivePatterns)
            {
                if (PatternHelper.IsMatch(pattern, value))
                {
                    return new SensitivityStatus { Field = field, Status = "Sensitive" };
                }
            }

            // Check if the value is in the list of known sensitive case numbers
            if (sensitiveCaseNumbers.Contains(value))
            {
                return new SensitivityStatus { Field = field, Status = "Sensitive" };
            }

            return new SensitivityStatus { Field = field, Status = "Safe" };
        }
    }
}

