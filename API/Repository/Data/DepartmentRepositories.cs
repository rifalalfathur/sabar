using API.Context;
using API.Models;

using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Data
{
    public class DepartmentRepositories : IDepartmentRepositories <Department, int>
    {
        private MyContext context;

        public DepartmentRepositories(MyContext myContext)
        {
            context = myContext;
        }

        //Get All
        public IEnumerable<Department> Get()
        {
            return context.Departments.ToList();
        }

        //Get By Id
        public Department Get(int id)
        {
            return context.Departments.Find(id);
        }

        //Create

        public int Create(Department department)
        {
            context.Departments.Add(department);
            var result = context.SaveChanges();
            return result;
        }

        //Update
        public int Update(Department department)
        {
            context.Entry(department).State = EntityState.Modified;
            var result = context.SaveChanges();
            return result;
        }

        //Delete
        public int Delete(int id)
        {
            var data = context.Departments.Find(id);
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
