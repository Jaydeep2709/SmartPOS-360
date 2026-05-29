using SmartPOS.Domain.Common;

namespace SmartPOS.Domain.Settings.Entities;

public class ThemeSetting : BaseEntity
{
    public string ThemeName { get; set; }

    public bool IsDarkMode { get; set; }
}