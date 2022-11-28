using API.Context;
using API.Models;

using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace API.Repository.Data
{
    public class DivisionRepositories : IDivisionRepositories <Division, int>
    {
        private MyContext context;

        public DivisionRepositories(MyContext myContext)
        {
            context = myContext;
        }

        //Get All
        public IEnumerable <Division> Get()
        {
            return context.Divisions.ToList();
        }

        //Get By Id
        public Division Get(int id)
        {
            return context.Divisions.Find(id);
        }

        //Create

        public int Create(Division division)
        {
            context.Divisions.Add(division);
            var result = context.SaveChanges();
            return result;
        }

        //Update
        public int Update(Division division)
        {
            context.Entry(division).State = EntityState.Modified;
            var result = context.SaveChanges();
            return result;
        }

        //Delete
        public int Delete(int id)
        {
            var data = context.Divisions.Find(id);
            if (data != null)
            {
                context.Remove(data);
                var result = context.SaveChanges();
                return result;
            }
            return 0;
        }

        
    }
}
