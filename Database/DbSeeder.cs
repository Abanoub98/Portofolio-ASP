using Microsoft.EntityFrameworkCore;
using Portofolio.Models;
using Faker;
using System;
namespace Portofolio.Database
{
    public static class DbSeeder
    {
        private static readonly int NUM_OF_RANDOM_DATA = 50;
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedContactStatuses(modelBuilder);
            SeedContacts(modelBuilder);
            SeedLinkTypes(modelBuilder);
            SeedProjectTypes(modelBuilder);
            SeedProjects(modelBuilder);
            SeedProjectFeedbacks(modelBuilder);
            SeedProjectImages(modelBuilder);
            SeedProjectLinks(modelBuilder);
            SeedUsers(modelBuilder);
            SeedUserLinks(modelBuilder);
            SeedUserRoles(modelBuilder);
            SeedUsersInProject(modelBuilder);
        }

        private static void SeedContacts(ModelBuilder modelBuilder)
        {
            Contact[] contacts = new Contact[NUM_OF_RANDOM_DATA];
            for (int i = 0; i < contacts.Length; i++)
            {
                Contact contact = new Contact
                {
                    Id = i + 1,
                    StatusId = 1,
                    ContactName = Faker.Name.FullName(),
                    Phone = "+201206784139",
                    Email = Faker.Internet.Email(),
                    Message = Faker.Lorem.Paragraph(2),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                contacts[i] = contact;
            }
            modelBuilder.Entity<Contact>().HasData(contacts);
        }

        private static void SeedContactStatuses(ModelBuilder modelBuilder)
        {
            ContactStatus csPending = new ContactStatus
            {
                Id = 1,
                Status = "Pending",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            ContactStatus csViewed = new ContactStatus
            {
                Id = 2,
                Status = "Viewed",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            ContactStatus csCompleted = new ContactStatus
            {
                Id = 3,
                Status = "Completed",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            modelBuilder.Entity<ContactStatus>().HasData(
                csPending,
                csViewed,
                csCompleted
            );
        }

        private static void SeedLinkTypes(ModelBuilder modelBuilder)
        {
            LinkType url = new LinkType
            {
                Id = 1,
                Type = "Url",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            LinkType github = new LinkType
            {
                Id = 2,
                Type = "Github",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            LinkType linkedIn = new LinkType
            {
                Id = 3,
                Type = "LinkedIn",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            LinkType facebook = new LinkType
            {
                Id = 4,
                Type = "Facebook",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            modelBuilder.Entity<LinkType>().HasData(url, github, linkedIn, facebook);
        }

        private static void SeedProjectTypes(ModelBuilder modelBuilder)
        {
            ProjectType desktop = new ProjectType
            {
                Id = 1,
                Type = "Desktop Application",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            ProjectType mobile = new ProjectType
            {
                Id = 2,
                Type = "Mobile Application",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            ProjectType web = new ProjectType
            {
                Id = 3,
                Type = "Web Application",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            modelBuilder.Entity<ProjectType>().HasData(desktop, mobile, web);
        }

        private static void SeedProjects(ModelBuilder modelBuilder)
        {
            Project[] projects = new Project[NUM_OF_RANDOM_DATA];
            for (int i = 0; i < projects.Length; i++)
            {
                Project project = new Project
                {
                    Id = i + 1,
                    TypeId = Faker.RandomNumber.Next(1, 3),
                    Title = Faker.Lorem.GetFirstWord(),
                    Description = Faker.Lorem.Paragraph(2),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                projects[i] = project;
            }
            modelBuilder.Entity<Project>().HasData(projects);
        }

        private static void SeedProjectFeedbacks(ModelBuilder modelBuilder)
        {
            ProjectFeedback[] feedbacks = new ProjectFeedback[NUM_OF_RANDOM_DATA];
            for (int i = 0; i < feedbacks.Length; i++)
            {
                ProjectFeedback feedback = new ProjectFeedback
                {
                    Id = i + 1,
                    Feedback = Faker.Lorem.Paragraph(2),
                    ProjectId = Faker.RandomNumber.Next(1, NUM_OF_RANDOM_DATA),
                    CreatedAt = DateTime.Now
                };

                feedbacks[i] = feedback;
            }
            modelBuilder.Entity<ProjectFeedback>().HasData(feedbacks);
        }

        private static void SeedProjectImages(ModelBuilder modelBuilder)
        {
            ProjectImage[] projectImages = new ProjectImage[NUM_OF_RANDOM_DATA];
            for (int i = 0; i < projectImages.Length; i++)
            {
                ProjectImage projectImage = new ProjectImage
                {
                    Id = i + 1,
                    ProjectId = i + 1,
                    ImagePath = Faker.Lorem.Paragraph(1),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                projectImages[i] = projectImage;
            }
            modelBuilder.Entity<ProjectImage>().HasData(projectImages);
        }

        private static void SeedProjectLinks(ModelBuilder modelBuilder)
        {
            ProjectLink[] projectLinks = new ProjectLink[NUM_OF_RANDOM_DATA];
            for (int i = 0; i < projectLinks.Length; i++)
            {
                var projectLink = new ProjectLink
                {
                    Id = i + 1,
                    ProjectId = i + 1,
                    TypeId = Faker.RandomNumber.Next(1, 2),
                    Link = Faker.Internet.Url(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                projectLinks[i] = projectLink;
            }
            modelBuilder.Entity<ProjectLink>().HasData(projectLinks);
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            User[] users = new User[NUM_OF_RANDOM_DATA];
            for (int i = 0; i < users.Length; i++)
            {
                var user = new User
                {
                    Id = i + 1,
                    UserName = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    ImagePath = Faker.Lorem.Paragraph(1),
                    PhoneNumber = "+201206784139",
                    PasswordHash = Faker.Identification.SocialSecurityNumber(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Specialization = "Backend Developer"
                };
                users[i] = user;
            }
            modelBuilder.Entity<User>().HasData(users);
        }

        private static void SeedUserLinks(ModelBuilder modelBuilder)
        {
            UserLink[] userLinks = new UserLink[NUM_OF_RANDOM_DATA];
            for (int i = 0; i < userLinks.Length; i++)
            {
                var userLink = new UserLink
                {
                    Id = i + 1,
                    UserId = i + 1,
                    TypeId = Faker.RandomNumber.Next(1, 4),
                    Link = Faker.Internet.Url(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                userLinks[i] = userLink;
            }
            modelBuilder.Entity<UserLink>().HasData(userLinks);
        }

        private static void SeedUserRoles(ModelBuilder modelBuilder)
        {
            UserRoleInProject backEnd = new UserRoleInProject
            {
                Id = 1,
                Role = "Back End Developer",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            UserRoleInProject frontEnd = new UserRoleInProject
            {
                Id = 2,
                Role = "Front End Developer",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            UserRoleInProject teamLeader = new UserRoleInProject
            {
                Id = 3,
                Role = "Team Leader",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            UserRoleInProject mobile = new UserRoleInProject
            {
                Id = 4,
                Role = "Mobile Developer",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            modelBuilder.Entity<UserRoleInProject>().HasData(backEnd, frontEnd, mobile, teamLeader);
        }

        private static void SeedUsersInProject(ModelBuilder modelBuilder)
        {
            UsersInProject[] usersInProject = new UsersInProject[NUM_OF_RANDOM_DATA];
            for (int i = 0; i < usersInProject.Length; i++)
            {
                var userInProject = new UsersInProject
                {
                    Id = i + 1,
                    UserId = Faker.RandomNumber.Next(1, NUM_OF_RANDOM_DATA),
                    RoleId = Faker.RandomNumber.Next(1, 4),
                    ProjectId = Faker.RandomNumber.Next(1, NUM_OF_RANDOM_DATA)
                };
                usersInProject[i] = userInProject;
            }
            modelBuilder.Entity<UsersInProject>().HasData(usersInProject);
        }

        public static void SeedServices(this ModelBuilder modelBuilder)
        {
            Service webAppService = new Service
            {
                Id = 1,
                ServiceName = "Web Application Service",
                ServiceDescription = Faker.Lorem.Paragraph(3),
                ServiceImage = Faker.Lorem.Paragraph(1)
            };

            Service desktopAppService = new Service
            {
                Id = 2,
                ServiceName = "Desktop Application Service",
                ServiceDescription = Faker.Lorem.Paragraph(3),
                ServiceImage = Faker.Lorem.Paragraph(1)
            };

            Service mobileAppService = new Service
            {
                Id = 3,
                ServiceName = "Mobile Application Service",
                ServiceDescription = Faker.Lorem.Paragraph(3),
                ServiceImage = Faker.Lorem.Paragraph(1)
            };

            modelBuilder.Entity<Service>().HasData(webAppService, desktopAppService, mobileAppService);
        }

    }
}