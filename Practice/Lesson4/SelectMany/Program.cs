using LINQTut04.Shared;

namespace SelectMany
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // RunExample01();
            RunExample02();
        }

        private static void RunExample01()
        {
            string[] sentences = {
                "I love asp.net core",
                "I like sql server also",
                "in general i love programming"
            };

            var words = sentences.SelectMany(x => x.Split(' '));

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }



        private static void RunExample02()
        {
            var employees = Repository.LoadEmployees();

            var skills = employees.SelectMany(x => x.Skills).Distinct();

            foreach (var skill in skills)
            {
                Console.WriteLine(skill);
            }



            //Using query syntax
            var skillsUsingQuery = (from emp in employees
                                    from skill in emp.Skills
                                    select skill).Distinct();

            Console.WriteLine("\n\n");
            foreach (var skill in skillsUsingQuery)
            {
                Console.WriteLine(skill);
            }




        }



      

    }
}
