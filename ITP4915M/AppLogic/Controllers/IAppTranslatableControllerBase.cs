namespace ITP4915M.AppLogic.Controllers
{
    public interface IAppTranslatableControllerBase<T>
    {
        public Task<List<Dictionary<object, object>>> GetAll(string lang = "en");
        public Task<Dictionary<object, object>> GetById(string id,string lang = "en");

        public Task<List<Dictionary<object, object>>> GetByQueryString(string queryString,string lang = "en");
        public Task<string> Add(T entity,string lang = "en");
        public Task Modify(string id, List<AppLogic.Models.UpdateObjectModel> content,string lang = "en");

        public Task Delete(string id);
    }
}