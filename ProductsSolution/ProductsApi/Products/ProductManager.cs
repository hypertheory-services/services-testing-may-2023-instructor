namespace ProductsApi.Products;

public class ProductManager : IManageTheProductCatalog
{
    public async Task<CreateProductResponse> AddProductAsync(CreateProductRequest request)
    {
        var response = new CreateProductResponse
        {
            Slug = "super-deluxe-dandruff-shampoo",
            Pricing = new ProductPricingInformation
            {
                Retail = 42.23M,
                Wholesale = new ProductPricingWholeInformation
                {
                    Wholesale = 40.23M,
                    MinimumPurchaseRequired = 10

                }
            }

        };
        return response;
    }
}
