using System.Text.Json;
using Core.Entities;
using System.Collections.Generic;
using System.IO;


namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
       public static async Task SeedAsync(StoreContext context) 
       {
        if (!context.ProductCategory.Any())
        {
            var categoriesData= File.ReadAllText("../Infrastructure/Data/SeedData/productscategory.json");
            var categories =JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);

            context.ProductCategory.AddRange(categories);
        }
        if (!context.Products.Any())
        {
            var productsData= File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
            var products =JsonSerializer.Deserialize<List<Product>>(productsData);

            context.Products.AddRange(products);
            
        }

        if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
       
       }

    }
}