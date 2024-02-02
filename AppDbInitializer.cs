using App.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace App
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //College
                if (!context.College.Any())
                {
                    var colleges = new List<College>();
                    {
                        new College()
                        {
                            CollegeName = "Sample College",
                            CollegeEmail = "college@example.com",
                            CollegeProvost = "Provost Name",
                            CollegeDescription = "Sample College Description",
                            CollegeLogoUrl = "college-logo.jpg",
                        };
                        context.College.AddRange(colleges);
                        context.SaveChanges();
                    }
                    //Faculty
                    if (!context.Faculty.Any())
                    {
                        var Faculties = new List<Faculty>();
                        {
                            new Faculty()
                            {
                                FacultyId = 2401,
                                FacultyLogoUrl = "https://www.freepik.com/free-photos-vectors/background",
                                FacultyName = "Physical and Computational Sciences",
                                FacultyEmail = "pcs-cos@knust.edu.gh",
                                FacultyDean = "Dr. Daniel Quansah",
                                FacultyDescription = "This is a sample history of department",
                                CollegeId = 1
                            };
                        };
                        context.Faculty.AddRange(Faculties);
                        context.SaveChanges();

                    }
                    //Department
                    if (!context.Department.Any())
                    {
                        var departments = new List<Department>();
                        {
                            new Department()
                            {
                                DepartmentLogoUrl = "https://www.freepik.com/free-photos-vectors/background",
                                DepartmentName = "Department of Physics",
                                DepartmentEmail = "physics.cos@knust.edu.gh",
                                DepartmentHod = "Dr. Daniel Quansah",
                                DepartmentDescription = "This is a sample history of department",
                                FacultyId= 1
                            };
                        };
                        context.Department.AddRange(departments);
                        context.SaveChanges();

                    }
                    //Nsp
                    if (!context.Nsp.Any())
                    {
                        var Nsps = new List<Nsp>();
                        {
                            new Nsp()
                            {
                                NspId = 2024001,
                                NspPicUrl = "https://www.freepik.com/free-photos-vectors/background",
                                NspName = "Kwame Amankwatia Jnr",
                                NspNumber = "NSSGST10109082",
                                NspPhone = "594189118",
                                NspEmail = "sample@email.com",
                                NspBio = "I am a Personnel"
                            };
                        };
                        context.Nsp.AddRange(Nsps);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
