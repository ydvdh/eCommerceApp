using Core.Entities;
using Core.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure
{
    /* SpecificationEvaluator<T> and the GetQuery method is used for applying the filtering and includes expressions to our query. 
     * If a criteria expression exists, it is applied with a 'Where', following by any Include expressions.
     * Note that the query is not actually executed at this point. 
     * To execute the query requires calling an EF core execution method such as .ToList()
     */
    public class SpecificationEvaluator<TEntity> where TEntity: BaseEntity 
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;
            if(specification.Criteria != null )
            {
                query = query.Where(specification.Criteria); // Where(p => p.ProductTypeId == id)
            }

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy); 
            }
            if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending); 
            }
            if(specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
