using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Lab11
{
    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    class Phone
    {
        public string Name { get; set; }
        public string Company { get; set; }
    }
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] month = new string[12] {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December",
            };
            Console.WriteLine($"Введите длину месяца");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Месяцы, длина линии которых равна {n}:");
            IEnumerable m1 = from m in month
                                where m.Length == n
                                select m;
            foreach (string m in m1)
            {
                Console.Write($"{m} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Сортировка по названию месяца:");
            IEnumerable m2 = from m in month
                                orderby m
                                select m;
            foreach (string m in m2)
            {
                Console.Write($"{m} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Зимние и летние месяцы:");
            IEnumerable m3 = from m in month
                                where m.Equals("December") || m.Equals("January") || m.Equals("February")
                                || m.Equals("June") || m.Equals("July") || m.Equals("August")
                                select m;
            foreach (string m in m3)
            {
                Console.Write($"{m} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Месяцы, длина линии которых не менее 4 и содержащие букву u:");
            IEnumerable m4 = from m in month
                                where m.Length >= 4 && m.Contains("u")
                                orderby m
                                select m;
            foreach (string m in m4)
            {
                Console.Write($"{m} ");
            }
            Console.WriteLine();

            Student student1 = new Student("Grisha", "Bulgak", "09012002", "Home", 4455, "FIT", 2, 10);
            Student student2 = new Student("Yaroslav", "Migun", "29012007", "Home", 498, "LH", 1, 11, "VL");
            Student student3 = new Student("Daniil", "Radkevich", "20102004", "Home", 765, "IEF", 2, 4, "EP");
            Student student4 = new Student("Vlad", "Gil", "05072000", "Home", 4511, "FIT", 2, 10);
            Student student5 = new Student("Alex", "Taranovich", "06022010", "Home", 7699, "EF", 4, 7, "ES");
            Student student6 = new Student("Max", "Kravchenko", "01032001", "Home", 982, "LF", 2, 3, "PF");
            Student student7 = new Student("Stefan", "Shmat", "04042005", "Home", 6822, "CF", 2, 9, "P");
            Student student8 = new Student("Ilya", "Shereshik", "27082006", "Home", 7321, "FIT", 2, 11, "DEIVI");
            Student student9 = new Student("Vlad", "Babyor", "05072003", "Dormitory", 6532, "TF", 1, 5, "TH");
            List<Student> students = new List<Student>();
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            students.Add(student4);
            students.Add(student5);
            students.Add(student6);
            students.Add(student7);
            students.Add(student8);
            students.Add(student9);
            Console.WriteLine($"Введите специальность: ");
            string spec = Convert.ToString(Console.ReadLine());
            IEnumerable listofst1 = from st in students
                                    where st.Specialization == spec
                                    orderby st.Surname
                                    select st;
            Console.WriteLine($"Список студентов");
            foreach (Student el in listofst1)
            {
                Console.WriteLine($"{el.Surname} {el.Name}");
            }
            Console.WriteLine($"Введите факультет: ");
            string fac = Convert.ToString(Console.ReadLine());
            Console.WriteLine($"Введите группу: ");
            int gr = Convert.ToInt32(Console.ReadLine());
            IEnumerable listofst2 = from st in students
                                    where st.Faculty == fac && st.Group == gr
                                    select st;
            Console.WriteLine($"Список студентов");
            foreach (Student el in listofst2)
            {
                Console.WriteLine($"{el.Surname} {el.Name}");
            }
            Student young = students.OrderBy(st => st.Age()).First();
            Console.WriteLine($"Самый молодой студент");
            Console.WriteLine($"{young.Surname} {young.Name}");
            Console.WriteLine($"Введите группу: ");
            int gr1 = Convert.ToInt32(Console.ReadLine());
            IEnumerable listofst3 = from st in students
                                    where st.Group == gr1
                                    orderby st.Surname
                                    select st;
            int count = 0;
            foreach (Student el in listofst3)
            {
                count++;
            }
            Console.WriteLine($"Количество  студентов заданной группы упорядоченных по фамилии: {count}");
            Console.WriteLine($"Введите имя: ");
            string name = Convert.ToString(Console.ReadLine());
            Student firstst = students.OrderBy(st => st.Surname).Where(u => u.Name == name).First();
            Console.WriteLine($"Студент {firstst.Surname} {firstst.Name}");

            List<Phone> phones = new List<Phone>
            {
                new Phone {Name="Lumia 430", Company="Microsoft" },
                new Phone {Name="Mi 5", Company="Xiaomi" },
                new Phone {Name="LG G 3", Company="LG" },
                new Phone {Name="iPhone 5", Company="Apple" },
                new Phone {Name="Lumia 930", Company="Microsoft" },
                new Phone {Name="iPhone 6", Company="Apple" },
                new Phone {Name="Lumia 630", Company="Microsoft" },
                new Phone {Name="LG G 4", Company="LG" }
            };

            var phoneGroups = (from phone in phones
                               where phone.Name.Length > 5
                               orderby phone.Name
                               group phone by phone.Company);

            var countPhonesInFirstGroup = (
                              from phone in phones
                              where phone.Name.Length > 5
                              orderby phone.Name
                              group phone by phone.Company).First().Count();
            Console.WriteLine($"В первой группе: {countPhonesInFirstGroup} телефонов");
            foreach (IGrouping<string, Phone> g in phoneGroups)
            {
                Console.WriteLine($"{g.Key}: ");
                foreach (var t in g)
                    Console.WriteLine(t.Name);
                Console.WriteLine();
            }
            string[] cars = { "Nissan", "Aston Martin", "Chevrolet", "Alfa Romeo", "Chrysler", "Dodge", "BMW",
            "Ferrari", "Audi", "Bentley", "Ford", "Lexus", "Mercedes", "Toyota", "Volvo", "Subaru", "Жигули :)"};

            IEnumerable<string> auto = cars.Take(5);

            foreach (string str in auto)
                Console.WriteLine(str);
            Console.WriteLine();

            List<User> users = new List<User>()
            {
                new User { Name = "Tom", Age = 23 },
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Bill", Age = 35 }
            };

            bool result1 = users.All(u => u.Age > 20); 
            if (result1)
                Console.WriteLine("У всех пользователей возраст больше 20");
            else
                Console.WriteLine("Есть пользователи с возрастом меньше 20");

            List<Team> teams = new List<Team>()
            {
                new Team { Name = "Бавария", Country ="Германия" },
                new Team { Name = "Барселона", Country ="Испания" }
            };
            List<Player> players = new List<Player>()
            {
                new Player {Name="Месси", Team="Барселона"},
                new Player {Name="Неймар", Team="Барселона"},
                new Player {Name="Роббен", Team="Бавария"}
            };

            var result = from pl in players
                         join t in teams on pl.Team equals t.Name
                         select new { Name = pl.Name, Team = pl.Team, Country = t.Country };

            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");

        }
    }
}
