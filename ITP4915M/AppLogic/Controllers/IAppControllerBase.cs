using System.Collections.Generic;

namespace ITP4915M.AppLogic.Controllers
{
    public interface IAppControllerBase<T>
    {
        public Task<List<string>> Index();
        public Task<List<Dictionary<object, object>>> GetAll();
        public Task<Dictionary<object, object>> GetById(string id);

        public Task<List<Dictionary<object, object>>> GetByQueryString(string queryString);
        public Task Add(T entity);
        public Task Modify(string id, List<AppLogic.Models.UpdateObjectModel> content);

        public Task Delete(string id);

    }
}