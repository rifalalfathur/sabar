using API.Context;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Repository
{
    public class GenerralRepository<Entity,Key> : IRepository<Entity,int> 
        where Entity : class
    {
        MyContext context;
        public GenerralRepository(MyContext _context)
        {
            this.context = _context;
        }


        public Entity Get(int Id)
        {
            return context.Set<Entity>().Find(Id);
            try
            {
                var data = context.Set<Entity>().Find(Id);
                if (data != null)
                {
                    return data;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public int Create (Entity entity)
        {
            
            try
            {
                context.Set<Entity>().Add(entity);
                var result = context.SaveChanges();
                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public int Update(Entity entity)
        {
            
            try
            {
                context.Set<Entity>().Update(entity);
                var result = context.SaveChanges();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        
        public int Delete(int id)
        {
            
            try
            {
                var data = Get(id);
                context.Set<Entity>().Remove(data);
                var result = context.SaveChanges();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ICollection<Entity> Get()
        {
            
            try
            {
                return context.Set<Entity>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
