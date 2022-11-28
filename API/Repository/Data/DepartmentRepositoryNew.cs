using API.Context;
using API.Models;

namespace API.Repository.Data
{
    public class DepartmentRepositoryNew : GenerralRepository<Department,string>
    {
        private MyContext context;
        public DepartmentRepositoryNew (MyContext myContext) :base(myContext)
        {
            context = myContext;
        }


    }
}
