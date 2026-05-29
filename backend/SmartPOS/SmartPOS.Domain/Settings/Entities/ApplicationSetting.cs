using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.Settings.Entities
{
    public class ApplicationSetting : BaseEntity
    {
        public string SettingKey { get; set; }

        public string SettingValue { get; set; }

        public string Description { get; set; }
    }
}
