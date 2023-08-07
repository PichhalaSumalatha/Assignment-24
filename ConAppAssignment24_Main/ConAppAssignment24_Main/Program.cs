using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConAppAssignment24;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConAppAssignment24_Main
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Employee employee = new Employee
            {
                Id = 101,
                FirstName = "Suma",
                LastName = "Latha",
                Salary = 72000.0
            };


            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("employee.bin", FileMode.Create))
            {
                binaryFormatter.Serialize(fileStream, employee);
            }


            Employee deserializedEmployee;
            using (FileStream fileStream = new FileStream("employee.bin", FileMode.Open))
            {
                deserializedEmployee = (Employee)binaryFormatter.Deserialize(fileStream);
            }


            Console.WriteLine("Binary Deserialization Result:");
            Console.WriteLine($"ID: {deserializedEmployee.Id}");
            Console.WriteLine($"First Name: {deserializedEmployee.FirstName}");
            Console.WriteLine($"Last Name: {deserializedEmployee.LastName}");
            Console.WriteLine($"Salary: {deserializedEmployee.Salary}");




            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
            using (FileStream fileStream = new FileStream("C:\\DotNet\\Assignment-24\\employee.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, employee);
            }
            using (FileStream fileStream = new FileStream("C:\\DotNet\\Assignment-24\\employee.xml", FileMode.Open))
            {
                deserializedEmployee = (Employee)xmlSerializer.Deserialize(fileStream);
            }


            Console.WriteLine("\nXML Deserialization Result:");
            Console.WriteLine($"ID: {deserializedEmployee.Id}");
            Console.WriteLine($"First Name: {deserializedEmployee.FirstName}");
            Console.WriteLine($"Last Name: {deserializedEmployee.LastName}");
            Console.WriteLine($"Salary: {deserializedEmployee.Salary}");

            Console.ReadKey();
        }
    }


}
