using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.Settings.Entities
{
    public class LanguageSetting : BaseEntity
    {
        public string DefaultLanguage { get; set; }

        // Example:
        // en,hi,mr
        public string SupportedLanguages { get; set; }
    }
}
