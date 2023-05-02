﻿
using Alba;
using ProductsApi.Products;

namespace ProductsApi.IntegrationTests.Products;

public class AddingProducts
{
    [Fact]
    public async Task TacoSalad()
    {
        await using var host = await AlbaHost.For<Program>();

        var request = new CreateProductRequest
        {
            Name ="Super Deluxe Dandruff Shampoo",
            Cost = 120.88M,
            Supplier = new SupplierInformation
            {
                Id = "bobs-shop",
                SKU  = "19891"
            }
        };

        var expectedResponse = new CreateProductResponse
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
        var response = await host.Scenario(api =>
        {
            api.Post.Json(request).ToUrl("/products");
            api.StatusCodeShouldBe(201);
        });

        var actualResponse = response.ReadAsJson<CreateProductResponse>();
        Assert.NotNull(actualResponse);

        Assert.Equal(expectedResponse, actualResponse);
    }
}
