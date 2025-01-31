using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            function1(args);
            function2(args);
            function3 (args);
            function4 (args);   
        }

        static void function1(string[] args) 
        {
            string str1 = "SkillForge";
            string str2 = "SkillForge";
            string str3 = "skillforge";

            
            bool areEqual = str1 == str2; 
            bool areEqualCaseInsensitive = str2 == str3;
            bool areNotEqual = str1 != str3; 

            Console.WriteLine($"str1 == str2: {areEqual}");
            Console.WriteLine($"str1 == str3: {areNotEqual}");
            Console.WriteLine($"str2 == str3: {areEqualCaseInsensitive}");

            Console.ReadKey();
        }
        static void function2(string[] args)
        {
            string strA = "Hello";
            string strB = "World";
            string strC = "Programming is great!";

            
            string concatenated = string.Concat(strA, " ", strB);
            Console.WriteLine("Concatenated: " + concatenated);

            
            string copiedString = string.Copy(strA);
            Console.WriteLine("Copied: " + copiedString);

            
            string substring = strC.Substring(0, 11); 
            Console.WriteLine("Substring: " + substring);

            
            string[] words = strC.Split(' ');
            Console.WriteLine("Words: " + string.Join(", ", words));

            
            string insertedString = strA.Insert(5, " there");
            Console.WriteLine("Inserted: " + insertedString);

            
            string removedSubstring = strC.Remove(0, 11); 
            Console.WriteLine("Removed substring: " + removedSubstring);

            
            string interpolatedString = $"{strA}, {strB}! Welcome to {strC}.";
            Console.WriteLine("Interpolated: " + interpolatedString);


            Console.ReadKey();
        }
        static void function3(string[] args)
        {
            string emptyString = "";
            string nullString = null;

            
            bool isEmpty = string.IsNullOrEmpty(emptyString); 
            bool isNull = string.IsNullOrEmpty(nullString); 

            Console.WriteLine($"Is empty string null or empty: {isEmpty}");
            Console.WriteLine($"Is null string null or empty: {isNull}");

            
            if (string.IsNullOrEmpty(nullString))
            {
                nullString = "Default value";
            }

            string upperEmpty = emptyString.ToUpper(); 
            Console.WriteLine($"Upper case empty string: {upperEmpty}");

            Console.ReadKey();
        }


        static void function4(string[] args)
        {
            StringBuilder sb = new StringBuilder("Hello, world!");

            
            sb.Remove(5, 7);
            Console.WriteLine("After removal: " + sb.ToString());

            
            sb.Insert(0, "Welcome to ");
            sb.Append(" platform.");
            Console.WriteLine("After insertions: " + sb.ToString());

            Console.ReadKey();
        }

    }
}
