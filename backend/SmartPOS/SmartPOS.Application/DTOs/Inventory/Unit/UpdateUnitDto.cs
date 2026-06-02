namespace SmartPOS.Application.DTOs.Inventory.Unit;

public class UpdateUnitDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string ShortName { get; set; } = string.Empty;
}