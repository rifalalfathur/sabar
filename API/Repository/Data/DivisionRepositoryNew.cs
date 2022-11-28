using API.Context;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Repository.Data
{
    public class DivisionRepositoryNew : GenerralRepository<Division, string>
    {
         private MyContext context;

        public DivisionRepositoryNew (MyContext myContext) : base (myContext)
        {
            context = myContext;
        }
        [HttpGet("{Name}")]
        public Division Get(string Name)
        {
            return context.Divisions.Find(Name);
        }
    }
}
