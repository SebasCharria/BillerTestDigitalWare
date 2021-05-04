using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Domain
{
    /// <summary>
    /// Representa un repostiory EF
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public partial interface IEfRepository<TEntity> : IRepository<TEntity>
        where TEntity : IAggregateRoot
    {

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<TEntity> TableNoTracking { get; }

    }
}
