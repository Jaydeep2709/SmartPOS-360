namespace SmartPOS.Application.DTOs.Inventory.Product;

public class CreateProductVariantDto
{
    public Guid ProductId { get; set; }

    public string VariantName { get; set; }

    public string SKU { get; set; }

    public string Barcode { get; set; }

    public decimal SellingPrice { get; set; }

    public decimal CostPrice { get; set; }
}