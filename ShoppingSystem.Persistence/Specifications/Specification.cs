﻿using ShoppingSystem.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Persistence.Specifications
{
    public abstract class Specification<TEntity>
     where TEntity : BaseEntity
    {
        protected Specification(Expression<Func<TEntity, bool>>? criteria) =>
            Criteria = criteria;

        public bool IsSplitQuery { get; protected set; }

        public Expression<Func<TEntity, bool>>? Criteria { get; }

        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new();

        public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }

        public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression) =>
            IncludeExpressions.Add(includeExpression);

        protected void AddOrderBy(
            Expression<Func<TEntity, object>> orderByExpression) =>
            OrderByExpression = orderByExpression;

        protected void AddOrderByDescending(
            Expression<Func<TEntity, object>> orderByDescendingExpression) =>
            OrderByDescendingExpression = orderByDescendingExpression;
    }
}
