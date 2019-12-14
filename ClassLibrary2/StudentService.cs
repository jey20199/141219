using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentService
    {
        private string path = "student.db";
        public IEnumerable<Student> Students { get; set; }
        public void Add(Student st)
        {
            (Students as List<Student>).Add(st);
            //  Save();
        }

        public void Remove(string LastName)
        {
            List<Student> temp = Students as List<Student>;
            temp.Remove(temp.Find(st => st.LastName.Equals(LastName)));
        }
        public StudentService()
        {
            if (!File.Exists(path))
                Students = new List<Student>();
            else
            {
                Load();
            }

        }

        private void Load()
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Students = (List<Student>)bf.Deserialize(fs);
            }
        }

        public void Save()
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, Students);
            }
        }
    }
}

