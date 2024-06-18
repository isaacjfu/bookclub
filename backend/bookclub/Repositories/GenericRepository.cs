using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bookclub.Models;
using Bookclub.Interfaces;
using Bookclub.Data;

namespace Bookclub.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T: class
{
    protected readonly DataContext _context;

    public GenericRepository(DataContext  context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {

        return await _context.Set<T>().ToListAsync();
    }
    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}