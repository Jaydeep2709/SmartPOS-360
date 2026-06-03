# SmartPOS-360
Billing and inventory system for shops/restaurants


```text

SMARTPOS-360
│
├── Frontend (Angular)
│
│   ├── src
│   │
│   ├── app
│   │
│   ├── Core
│   │   │
│   │   ├── guards
│   │   │   ├── auth.guard.ts
│   │   │   ├── role.guard.ts
│   │   │   ├── login.guard.ts
│   │   │
│   │   ├── interceptors
│   │   │   ├── auth.interceptor.ts
│   │   │   ├── error.interceptor.ts
│   │   │   ├── loading.interceptor.ts
│   │   │
│   │   ├── services
│   │   │   ├── auth.service.ts
│   │   │   ├── user.service.ts
│   │   │   ├── role.service.ts
│   │   │   ├── product.service.ts
│   │   │   ├── category.service.ts
│   │   │   ├── brand.service.ts
│   │   │   ├── inventory.service.ts
│   │   │   ├── stock.service.ts
│   │   │   ├── supplier.service.ts
│   │   │   ├── customer.service.ts
│   │   │   ├── warehouse.service.ts
│   │   │   ├── purchase-order.service.ts
│   │   │   ├── sales.service.ts
│   │   │   ├── report.service.ts
│   │   │   ├── translation.service.ts
│   │   │   ├── theme.service.ts
│   │   │   ├── layout.service.ts
│
│   ├── Features
│   │
│   │   ├── auth
│   │   │   ├── login
│   │   │   │   ├── login.html
│   │   │   │   ├── login.scss
│   │   │   │   ├── login.spec.ts
│   │   │   │   ├── login.ts
│   │   │   │
│   │   │   ├── forgot-password
│   │   │       ├── forgot-password.html
│   │   │       ├── forgot-password.scss
│   │   │       ├── forgot-password.spec.ts
│   │   │       ├── forgot-password.ts
│   │
│   │
│   │   ├── dashboard
│   │   │
│   │   │   ├── components
│   │   │   │   ├── stat-card
│   │   │   │   │   ├── stat-card.html
│   │   │   │   │   ├── stat-card.scss
│   │   │   │   │   ├── stat-card.ts
│   │   │   │
│   │   │   │   ├── sales-chart
│   │   │   │   │   ├── sales-chart.html
│   │   │   │   │   ├── sales-chart.scss
│   │   │   │   │   ├── sales-chart.ts
│   │   │   │
│   │   │   │   ├── low-stock-widget
│   │   │   │   ├── recent-sales-widget
│   │   │
│   │   │   ├── dashboard.html
│   │   │   ├── dashboard.scss
│   │   │   ├── dashboard.ts
│
│   │
│   │   ├── products
│   │   │
│   │   │   ├── product-list
│   │   │   │   ├── product-list.html
│   │   │   │   ├── product-list.scss
│   │   │   │   ├── product-list.ts
│   │   │
│   │   │   ├── product-create
│   │   │   │   ├── product-create.html
│   │   │   │   ├── product-create.scss
│   │   │   │   ├── product-create.ts
│   │   │
│   │   │   ├── product-edit
│   │   │   ├── product-details
│
│   │
│   │   ├── categories
│   │   │   ├── category-list
│   │   │   ├── category-create
│   │   │   ├── category-edit
│
│   │
│   │   ├── brands
│   │   │   ├── brand-list
│   │   │   ├── brand-create
│   │   │   ├── brand-edit
│
│   │
│   │   ├── customers
│   │   │   ├── customer-list
│   │   │   ├── customer-create
│   │   │   ├── customer-edit
│   │   │   ├── customer-details
│
│   │
│   │   ├── suppliers
│   │   │   ├── supplier-list
│   │   │   ├── supplier-create
│   │   │   ├── supplier-edit
│
│   │
│   │   ├── warehouses
│   │   │   ├── warehouse-list
│   │   │   ├── warehouse-create
│   │   │   ├── warehouse-edit
│
│   │
│   │   ├── inventory
│   │   │   ├── stock-list
│   │   │   ├── stock-adjustment
│   │   │   ├── stock-transfer
│   │   │   ├── inventory-transactions
│
│   │
│   │   ├── purchase-orders
│   │   │   ├── purchase-order-list
│   │   │   ├── purchase-order-create
│   │   │   ├── purchase-order-details
│   │   │   ├── receive-goods
│
│   │
│   │   ├── sales
│   │   │   ├── pos-screen
│   │   │   ├── cart
│   │   │   ├── payment
│   │   │   ├── invoice
│   │   │   ├── sales-history
│
│   │
│   │   ├── users
│   │   │   ├── user-list
│   │   │   ├── user-create
│   │   │   ├── user-edit
│   │   │   ├── assign-role
│
│   │
│   │   ├── roles
│   │   │   ├── role-list
│   │   │   ├── role-create
│
│   │
│   │   ├── reports
│   │   │   ├── sales-report
│   │   │   ├── inventory-report
│   │   │   ├── purchase-report
│   │   │   ├── profit-loss-report
│   │
│   │
│   │   ├── settings
│   │   │   ├── application-settings
│   │   │   ├── language-settings
│   │   │   ├── theme-settings
│   │
│   │
│   │   ├── audit-logs
│   │       ├── audit-log-list
│
│   ├── Layouts
│   │   ├── auth-layout
│   │   ├── main-layout
│   │   ├── header
│   │   ├── sidebar
│   │   ├── footer
│
│   ├── Shared
│   │   ├── components
│   │   │   ├── data-table
│   │   │   ├── confirm-dialog
│   │   │   ├── loader
│   │   │   ├── pagination
│   │   │   ├── search-box
│   │   │   ├── page-header
│   │   │   ├── no-data
│   │   │   ├── toast
│   │
│   │   ├── directives
│   │   ├── validators
│   │   ├── pipes
│
│   ├── Store (NgRx)
│   │   ├── actions
│   │   ├── reducers
│   │   ├── selectors
│   │   ├── effects
│   │   ├── models
│   │   ├── app.state.ts
│
│   ├── i18n
│   │   ├── en.json
│   │   ├── es.json
│   │   ├── fr.json
│
│   ├── app.routes.ts
│   ├── app.config.ts
│   ├── app.ts
│
└────────────────────────────────────────────

Backend
│
├── SmartPOS.API
│   ├── Controllers
│   │
│   ├── AuthController.cs
│   ├── UsersController.cs
│   ├── RolesController.cs
│   ├── ProductsController.cs
│   ├── ProductVariantsController.cs
│   ├── CategoriesController.cs
│   ├── BrandsController.cs
│   ├── UnitsController.cs
│   ├── SuppliersController.cs
│   ├── CustomersController.cs
│   ├── WarehousesController.cs
│   ├── StocksController.cs
│   ├── InventoryTransactionsController.cs
│   ├── PurchaseOrdersController.cs
│   ├── SalesController.cs
│   ├── ReportsController.cs
│   ├── AuditLogsController.cs
│   ├── SettingsController.cs
│
│
├── SmartPOS.Application
│
│   ├── Interfaces
│   │
│   ├── Repositories
│   │
│   │   ├── IAuthRepository.cs
│   │   ├── IUserRepository.cs
│   │   ├── IRoleRepository.cs
│   │   ├── IProductRepository.cs
│   │   ├── IProductVariantRepository.cs
│   │   ├── ICategoryRepository.cs
│   │   ├── IBrandRepository.cs
│   │   ├── IUnitRepository.cs
│   │   ├── ISupplierRepository.cs
│   │   ├── ICustomerRepository.cs
│   │   ├── IWarehouseRepository.cs
│   │   ├── IStockRepository.cs
│   │   ├── IInventoryTransactionRepository.cs
│   │   ├── IPurchaseOrderRepository.cs
│   │   ├── ISaleRepository.cs
│   │   ├── IPaymentRepository.cs
│   │   ├── IAuditLogRepository.cs
│   │   ├── IReportRepository.cs
│
│   │
│   ├── Services
│   │
│   │   ├── IAuthService.cs
│   │   ├── IUserService.cs
│   │   ├── IRoleService.cs
│   │   ├── IProductService.cs
│   │   ├── IProductVariantService.cs
│   │   ├── ICategoryService.cs
│   │   ├── IBrandService.cs
│   │   ├── IUnitService.cs
│   │   ├── ISupplierService.cs
│   │   ├── ICustomerService.cs
│   │   ├── IWarehouseService.cs
│   │   ├── IStockService.cs
│   │   ├── IInventoryTransactionService.cs
│   │   ├── IPurchaseOrderService.cs
│   │   ├── ISaleService.cs
│   │   ├── IPaymentService.cs
│   │   ├── IReportService.cs
│   │   ├── IAuditLogService.cs
│   │   ├── IEmailService.cs
│   │   ├── IJwtService.cs
│
│
│   ├── DTOs
│
│   │
│   ├── Auth
│   │   ├── LoginDto.cs
│   │   ├── LoginResponseDto.cs
│   │   ├── RefreshTokenDto.cs
│
│   │
│   ├── Users
│   │   ├── CreateUserDto.cs
│   │   ├── UpdateUserDto.cs
│   │   ├── UserDto.cs
│   │   ├── AssignRoleDto.cs
│
│   │
│   ├── Roles
│   │   ├── CreateRoleDto.cs
│   │   ├── RoleDto.cs
│
│   │
│   ├── Products
│   │   ├── CreateProductDto.cs
│   │   ├── UpdateProductDto.cs
│   │   ├── ProductDto.cs
│
│   │
│   ├── ProductVariants
│   │   ├── CreateProductVariantDto.cs
│   │   ├── UpdateProductVariantDto.cs
│   │   ├── ProductVariantDto.cs
│
│   │
│   ├── Categories
│   │   ├── CreateCategoryDto.cs
│   │   ├── UpdateCategoryDto.cs
│   │   ├── CategoryDto.cs
│
│   │
│   ├── Brands
│   │   ├── CreateBrandDto.cs
│   │   ├── UpdateBrandDto.cs
│   │   ├── BrandDto.cs
│
│   │
│   ├── Units
│   │   ├── CreateUnitDto.cs
│   │   ├── UpdateUnitDto.cs
│   │   ├── UnitDto.cs
│
│   │
│   ├── Customers
│   │   ├── CreateCustomerDto.cs
│   │   ├── UpdateCustomerDto.cs
│   │   ├── CustomerDto.cs
│
│   │
│   ├── Suppliers
│   │   ├── CreateSupplierDto.cs
│   │   ├── UpdateSupplierDto.cs
│   │   ├── SupplierDto.cs
│
│   │
│   ├── Warehouses
│   │   ├── CreateWarehouseDto.cs
│   │   ├── UpdateWarehouseDto.cs
│   │   ├── WarehouseDto.cs
│
│   │
│   ├── Stocks
│   │   ├── CreateStockDto.cs
│   │   ├── UpdateStockDto.cs
│   │   ├── StockDto.cs
│
│   │
│   ├── InventoryTransactions
│   │   ├── CreateInventoryTransactionDto.cs
│   │   ├── InventoryTransactionDto.cs
│
│   │
│   ├── PurchaseOrders
│   │   ├── CreatePurchaseOrderDto.cs
│   │   ├── UpdatePurchaseOrderDto.cs
│   │   ├── ReceivePurchaseOrderDto.cs
│   │   ├── PurchaseOrderDto.cs
│
│   │
│   ├── Sales
│   │   ├── CreateSaleDto.cs
│   │   ├── SaleDto.cs
│   │   ├── SaleItemDto.cs
│
│   │
│   ├── Payments
│   │   ├── CreatePaymentDto.cs
│   │   ├── PaymentDto.cs
│
│
│   ├── Mapping
│   │   ├── ProductProfile.cs
│   │   ├── CategoryProfile.cs
│   │   ├── BrandProfile.cs
│   │   ├── CustomerProfile.cs
│   │   ├── SupplierProfile.cs
│   │   ├── SaleProfile.cs
│
│
├── SmartPOS.Domain
│
│   ├── Entities
│   │
│   ├── User.cs
│   ├── Role.cs
│   ├── RefreshToken.cs
│
│   ├── Product.cs
│   ├── ProductVariant.cs
│   ├── Category.cs
│   ├── Brand.cs
│   ├── Unit.cs
│
│   ├── Customer.cs
│   ├── Supplier.cs
│
│   ├── Warehouse.cs
│   ├── Stock.cs
│   ├── InventoryTransaction.cs
│
│   ├── PurchaseOrder.cs
│   ├── PurchaseOrderItem.cs
│
│   ├── Sale.cs
│   ├── SaleItem.cs
│   ├── Payment.cs
│
│   ├── AuditLog.cs
│
│
├── SmartPOS.Infrastructure
│
│   ├── Data
│   │   ├── ApplicationDbContext.cs
│
│
│   ├── Repositories
│   │
│   ├── AuthRepository.cs
│   ├── UserRepository.cs
│   ├── RoleRepository.cs
│   ├── ProductRepository.cs
│   ├── ProductVariantRepository.cs
│   ├── CategoryRepository.cs
│   ├── BrandRepository.cs
│   ├── UnitRepository.cs
│   ├── SupplierRepository.cs
│   ├── CustomerRepository.cs
│   ├── WarehouseRepository.cs
│   ├── StockRepository.cs
│   ├── InventoryTransactionRepository.cs
│   ├── PurchaseOrderRepository.cs
│   ├── SaleRepository.cs
│   ├── PaymentRepository.cs
│   ├── AuditLogRepository.cs
│
│
│   ├── Services
│   │
│   ├── AuthService.cs
│   ├── UserService.cs
│   ├── RoleService.cs
│   ├── ProductService.cs
│   ├── ProductVariantService.cs
│   ├── CategoryService.cs
│   ├── BrandService.cs
│   ├── UnitService.cs
│   ├── SupplierService.cs
│   ├── CustomerService.cs
│   ├── WarehouseService.cs
│   ├── StockService.cs
│   ├── InventoryTransactionService.cs
│   ├── PurchaseOrderService.cs
│   ├── SaleService.cs
│   ├── PaymentService.cs
│   ├── ReportService.cs
│   ├── AuditLogService.cs
│   ├── EmailService.cs
│   ├── JwtService.cs
│
│
│   ├── Configurations
│   │
│   ├── ProductConfiguration.cs
│   ├── CategoryConfiguration.cs
│   ├── BrandConfiguration.cs
│   ├── CustomerConfiguration.cs
│   ├── SupplierConfiguration.cs
│   ├── WarehouseConfiguration.cs
│   ├── SaleConfiguration.cs
│
│
│   ├── DependencyInjection.cs
│
│
└── Tests
    ├── UnitTests
    ├── IntegrationTests


    ```