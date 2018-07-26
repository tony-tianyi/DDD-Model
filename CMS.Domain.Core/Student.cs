using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Core
{
    public class Student : IAggregateRoot
    {
       public Student()
       { }
      
       public int Id { get; set; }
       public string Name { get; set; }
       public string Age { get; set; }
    }

    
}
