﻿using System.ComponentModel.DataAnnotations;

namespace BlogDemo.API.DataAccessLayer
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
