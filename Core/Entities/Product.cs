namespace Core.Entities
{
    public class Product : BaseEntity
    {
     
      public string Name {get; set;}
      public string Description {get; set;}
      public decimal Price {get; set;}
       public string ImageUrl {get; set;}
       public ProductCategory ProductCategory {get; set;}
      public int ProductCategoryId {get; set;}

      public decimal AvailableQuantity {get; set;}
      
      public decimal Discount {get; set;}

      public string Specification {get; set;}

      
      

    } 
}