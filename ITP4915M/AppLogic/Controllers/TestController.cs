using ITP4915M.Data;

namespace ITP4915M.AppLogic.Controllers;

public class TestController
{
    private readonly DataContext _dataContext;

    public TestController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    //public List<Acc> GetSth()
    //      {
    //	return _dataContext.Accs.ToList();
    //      }

    //public void CreateSth(Acc acc)
    //      {
    //	var entity = _dataContext.Accs.FirstOrDefault(o => o.Id == acc.Id);
    //	if (entity is not null) throw new DuplicateEntryException("Entity exist");
    //	_dataContext.Accs.Add(acc);
    //	_dataContext.SaveChanges();


    //	// return await _dataContext.Accs.ToListAsync();
    //      }
}