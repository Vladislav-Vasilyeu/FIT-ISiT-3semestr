using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad4
{
    internal class Program
    {
        public interface IActions
        {
            void PerformAction();
        }

        
        public class C3 : IActions
        {
            
            public string publicField = "Public Field in C3";
            protected string protectedField = "Protected Field in C3";
            private string privateField = "Private Field in C3";

            
            public string PublicProperty { get; set; }

            
            private string PrivateProperty { get; set; }

            
            public C3()
            {
                PublicProperty = "Initial Public Property in C3";
                Console.WriteLine("Constructor of C3 called");
            }

            
            public void ShowPublicInfo()
            {
                Console.WriteLine($"Public Field: {publicField}");
                Console.WriteLine($"Protected Field: {protectedField}");
                Console.WriteLine($"Private Field: {privateField}");
            }

            
            public void PerformAction()
            {
                Console.WriteLine("Action performed by C3");
            }

            
            protected void ProtectedMethod()
            {
                Console.WriteLine("Protected method in C3");
            }
        }

        
        public class C4 : C3
        {
            
            public string additionalField = "Additional Field in C4";

            
            public string AdditionalProperty { get; set; }

            
            public C4() : base() 
            {
                AdditionalProperty = "Initial Additional Property in C4";
                Console.WriteLine("Constructor of C4 called");
            }

            
            public void ShowInheritedMembers()
            {
                
                Console.WriteLine($"Inherited Public Field: {publicField}");

                
                Console.WriteLine($"Inherited Protected Field: {protectedField}");

                
                ProtectedMethod();
            }

           
            public new void PerformAction()
            {
                Console.WriteLine("Action performed by C4");
            }
        }

        class Program1
        {
            static void Main(string[] args)
            {
                
                C4 derivedObject = new C4();

                
                Console.WriteLine("\nCalling ShowPublicInfo from C3:");
                derivedObject.ShowPublicInfo(); 

                Console.WriteLine("\nCalling ShowInheritedMembers from C4:");
                derivedObject.ShowInheritedMembers(); 

                Console.WriteLine("\nCalling PerformAction from C4:");
                derivedObject.PerformAction(); 

                Console.WriteLine("\nAccessing fields and properties:");

                Console.WriteLine($"Initial publicField: {derivedObject.publicField}");
                derivedObject.publicField = "Updated Public Field in C4";
                Console.WriteLine($"Updated publicField: {derivedObject.publicField}");

                Console.WriteLine($"PublicProperty from C3: {derivedObject.PublicProperty}");

                Console.WriteLine($"Initial AdditionalProperty: {derivedObject.AdditionalProperty}");
                derivedObject.AdditionalProperty = "Updated Additional Property in C4";
                Console.WriteLine($"Updated AdditionalProperty: {derivedObject.AdditionalProperty}");
            }
        }
    }
}
