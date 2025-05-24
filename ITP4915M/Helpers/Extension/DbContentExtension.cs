using Microsoft.EntityFrameworkCore;

namespace ITP4915M.Helpers.Extension
{
    public static class DbContextExtension
    {

        /**
        * <summary>Load all foreign key data from database</summary>
        * <remarks>ICollection type is not able to load. Lazy loading is enable, therefore it is not recommend to use this function</remarks>
        */
        public static void LoadRelatedEntity(this DbContext db, object entity)
        {
            if (entity is null)
                return;
            // load all foreign key data from database
            foreach (var item in entity.GetType().GetProperties())
            {

                // if (item.PropertyType == typeof(List<>))
                // {
                //     db.Entry(entity).Collection(item.Name).Load();
                // }
                if (item.PropertyType.IsClass && item.PropertyType != typeof(string))
                {
                    ConsoleLogger.Debug($"{item.Name} is a class");
                    db.Entry(entity).Reference(item.Name).Load();
                    LoadRelatedEntity(db, item.GetValue(entity));
                }
            }

        }

    }
}