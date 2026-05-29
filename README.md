# SmartPOS-360
Billing and inventory system for shops/restaurants.
SmartPOS.Domain/
│
├── Common/
│   ├── BaseEntity.cs
│   └── AuditableEntity.cs
│
├── Identity/
│   ├── Entities/
│   │   ├── ApplicationUser.cs
│   │   ├── Role.cs
│   │   ├── RefreshToken.cs
│   │   ├── UserRole.cs
│   │   └── AuditLog.cs
│
├── Store/
│   ├── Entities/
│   │   ├── Store.cs
│   │   ├── Branch.cs
│   │   └── Warehouse.cs
│
├── Inventory/
│   ├── Entities/
│   │   ├── Category.cs
│   │   ├── Brand.cs
│   │   ├── Unit.cs
│   │   ├── Supplier.cs
│   │   ├── Product.cs
│   │   ├── ProductVariant.cs
│   │   ├── Stock.cs
│   │   ├── InventoryTransaction.cs
│   │   ├── PurchaseOrder.cs
│   │   └── PurchaseOrderItem.cs
│
  ├── POS/
│   ├── Entities/
│   │   ├── Customer.cs
│   │   ├── Sale.cs
│   │   ├── SaleItem.cs
│   │   ├── Payment.cs
│   │   ├── Discount.cs
│   │   └── Tax.cs
│
├── Reports/
│   ├── Entities/
│   │   └── SalesReport.cs
│
└── Settings/
    ├── Entities/
        ├── ApplicationSetting.cs
        ├── LanguageSetting.cs
        └── ThemeSetting.cs



        SmartPOS.Application/
│
├── DTOs/
│
├── Identity/
│   ├── LoginDto.cs
│   ├── RegisterDto.cs
│   ├── RefreshTokenDto.cs
│   ├── AuthResponseDto.cs
│   ├── UserDto.cs
│   ├── RoleDto.cs
│   └── ChangePasswordDto.cs
│
├── Store/
│   ├── StoreDto.cs
│   ├── CreateStoreDto.cs
│   ├── UpdateStoreDto.cs
│   ├── BranchDto.cs
│   ├── CreateBranchDto.cs
│   ├── UpdateBranchDto.cs
│   ├── WarehouseDto.cs
│   ├── CreateWarehouseDto.cs
│   └── UpdateWarehouseDto.cs
│
├── Inventory/
│   ├── Category/
│   │   ├── CategoryDto.cs
│   │   ├── CreateCategoryDto.cs
│   │   └── UpdateCategoryDto.cs
│   │
│   ├── Brand/
│   │   ├── BrandDto.cs
│   │   ├── CreateBrandDto.cs
│   │   └── UpdateBrandDto.cs
│   │
│   ├── Unit/
│   │   ├── UnitDto.cs
│   │   ├── CreateUnitDto.cs
│   │   └── UpdateUnitDto.cs
│   │
│   ├── Supplier/
│   │   ├── SupplierDto.cs
│   │   ├── CreateSupplierDto.cs
│   │   └── UpdateSupplierDto.cs
│   │
│   ├── Product/
│   │   ├── ProductDto.cs
│   │   ├── ProductListDto.cs
│   │   ├── ProductDetailsDto.cs
│   │   ├── CreateProductDto.cs
│   │   ├── UpdateProductDto.cs
│   │   ├── ProductVariantDto.cs
│   │   ├── CreateProductVariantDto.cs
│   │   └── UpdateProductVariantDto.cs
│   │
│   ├── Stock/
│   │   ├── StockDto.cs
│   │   ├── UpdateStockDto.cs
│   │   └── StockAdjustmentDto.cs
│   │
│   ├── InventoryTransaction/
│   │   ├── InventoryTransactionDto.cs
│   │   └── CreateInventoryTransactionDto.cs
│   │
│   └── PurchaseOrder/
│       ├── PurchaseOrderDto.cs
│       ├── PurchaseOrderItemDto.cs
│       ├── CreatePurchaseOrderDto.cs
│       ├── UpdatePurchaseOrderDto.cs
│       ├── CreatePurchaseOrderItemDto.cs
│       └── ReceivePurchaseOrderDto.cs
│
├── POS/
│   ├── Customer/
│   │   ├── CustomerDto.cs
│   │   ├── CreateCustomerDto.cs
│   │   └── UpdateCustomerDto.cs
│   │
│   ├── Sale/
│   │   ├── SaleDto.cs
│   │   ├── SaleDetailsDto.cs
│   │   ├── CreateSaleDto.cs
│   │   ├── SaleItemDto.cs
│   │   ├── CreateSaleItemDto.cs
│   │   ├── PaymentDto.cs
│   │   ├── CreatePaymentDto.cs
│   │   ├── DiscountDto.cs
│   │   └── TaxDto.cs
│
├── Reports/
│   ├── SalesReportDto.cs
│   ├── DashboardSummaryDto.cs
│   ├── RevenueChartDto.cs
│   ├── TopSellingProductDto.cs
│   └── SalesAnalyticsDto.cs
│
├── Settings/
│   ├── ApplicationSettingDto.cs
│   ├── LanguageSettingDto.cs
│   ├── ThemeSettingDto.cs
│   └── UpdateApplicationSettingDto.cs
│
└── Common/
    ├── ApiResponseDto.cs
    ├── PaginationDto.cs
    ├── PagedResultDto.cs
    └── DropdownDto.cs