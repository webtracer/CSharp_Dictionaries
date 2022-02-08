using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionaries_Demo
{
    class Program
    {   
        //key - value

        static void Main(string[] args)
        {
            /*
            // Dictionary<TKey, TValue>;  TKey = Type of Key (data Type), TValue = Type of value entered
            Dictionary<int, string> myDictionarly = new Dictionary<int, string>()
            {
                {1, "one" },
                {2, "two" },
                {3, "three" }
            };
            */
#region Populate the Employee Objects
            Employee[] employees =
            {
                new Employee("CEO", "Gwyn", 95, 200),
                new Employee("Manager", "Joe", 35, 25),
                new Employee("HR", "Lora", 33, 21),
                new Employee("Secretary", "Petra", 28, 18),
                new Employee("Lead Developer", "Artorias", 55, 35),
                new Employee("Intern", "Ernest", 22, 8),
            };
            #endregion

#region Populate the EmployeeDictionary from the Employee Objects
            Dictionary<string, Employee> employeesDictionary = new Dictionary<string, Employee>();
            foreach(Employee emp in employees)
            {
                employeesDictionary.Add(emp.Role, emp);
            }

            #endregion

#region Loop through the EmployeesDictionary and write the Employees to the console
            for (int i = 0; i < employeesDictionary.Count; i++)
            {
                //using ElementAt(i) to return the key value pair stored at index i
                KeyValuePair<string, Employee> keyValuePair = employeesDictionary.ElementAt(i);

                //print the key
                Console.WriteLine($"Key: {keyValuePair.Key}, i is {i}");

                //storing the value in an employee object
                Employee employeeValue = keyValuePair.Value;

                //printing the properties of the employee object
                Console.WriteLine($"Employee Name: {employeeValue.Name}");
                Console.WriteLine($"Employee Role: {employeeValue.Role}");
                Console.WriteLine($"Employee Age: {employeeValue.Age}");
                Console.WriteLine($"Employee Salary: {employeeValue.Salary}");
                Console.WriteLine("----------"); Console.WriteLine(" ");
            }
            #endregion

#region Fetching Data from the Dictionary based on a Key 
            string key = "CEO";
            if (employeesDictionary.ContainsKey(key))
            {
                // Fetch data from the Dictionary
                Employee empl = employeesDictionary[key];
                Console.WriteLine($"Employee Name: {empl.Name}, Role: {empl.Role}, Salary: {empl.Salary}");
            }
            else
            {
                Console.WriteLine($"No employee found with this Key {key}");
            }
            #endregion

#region Edit the Values in a Dictionary via Key-Value Pairs
            // edit a key - value pair in a dictionary
            string keyToUpdate = "HR";
            if (employeesDictionary.ContainsKey(keyToUpdate))
            {
                employeesDictionary[keyToUpdate] = new Employee("HR", "Eleka", 26, 18);
                Console.WriteLine($"The employee with Role/Key {keyToUpdate} was updated successfully");
            }
            else
            {
                Console.WriteLine($"The employee with Role/Key {keyToUpdate} was not updated.  Please ensure you are using a valid Key");
            }
            #endregion

#region Remove an Entry from a dictionary
            // remove an entry from a dictionary
            string keyToRemove = "Intern";
            if(employeesDictionary.Remove(keyToRemove))
            {
                Console.WriteLine($"Employee with Key {keyToRemove} was removed from the database");
            }
            else
            {
                Console.WriteLine($"No employee with Key {keyToRemove} was found, please make sure you are using the correct Key");
            }
            #endregion

#region Retrieve Data from the Dictionary using TryGetValue
            Employee result = null;
            //using TryGetValue() it returns true if the operation was successful and false otherwise
            if(employeesDictionary.TryGetValue("Intern", out result))
            {
                Console.WriteLine(" ");
                Console.WriteLine("Value Retrieved!");

                Console.WriteLine($"Employee Name: {result.Name}");
                Console.WriteLine($"Employee Role: {result.Role}");
                Console.WriteLine($"Employee Age: {result.Age}");
                Console.WriteLine($"Employee Salary: {result.Salary}");
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine($"The Key does not exist.");
            }
#endregion
        }
    }
}
