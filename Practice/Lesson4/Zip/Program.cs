
using LINQTut04.Shared;
using System.Runtime.CompilerServices;

namespace Zip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RunExample01();
            RunExample02();
        }

        private static void RunExample01()
        {
            string[] colorName = { "Red", "Green", "Blue", "extraColor" };
            string[] colorHEX = { "FF0000", "00FF00", "0000FF" };

            var colorNameWithHex = colorName.Zip(colorHEX, (name, hex) => $"{name} ({hex})");

            foreach (var color in colorNameWithHex)
            {
                Console.WriteLine(color);
            }

        }
        private static void RunExample02()
        {
            var employees = Repository.LoadEmployees().ToArray();

            var firstThreeEmps = employees[..3]; 
            var lastThreeEmps = employees[^3..];

            var teams = firstThreeEmps.Zip(lastThreeEmps, (first, last) =>
            $"{first.FullName} with {last.FullName}");


            foreach (var team in teams)
            {
                Console.WriteLine(team);
            }


            //Using query syntax
            var teamsQuerySyntax = from team in firstThreeEmps.Zip(lastThreeEmps)
                                   select $"{team.First.FullName} with {team.Second.FullName}";

            Console.WriteLine("\n\n");
            foreach (var team in teamsQuerySyntax)
            {
                Console.WriteLine(team);
            }


        }
    }
}
