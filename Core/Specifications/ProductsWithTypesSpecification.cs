using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesSpecification : BaseSpecification<Product>

    {
        private int id;

        public ProductsWithTypesSpecification(ProductSpecParams productParams)
        : base(x =>
        (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains
        (productParams.Search)) &&
                 (!productParams.categoryId.HasValue || x.ProductCategoryId == productParams.categoryId))
        
       {
        AddInclude(x=>x.ProductCategory);
        AddOrderBy(x => x.Name);
        ApplyPaging(productParams.PageSize * (productParams.PageIndex -1),
        productParams.PageSize);
        if (!string.IsNullOrEmpty(productParams.Sort))

        {
            switch (productParams.Sort)
            {
                case "priceAsc":
                AddOrderBy(p => p.Price);
                break;
                case "priceDesc": 
                AddOrderByDescending (p => p.Price); 
                break;
                default:
                AddOrderBy(n =>n.Name);
                break;


            }
        } 
       }

        public ProductsWithTypesSpecification(int id)
        {
            this.id = id;
        }
    }           

}  

    







