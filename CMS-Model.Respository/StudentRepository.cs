using CMS.Domain.Core;
using CMS.Domain.Core.Respository;
using CMS.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Model.Respository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(IDbContext dbContext)
            : base(dbContext)
        { }

        public IQueryable<Student> GetByName(string name)
        {
            return _entities.Where(x => x.Name == name);
        }
    }
}
