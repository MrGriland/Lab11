using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{
    class Student
    {
        static int numOfStudents;
        public readonly int id;
        string name;
        string surname;
        string dateOfBirth;
        string address;
        int phone;
        string faculty;
        string specialization;
        int course;
        int group;
        public int age;
        static public int NumOfStudents
        {
            get
            {
                return numOfStudents;
            }
            set
            {
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Пустое имя недопустимо");
                }
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Пустая фамилия недопустима");
                }
                surname = value;
            }
        }
        public string DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Пустая дата рождения недопустима");
                }
                dateOfBirth = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Пустой адрес недопустим");
                }
                address = value;
            }
        }
        public int Phone
        {
            get
            {
                return phone;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentNullException("Пустой или отрицательный номер телефона недопустим");
                }
                phone = value;
            }
        }
        public string Faculty
        {
            get
            {
                return faculty;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Пустое название факультета недопустимо");
                }
                faculty = value;
            }
        }
        public string Specialization
        {
            get
            {
                return specialization;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Пустое название специальности недопустимо");
                }
                specialization = value;
            }
        }
        public int Course
        {
            get
            {
                return course;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentNullException("Пустой или отрицательный номер курса недопустим");
                }
                course = value;
            }
        }
        public int Group
        {
            get
            {
                return group;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentNullException("Пустой или отрицательный номер группы недопустим");
                }
                group = value;
            }
        }
        static Student()
        {
            Console.WriteLine("Статический конструктор выполнился");
        }
        public Student()
        {
            numOfStudents++;
            Console.WriteLine("Введите имя:");
            Name = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            Surname = Console.ReadLine();
            Console.WriteLine("Введите дату рождения");
            DateOfBirth = Console.ReadLine();
            Console.WriteLine("Введите адрес:");
            Address = Console.ReadLine();
            Console.WriteLine("Введите номер телефона:");
            Phone = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите название факультета:");
            Faculty = Console.ReadLine();
            Console.WriteLine("Введите название специльности:");
            Specialization = Console.ReadLine();
            Console.WriteLine("Введите номер курса:");
            Course = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите номер группы:");
            Group = Convert.ToInt32(Console.ReadLine());
            id = Phone + Course + Group;
            if (id < 1)
            {
                throw new ArgumentNullException("Пустой или отрицательный идентификатор недопустим");
            }
        }
        public Student(string nameparam = "Default", string surnameparam = "Default", string dateOfBirthparam = "01012020", string addressparam = "Dormitory", int phoneparam = 1, string facultyparam = "FIT", int courseparam = 2, int groupparam = 10, string spec = "POIBMS")
        {
            numOfStudents++;
            Name = nameparam;
            Surname = surnameparam;
            DateOfBirth = dateOfBirthparam;
            Address = addressparam;
            Phone = phoneparam;
            Faculty = facultyparam;
            Course = courseparam;
            Group = groupparam;
            Specialization = spec;
            id = Phone + Course + Group;
            if (id < 1)
            {
                throw new ArgumentNullException("Пустой или отрицательный идентификатор недопустим");
            }
        }
        public int Age()
        {
            int year = Convert.ToInt32(DateOfBirth.Substring(4, 4));
            int month = Convert.ToInt32(DateOfBirth.Substring(2, 2));
            int date = Convert.ToInt32(DateOfBirth.Substring(0, 2));
            DateTime bDay = new DateTime(year, month, date);
            DateTime now = DateTime.Today;
            int age = now.Year - bDay.Year;
            if (bDay > now.AddYears(-age))
                age--;
            return age;
        }
    }
}
