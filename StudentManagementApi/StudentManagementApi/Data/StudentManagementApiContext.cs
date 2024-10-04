using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagementApi.Models;

namespace StudentManagementApi.Data
{
    public class StudentManagementApiContext : DbContext
    {
        public StudentManagementApiContext (DbContextOptions<StudentManagementApiContext> options)
            : base(options)
        {
        }

        public DbSet<StudentManagementApi.Models.Student> Student { get; set; } = default!;
    }
}
