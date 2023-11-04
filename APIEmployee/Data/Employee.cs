﻿using System.ComponentModel.DataAnnotations;

namespace MVCEmployee.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}
