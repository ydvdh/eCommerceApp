using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specification
{
    /* This class is concrete implementation of interface. 
     *  It defines Criteria and Includes as properties and an additional method for adding include expressions to the Includes collection.
     */
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
