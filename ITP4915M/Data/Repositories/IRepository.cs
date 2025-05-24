namespace ITP4915M.Data.Repositories;

public interface IRepository<TEntity>
{
    abstract Task<List<TEntity>> GetAllAsync();
    abstract Task<TEntity?> GetByIdAsync(params object[] ids);
    abstract Task<List<TEntity>> GetBySQLAsync(string sql);
    abstract Task<bool> AddAsync(TEntity entity, bool saveNow = true);
    abstract Task AddRangeAsync(List<TEntity> entities, bool saveNow = true);
    abstract Task<bool> UpdateAsync(TEntity entity, bool saveNow = true);
    abstract Task DeleteAsync(TEntity entity, bool saveNow = true);
    abstract Task<bool> IsRecordExistAsync(string id);


    abstract List<TEntity> GetAll();

    abstract TEntity GetById(params object[] ids);
    abstract List<TEntity> GetBySQL(string sql);

    abstract bool Add(TEntity entity, bool saveNow = true);
    abstract bool Update(in TEntity entity, bool saveNow = true);
    abstract void Delete(TEntity entity, bool saveNow = true);
    abstract bool IsRecordExist(string id);

    abstract void Dispose();
}