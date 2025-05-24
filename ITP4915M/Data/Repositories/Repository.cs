using MySqlConnector;
using ITP4915M.AppLogic.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ITP4915M.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
{
    protected readonly DataContext DbContext;
    public DbSet<TEntity> Entities { get; set; }
    
    protected Repository(){}
    public Repository(DataContext dbContext)
    {
        DbContext = dbContext;
        Entities = dbContext.Set<TEntity>();
    }
    

    public async Task<TEntity?> GetByIdAsync(params object[] ids)
    {
        return await Entities
                    .FindAsync(ids);
    }

    public async Task<List<TEntity>> GetBySQLAsync(string sql)
    {
        return await Entities.FromSqlRaw(sql).ToListAsync();
    }

    public async Task<bool> AddAsync(TEntity entity, bool saveNow = true)
    {
        if (!Helpers.Entity.EntityValidator.Validate<TEntity>(entity))
            return false;
        
        try
        {
            Entities.Add(entity);
            if (saveNow)
                await DbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            ConsoleLogger.Debug(e.InnerException);
            if (e.InnerException.ToString().Contains("Duplicate entry"))
                throw new BadArgException("The entity already exists.");
            else
                throw new BadArgException("The entity is not valid. (no related foreign entity)");
        }

    }

    public async Task AddRangeAsync(List<TEntity> entities , bool saveNow = true)
    {
        foreach (var entity in entities)
        {
            if (!Helpers.Entity.EntityValidator.Validate<TEntity>(entity))
                throw new BadArgException($"The entity is not valid. ({entity.GetType().GetProperties().Where(p => p.Name.ToLower() == "id").First().GetValue(entity)})");
        }

        await Entities.AddRangeAsync(entities);
        await DbContext.SaveChangesAsync();
    }
    

    public async Task<bool> UpdateAsync(TEntity entity, bool saveNow = true)
    {
        try
        {
            Entities.Update(entity);
            if (saveNow)
                await DbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw new OperationFailException("Error");
        }
    }

    public async Task DeleteAsync(TEntity entity, bool saveNow = true)
    {
        try
        {
            Entities.Remove(entity);
            if (saveNow)
                await DbContext.SaveChangesAsync();
        }catch(Exception e)
        {
            throw new OperationFailException($"Delete {entity} failed!");
        }
    }

    public async Task<bool> IsRecordExistAsync(string id)
    {
        return (await Entities.FindAsync(id)) is null;
    }

    public TEntity GetById(params object[] ids)
    {
        return Entities.Find(ids);
    }

    public List<TEntity> GetBySQL(string sql)
    {
        return Entities.FromSqlRaw(sql).ToList();
    }

    public bool Add(TEntity entity, bool saveNow = true)
    {
        if (!Helpers.Entity.EntityValidator.Validate<TEntity>(entity))
        {
            ConsoleLogger.Debug(entity.Debug());
            throw new BadArgException("The entity is not valid.");
        }
        Entities.Add(entity);
        if (saveNow)
            DbContext.SaveChanges();
        return true;
    }

    public bool Update(in TEntity entity, bool saveNow = true)
    {
        try
        {
            Entities.Update(entity);
            if (saveNow)
                DbContext.SaveChanges();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw new OperationFailException("Error");
        }
    }

    public void Delete(TEntity entity, bool saveNow = true)
    {
        try
        {
            Entities.Remove(entity);
            if (saveNow)
                DbContext.SaveChanges();
        }catch(Exception e)
        {
            throw new OperationFailException($"Delete {entity} failed!");
        }
    }

    public bool IsRecordExist(string id)
    {
        return ! (Entities.Find(id) is null);
    }

    public List<TEntity> GetAll()
    {
        return Entities.ToList();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await Entities.ToListAsync();
    }

    public void Dispose()
    {
        
    }
}