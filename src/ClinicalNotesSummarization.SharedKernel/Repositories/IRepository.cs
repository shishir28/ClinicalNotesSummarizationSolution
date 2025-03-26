﻿using ClinicalNotesSummarization.SharedKernel.Entities;

namespace ClinicalNotesSummarization.SharedKernel.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
