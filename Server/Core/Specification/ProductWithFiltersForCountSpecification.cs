using Core.Entities;

namespace Core.Specification
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParam)
             : base(x => (string.IsNullOrEmpty(productParam.Search) || x.Name.ToLower().Contains(productParam.Search)) &&
               (!productParam.BrandId.HasValue || x.ProductBrandId == productParam.BrandId) &&
               (!productParam.TypeId.HasValue || x.ProductTypeId == productParam.TypeId))
        {
        }
    }
}
