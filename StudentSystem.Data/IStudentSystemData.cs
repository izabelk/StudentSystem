namespace StudentSystem.Data
{
    using StudentSystem.Data.Repositories;

    public interface IStudentSystemData
    {
        StudentsRepository Students { get; }

        CoursesRepository Courses { get; }

        HomeworksRepository Homeworks { get; }

        void SaveChanges();
    }
}
