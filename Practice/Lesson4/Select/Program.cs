using LINQTut04.Shared;
using System.Security.Cryptography.X509Certificates;

namespace Select
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RunExample01();
            //RunExample02();
            //RunExample02UsingQuerySyntax();
            RunExample03();
        }

        private static void RunExample01()
        {
            List<string> words = new() { "i", "love", "asp.net", "core" };

            var firstLetters = words.Select(x => x[0]);

            foreach (var word in firstLetters)
            {
                Console.WriteLine(word);
            }
        }

        private static void RunExample02()
        {
            List<string> words = new() { "i", "love", "asp.net", "core" };

            var words2 = words.Select(x => x.ToUpperInvariant());

            foreach (var word in words2)
            {
                Console.WriteLine(word);
            }
        }


        private static void RunExample02UsingQuerySyntax()
        {
            List<string> words = new() { "i", "love", "asp.net", "core" };

            var words2 = from word in words
                         select word.ToUpper();

            foreach (var word in words2)
            {
                Console.WriteLine(word);
            }
        }




        private static void RunExample03()
        {
            var employees = Repository.LoadEmployees();

            IEnumerable<EmployeeDto> dtos = employees.Select(x =>
            new EmployeeDto
            {
                Name = $"{x.FirstName} {x.LastName}",
                TotalSkills = x.Skills.Count
            });

            // Using query syntax
            var dtosUsingQuerySyntax = from employee in employees
                                       select new EmployeeDto
                                       {
                                           Name = $"{employee.FirstName} {employee.LastName}",
                                           TotalSkills = employee.Skills.Count
                                       };




            foreach (var d in dtos)
                Console.WriteLine(d);
        }



    }
}
