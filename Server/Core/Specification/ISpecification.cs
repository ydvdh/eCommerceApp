using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specification
{
    /* It include Criteria expression and a collection of Include expressions.
     * Criteria is used for storing and filtering expression
     * Includes is for storing expressions that determine what data we want to include in the query.
     * Expressions are nothing more than filter criteria which are pass into LINQ methods, e.g. Where(p => p.Description == "Test")
     */
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> Criteria { get; }

        List<Expression<Func<T, object>>> Includes { get; }

        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, object>> OrderByDescending { get; }
    }
}
