using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaj9wpf
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime Enlisting { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }

    public class StudentView
    {
        public StudentList List { get; set; }

        public StudentView()
        {
            List = new StudentList()
            {
                students = new ObservableCollection<Student>()
                {
                    new Student
                    {
                        Id=1,
                        Name="Patryk",
                        LastName="Kwiecinski",
                        Enlisting=new DateTime(2000,1,3)
                    },
                    new Student
                    {
                        Id=1,
                        Name="Pjoter",
                        LastName="Kowalski",
                        Enlisting=new DateTime(2003,10,12)
                    },
                    new Student
                    {
                        Id=1,
                        Name="Brajanusz",
                        LastName="Cyżycki",
                        Enlisting=new DateTime(2002,2,10)
                    }

                }
            };
        }
    }
    public class StudentList
    {
        public ObservableCollection<Student> students { get; set; }
    }
}
