﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podium.Data.Abstractions
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetAsync(object id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(object id);
    }
}