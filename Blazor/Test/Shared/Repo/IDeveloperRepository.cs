using Test.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared.Repo
{
    public interface IDeveloperRepository
    {
        public Task<List<Developer>> GetAll();
        public Task<Developer?> GetById(int id);
        public Task<Developer?> Insert(Developer developer);
        public Task<Developer> Update(Developer developer);
        public Task<Developer?> Remove(int id);
    }
}
