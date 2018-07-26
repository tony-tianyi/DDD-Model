using CMS.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infrastructure
{
   public class Program
    {
       public static void Main(string[] args)
       {
           using (var db = new SchoolDbContext())
           {
               Console.Write("wangtianyi ");
               var name = Console.ReadLine();

               var type_Model = new Student { Name = name };
               db.student.Add(type_Model);
               db.SaveChanges();

               Console.WriteLine("查询名字:");
               var search_type = Console.ReadLine();
               var query = from b in db.student
                           where b.Name == search_type
                           select b;

               Console.WriteLine("查询结果:");
               foreach (var item in query)
               {
                   Console.WriteLine(item.Name);
               }

               Console.ReadKey();
           }
       }
    }
}
