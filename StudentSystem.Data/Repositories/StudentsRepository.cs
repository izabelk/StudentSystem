namespace StudentSystem.Data.Repositories
{
    using System.Linq;

    using StudentSystem.Models;
    
    public class StudentsRepository : GenericRepository<Student>, IGenericRepository<Student>
    {
        public StudentsRepository(IStudentSystemDbContext context)
            : base(context)
        {
        }
    }
}
