﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Teachers
{
    public class TeacherCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }
    }
}
