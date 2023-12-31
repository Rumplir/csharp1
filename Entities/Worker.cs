﻿using S09EP03.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S09EP03.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts = new List<HourContract>();

        public Worker() { }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract) 
        {
            Contracts.Add(contract);
        }
        public void RemoveContract(HourContract contract)
        {
           Contracts.Remove(contract);
        }
        public double Income(int month, int year)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Month == month && contract.Date.Year == year)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }
    }
}
