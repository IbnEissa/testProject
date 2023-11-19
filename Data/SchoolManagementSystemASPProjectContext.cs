using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystemASPProject.Models;

namespace SchoolManagementSystemASPProject.Data
{
    public class SchoolManagementSystemASPProjectContext : DbContext
    {
        public SchoolManagementSystemASPProjectContext (DbContextOptions<SchoolManagementSystemASPProjectContext> options)
            : base(options)
        {
        }

        public DbSet<SchoolManagementSystemASPProject.Models.ClassRoom> ClassRoom { get; set; } = default!;

        public DbSet<SchoolManagementSystemASPProject.Models.Student>? Student { get; set; }

        public DbSet<SchoolManagementSystemASPProject.Models.User>? User { get; set; }

        public DbSet<SchoolManagementSystemASPProject.Models.StudentTb>? StudentTb { get; set; }

        public DbSet<SchoolManagementSystemASPProject.Models.TeacherTb>? TeacherTb { get; set; }
    }
}
