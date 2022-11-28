using MCC71.Models;
using MCC71.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC71.Repositories.Interface
{
    public interface IDivisionRepository
    {
        public List<Division> Get();
        public int Get(int Id);

        public int Insert(Division division);
        public int Update(Division division);
        public int Delete(int Id);
    }
}
