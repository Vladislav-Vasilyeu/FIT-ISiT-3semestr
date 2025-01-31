using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml;
using System.IO;

namespace project
{
    public class Reflector
    {
        public static string GetAssemblyName(string className)
        {
            var type = Type.GetType(className);
            if (type == null) throw new ArgumentException($"Class {className} not found.");
            return type.Assembly.FullName;
        }

        public static bool HasPublicConstructor(string className)
        {
            var type = Type.GetType(className);
            if (type == null) throw new ArgumentException($"Class {className} not found.");
            return type.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Any();
        }

        public static IEnumerable<string> GetPublicMethods(string className)
        {
            var type = Type.GetType(className);
            if (type == null) throw new ArgumentException($"Class {className} not found.");
            return type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).Select(m => m.Name);
        }

        public static IEnumerable<string> GetFieldAndProperties(string className)
        {
            var type = Type.GetType(className);
            if (type == null) throw new ArgumentException($"Class {className} not found.");
            var field = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Select(f => $"Field: {f.Name}");
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Select(p => $"Property: {p.Name}");
            return field.Concat( properties );
        }
        public static IEnumerable<string> GetImplementedInterfaces(string className)
        {
            var type = Type.GetType(className);
            if (type == null) throw new ArgumentException($"Class {className} not found.");
            return type.GetInterfaces().Select(i => i.Name);
        }

        public static IEnumerable<string> GetMethodsWithParameterType(string className, string parameterTypeName)
        {
            var type = Type.GetType(className);
            if (type == null) throw new ArgumentException($"Class {className} not found.");

            var parameterType = Type.GetType(parameterTypeName);
            if (parameterType == null) throw new ArgumentException($"Parameter type {parameterTypeName} not found.");

            return type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                       .Where(m => m.GetParameters().Any(p => p.ParameterType == parameterType))
                       .Select(m => m.Name);
        }

        public static object InvokeMethod(string className, string methodName, object[] parameters)
        {
            var type = Type.GetType(className);
            if (type == null) throw new ArgumentException($"Class {className} not found.");

            var method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            if (method == null) throw new ArgumentException($"Method {methodName} not found in class {className}.");

            var instance = Activator.CreateInstance(type);
            return method.Invoke(instance, parameters);
        }

        public static void SaveToFile(string filePath, object data)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine(data);
            }
        }

        public static T Create<T>()
        {
            var type = typeof(T);

            
            var constructor = type.GetConstructors()
                                  .OrderByDescending(c => c.GetParameters().Length)
                                  .FirstOrDefault();

            if (constructor == null)
                throw new InvalidOperationException($"Type {type.FullName} does not have a public constructor.");

            
            var parameters = constructor.GetParameters()
                                         .Select(p => GenerateDefaultValue(p.ParameterType))
                                         .ToArray();

           
            return (T)constructor.Invoke(parameters);
        }

        private static object GenerateDefaultValue(Type type)
        {
            if (type == typeof(string))
                return "Default"; 

            if (type == typeof(int))
                return 0;

            if (type == typeof(decimal))
                return 0m;

            if (type == typeof(bool))
                return false;

            if (type.IsValueType)
                return Activator.CreateInstance(type);

            return null; 
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string customer = typeof(Customer).FullName;
            Console.WriteLine($"Assembly for {customer}: {Reflector.GetAssemblyName(customer)}");
            Console.WriteLine($"Has public constructors: {Reflector.HasPublicConstructor(customer)}");
            Console.WriteLine("Public methods:");
            foreach (var method in Reflector.GetPublicMethods(customer))
            {
                Console.WriteLine($" - {method}");
            }
            Console.WriteLine("Fields and properties:");
            foreach (var member in Reflector.GetFieldAndProperties(customer))
            {
                Console.WriteLine($" - {member}");
            }



            string workerClass = typeof(Работник).FullName;
            Console.WriteLine($"\nAssembly for {workerClass}: {Reflector.GetAssemblyName(workerClass)}");
            Console.WriteLine($"Has public constructors: {Reflector.HasPublicConstructor(workerClass)}");
            Console.WriteLine("Public methods:");
            foreach (var method in Reflector.GetPublicMethods(workerClass))
            {
                Console.WriteLine($" - {method}");
            }
            Console.WriteLine("Fields and properties:");
            foreach (var member in Reflector.GetFieldAndProperties(workerClass))
            {
                Console.WriteLine($" - {member}");
            }


            string stringClass = typeof(string).FullName;
            Console.WriteLine($"\nAssembly for {stringClass}: {Reflector.GetAssemblyName(stringClass)}");
            Console.WriteLine($"Has public constructors: {Reflector.HasPublicConstructor(stringClass)}");
            Console.WriteLine("Public methods:");
            foreach (var method in Reflector.GetPublicMethods(stringClass))
            {
                Console.WriteLine($" - {method}");
            }

            string listClass = typeof(List<int>).FullName;
            Console.WriteLine($"\nAssembly for {listClass}: {Reflector.GetAssemblyName(listClass)}");
            Console.WriteLine($"Has public constructors: {Reflector.HasPublicConstructor(listClass)}");
            Console.WriteLine("Public methods:");
            foreach (var method in Reflector.GetPublicMethods(listClass))
            {
                Console.WriteLine($" - {method}");
            }

            
            var newCustomer = Reflector.Create<Customer>();
            Console.WriteLine($"\nCreated Customer: {customer?.GetType().Name}");

            var worker = Reflector.Create<Работник>();
            Console.WriteLine($"Created Worker: {worker?.GetType().Name}");
        }
    }
}
