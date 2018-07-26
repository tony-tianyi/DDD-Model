using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Core
{
    public class Grade : IAggregateRoot
    {
        public Grade()
        { }

        public int Id { get; set; }
        public string GradeName { get; set; }
        public string Seat { get; set; }
    }
}
