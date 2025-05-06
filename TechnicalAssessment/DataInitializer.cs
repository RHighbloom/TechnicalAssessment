using TechnicalAssessment.Data;
using TechnicalAssessment.Models.Entities;
public class DataInitializer
{
    public static void InitData(AppDBContext context)
    {
        context.Database.EnsureCreated();

        if (context.Students.Any())
        {
            return; // DB has been seeded
        }

        var schools = new List<School>
        {
            new School { Name = "School A", Address1 = "123 Main St", City = "CityA", State = "CA", ZipCode = "12345" },
            new School { Name = "School B", Address1 = "456 Elm St", City = "CityB", State = "CA", ZipCode = "67890" },
            new School { Name = "School C", Address1 = "789 Oak St", City = "CityC", State = "CA", ZipCode = "54321" }
        };
        
        context.Schools.AddRange(schools);
        context.SaveChanges();

        var students = new List<Student>
        {
            new Student {FirstName = "Tom", LastName = "Adams", School = schools[0].Id, Major = "Computer Science", DateModified = DateTime.Parse("04/05/2018"), IsActive = true },
            new Student {FirstName = "John", LastName = "Smith", School = schools[1].Id, Major = "Mathematics", DateModified = DateTime.Parse("03/28/2018"), IsActive = true },
            new Student {FirstName = "Jane", LastName = "Doe", School = schools[2].Id, Major = "Physics", DateModified = DateTime.Parse("03/22/2018"), IsActive = false },  
            new Student {FirstName = "Mary", LastName = "Johnson", School = schools[0].Id, Major = "Chemistry", DateModified = DateTime.Parse("05/21/2018"), IsActive = true },
        };

        context.Students.AddRange(students);
        context.SaveChanges();
    }
}