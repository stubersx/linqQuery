using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace linqQuery
{
    class famousPeople
    {
        public string Name { get; set; }
        public int? BirthYear { get; set; } = null;
        public int? DeathYear { get; set; } = null;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<famousPeople> stemPeople = new List<famousPeople>() {
                new famousPeople() { Name = "Michael Faraday", BirthYear = 1791, DeathYear = 1867 },
                new famousPeople() { Name = "James Clerk Maxwell", BirthYear = 1831, DeathYear = 1879 },
                new famousPeople() { Name = "Marie Skłodowska Curie", BirthYear = 1867, DeathYear = 1934 },
                new famousPeople() { Name = "Katherine Johnson", BirthYear = 1918, DeathYear = 2020 },
                new famousPeople() { Name = "Jane C. Wright", BirthYear = 1919, DeathYear = 2013 },
                new famousPeople() { Name = "Tu YouYou", BirthYear = 1930 },
                new famousPeople() { Name = "Françoise Barré-Sinoussi", BirthYear = 1947 },
                new famousPeople() { Name = "Lydia Villa-Komaroff", BirthYear = 1947 },
                new famousPeople() { Name = "Mae C. Jemison", BirthYear = 1956 },
                new famousPeople() { Name = "Stephen Hawking", BirthYear = 1942, DeathYear = 2018 },
                new famousPeople() { Name = "Tim Berners-Lee", BirthYear = 1955 },
                new famousPeople() { Name = "Terence Tao", BirthYear = 1975 },
                new famousPeople() { Name = "Florence Nightingale", BirthYear = 1820, DeathYear = 1910 },
                new famousPeople() { Name = "George Washington Carver", DeathYear = 1943 },
                new famousPeople() { Name = "Frances Allen", BirthYear = 1932, DeathYear = 2020 },
                new famousPeople() { Name = "Bill Gates", BirthYear = 1955 }
            };

            var birthdates = from b in stemPeople
                             where b.BirthYear > 1900
                             select b;
            Console.WriteLine("People with birthdates after 1900");
            foreach (famousPeople birth in birthdates)
            {
                Console.WriteLine($"Name: {birth.Name} - Birth Year: {birth.BirthYear}");
            }

            var twoLs = from l in stemPeople
                        where l.Name.Contains("ll")
                        select l;
            Console.WriteLine("\nPeople who have two lowercase L's in their name");
            foreach(famousPeople ls in twoLs)
            {
                Console.WriteLine($"Name: {ls.Name}");
            }

            var count = (from c in stemPeople
                         where c.BirthYear > 1950
                         select c).Count();
            Console.WriteLine($"\nNumber of people with birthdays after 1950: {count}");

            var birthyears = from byrs in stemPeople
                             where byrs.BirthYear >= 1920
                             where byrs.BirthYear <=2000
                             select byrs;
            var yrscount = birthyears.Count();
            Console.WriteLine("\nPeople with birth years between 1920 and 2000.");
            foreach(famousPeople yrs in birthyears)
            {
                Console.WriteLine($"Name: {yrs.Name}");
            }
            Console.WriteLine($"Number of people in the list: {yrscount}");

            var sortByYear = from s in stemPeople
                             orderby s.BirthYear
                             select s;
            Console.WriteLine("\nSort the list by BirthYear");
            foreach(famousPeople sb in sortByYear)
            {
                Console.WriteLine($"Birth Year: {sb.BirthYear}\tName: {sb.Name} - Death Year: {sb.DeathYear}");
            }

            var deathYear = from d in stemPeople
                            where d.DeathYear > 1960
                            where d.DeathYear < 2015
                            orderby d.Name
                            select d;
            Console.WriteLine("\nPeople with a death year after 1960 and before 2015.");
            foreach(famousPeople dy in deathYear)
            {
                Console.WriteLine($"Name: {dy.Name} - Death Year: {dy.DeathYear}");
            }
        }
    }
}
