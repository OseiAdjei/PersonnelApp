//using App.Domain;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.DependencyInjection;

//namespace App
//{
//    public class AppDbInitializer
//    {
//        public static void Seed(IApplicationBuilder applicationBuilder)
//        {
//            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
//            {
//                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

//                context.Database.EnsureCreated();

//                //College
//                if (!context.College.Any())
//                {
//                    var colleges = new List<College>();
//                    {
//                        new College()
//                        {
//                            CollegeName = "Sample College",
//                            CollegeEmail = "college@example.com",
//                            CollegeProvost = "Provost Name",
//                            CollegeDescription = "Sample College Description",
//                            CollegeLogoUrl = "college-logo.jpg",
//                            NspId = 1 // Assuming the NspId foreign key
//                        };
//                        new College()
//                        {
//                            CollegeId = 2302,
//                            CollegeLogoUrl = "https://www.freepik.com/free-photos-vectors/background",
//                            CollegeName = "College of Engineering (CoE)",
//                            CollegeEmail = "coe@knust.edu.gh",
//                            CollegeProvost = "Dr. Daniel Quansah",
//                            CollegeDescription = "This is a sample history of department"
//                        };
//                        new College()
//                        {
//                            CollegeId = 2303,
//                            CollegeLogoUrl = "https://www.freepik.com/free-photos-vectors/background",
//                            CollegeName = "College of Humanities and Social Sciences (CoHSS)",
//                            CollegeEmail = "cos@knust.edu.gh",
//                            CollegeProvost = "Dr. Daniel Quansah",
//                            CollegeDescription = "This is a sample history of department"
//                        };
//                        context.College.AddRange(colleges);
//                        context.SaveChanges();
//                    }
//                    //Faculty
//                    if (!context.Faculty.Any())
//                    {
//                        var Faculties = new List<Faculty>();
//                        {
//                            new Faculty()
//                            {
//                                FacultyId = 2401,
//                                FacultyLogoUrl = "https://www.freepik.com/free-photos-vectors/background",
//                                FacultyName = "Physical and Computational Sciences",
//                                FacultyEmail = "pcs-cos@knust.edu.gh",
//                                FacultyDean = "Dr. Daniel Quansah",
//                                FacultyDescription = "This is a sample history of department",
//                                DepartmentId = 2501
//                            };
//                            new Faculty()
//                            {
//                                FacultyId = 2402,
//                                FacultyLogoUrl = "https://www.freepik.com/free-photos-vectors/background",
//                                FacultyName = "Engineering Analysis and Structures",
//                                FacultyEmail = "eas-coe@knust.edu.gh",
//                                FacultyDean = "Dr. Daniel Quansah",
//                                FacultyDescription = "This is a sample history of department",
//                                DepartmentId = 2502
//                            };
//                            new Faculty()
//                            {
//                                FacultyId = 2403,
//                                FacultyLogoUrl = "https://www.freepik.com/free-photos-vectors/background",
//                                FacultyName = "Media and Relations",
//                                FacultyEmail = "mrs-cohss@knust.edu.gh",
//                                FacultyDean = "Dr. Daniel Quansah",
//                                FacultyDescription = "This is a sample history of department",
//                                DepartmentId = 2503
//                            };
//                        };
//                        context.Faculty.AddRange(Faculties);
//                        context.SaveChanges();

//                    }
//                    //Department
//                    if (!context.Department.Any())
//                    {
//                        var departments = new List<Department>();
//                        {
//                            new Department()
//                            {
//                                DepartmentId = 2501,
//                                DepartmentLogoUrl = "https://www.freepik.com/free-photos-vectors/background",
//                                DepartmentName = "Department of Physics",
//                                DepartmentEmail = "physics.cos@knust.edu.gh",
//                                DepartmentHod = "Dr. Daniel Quansah",
//                                DepartmentDescription = "This is a sample history of department"
//                            };
//                            new Department()
//                            {
//                                DepartmentId = 2502,
//                                DepartmentLogoUrl = "https://www.freepik.com/free-photos-vectors/background",
//                                DepartmentName = "Department of Electrical Engineering",
//                                DepartmentEmail = "eeng.coe@knust.edu.gh",
//                                DepartmentHod = " Mr. Daniel Quansah",
//                                DepartmentDescription = "This is a sample history of department"
//                            };
//                            new Department()
//                            {
//                                DepartmentId = 2503,
//                                DepartmentLogoUrl = "https://www.freepik.com/free-photos-vectors/background",
//                                DepartmentName = "Department of Language and Communication Studies",
//                                DepartmentEmail = "lcss.cohsss@knust.edu.gh",
//                                DepartmentHod = "Dr. Daniel Quansah",
//                                DepartmentDescription = "This is a sample history of department"
//                            };
//                        };
//                        context.Department.AddRange(departments);
//                        context.SaveChanges();

//                    }
//                    //Nsp
//                    if (!context.Nsp.Any())
//                    {
//                        var Nsps = new List<Nsp>();
//                        {
//                            new Nsp()
//                            {
//                                NspId = 2024001,
//                                NspPicUrl = "https://www.freepik.com/free-photos-vectors/background",
//                                NspName = "Kwame Amankwatia Jnr",
//                                NspNumber = "NSSGST10109082",
//                                NspPhone = "594189118",
//                                NspEmail = "sample@email.com"
//                            };
//                            new Nsp()
//                            {
//                                NspId = 2024002,
//                                NspPicUrl = "https://www.freepik.com/free-photos-vectors/background",
//                                NspName = "George Bush",
//                                NspNumber = "NSSGST10104182",
//                                NspPhone = "507130629",
//                                NspEmail = "sample@email.com"
//                            };
//                            new Nsp()
//                            {
//                                NspId = 2024003,
//                                NspPicUrl = "https://www.freepik.com/free-photos-vectors/background",
//                                NspName = "Bridget Manu Thomas",
//                                NspNumber = "NSSGST10237890",
//                                NspPhone = "507262645",
//                                NspEmail = "sample@email.com"
//                            };
//                        };
//                        context.Nsp.AddRange(Nsps);
//                        context.SaveChanges();
//                    }
//                }
//            }
//        }
//    }
//}
