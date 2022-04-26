using System;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.Json;

using EntityFramework.LabExercise2.Repositories;
using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;
using System.Linq;

namespace EntityFramework.LabExercise2
{

    internal class Program
    {
        static void Main(string[] args)
        {

            ConfigurationHelper configurationHelper = ConfigurationHelper.Instance();
            var dbConnectionString = configurationHelper.GetProperty<string>("DbConnectionString");

            using (RecruitmentContext context = new RecruitmentContext(dbConnectionString))
            {
                Console.Write("\nInput Employee Code: ");
                string EmployeeCode = Console.ReadLine();
                Console.Clear();

                EmployeeGenericRepository employeeRepository = new(context);
                Employee employee = employeeRepository.FindByEmployeeCode(EmployeeCode);

                if (employee is Employee)
                {
                    EmployeePositionGenericRepository positionRepository = new(context);
                    Position position = positionRepository.FindByEmployeeCode(employee.CCurrentPosition);
                    

                    Console.WriteLine("***********************************");
                    Console.WriteLine($"Details for Employee Code: {employee.CEmployeeCode}");
                    Console.WriteLine("***********************************");

                    Console.WriteLine($"First Name: { employee.VFirstName}");
                    Console.WriteLine($"Last Name: { employee.VLastName}");
                    Console.WriteLine($"Postion: { position.VDescription}");
                    Console.WriteLine();

                    Console.WriteLine("\tAnnual Salary: ");
                    AnnualSalaryGenericRepository annualSalaryRepository = new AnnualSalaryGenericRepository(context);
                    List<AnnualSalary> annualSalaries = annualSalaryRepository.GetAnnualSalary(EmployeeCode);
                    foreach (var annualSalary in annualSalaries)
                    {
                        Console.WriteLine($"\t{annualSalary.SiYear}: {annualSalary.MAnnualSalary}");
                    }
                    Console.WriteLine();

                    Console.WriteLine("\tMonthly Salary: ");
                    MonthlySalaryGenericRepository monthlySalaryRepository = new(context);
                    List<MonthlySalary> monthlySalaries = monthlySalaryRepository.GetMonthlySalary(EmployeeCode);
                    foreach (var monthslySalary in monthlySalaries)
                    {
                        Console.WriteLine($"\t{monthslySalary.DPayDate.ToString("MMMM yyyy")}: {monthslySalary.MMonthlySalary}");
                    }
                    Console.WriteLine();

                    EmployeeSkillGenericRepository employeeSkillRepository = new(context);
                    IEnumerable<dynamic> skills = employeeSkillRepository.FindAll(employee.CEmployeeCode);
                    Console.WriteLine("\tSkill: ");
                    foreach(var skill in skills)
                    {
                        Console.WriteLine($"\t*{skill.CSkillCode}");
                    }
                }
            }
        }
    }
}