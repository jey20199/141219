using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace StudentConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            StudentService StudentService = new StudentService();
            StudentService.Add(new Student
            {
                Name = "Ivan",
                LastName = "Ivanov",
                Age = 20
            }
                );

            StudentService.Add(new Student
            {
                Name = "Petro",
                LastName = "Ivanov",
                Age = 20
            }
                   );

            Random rnd = new Random();
            foreach (Student item in StudentService.Students)
            {
                item.AddMark("C++", rnd.Next(1, 12));
                item.AddMark("C#", rnd.Next(1, 12));
            }
            foreach (Student item in StudentService.Students)
            {
                Console.WriteLine(item);
            }
            StudentService.Save();
        }
    }
}
