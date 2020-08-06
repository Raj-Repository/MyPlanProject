using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagmentTree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = LoadEmployees();
            displayManagementTree(employeeList);
        }
        public static void displayManagementTree(List<Employee> employeeList)
        {
            // check if the list has employees
            if (employeeList != null && employeeList.Count > 0)
            {
                Employee managerEmp = employeeList.OrderBy(y => y.ManagerId).ToList().FirstOrDefault();

                Console.WriteLine("->" + managerEmp.Name);
                printChildEmployes(managerEmp.Id, employeeList, 2);
                Console.WriteLine(employeeList.Count);
            }
            else
            {
                Console.WriteLine("Employee list is empty");
            }
        }

        public static void printChildEmployes(int Id , List<Employee> employeeList,int rank)
        {
            // get a list if child employees in sorted order.
            List<Employee> childList =  employeeList.Where(x => x.ManagerId == Id).ToList().OrderBy(z => z.Name).ToList();
            // create arrow string based on the rank
            string result = new StringBuilder().Insert(0, "->", rank).ToString();
            int newrank = rank + 1;
            //recursive loop through each child emplyee and display the name 
            foreach (Employee empChild in childList)
            {
                Console.WriteLine(result + (empChild.Name));
                printChildEmployes(empChild.Id, employeeList, newrank);
            }

        }
        public static List<Employee> LoadEmployees()
        {
            // create the dataset and return in an order
            List<Employee> empList = new List<Employee>() {
                                    new Employee { Id = 1,Name = "Tom", ManagerId = 0 },
                                    new Employee { Id = 2,Name = "Mickey", ManagerId = 1 },
                                    new Employee { Id = 3,Name = "Jerry", ManagerId = 1},
                                    new Employee { Id = 4,Name = "John", ManagerId = 2 },
                                    new Employee { Id = 5,Name = "Sarah", ManagerId = 1 }
                            };
            return empList.OrderBy(x=> x.ManagerId).ToList();
        }
    }
}
