namespace NewsPortal.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NewsPortal.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsPortal.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NewsPortal.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);



            //Shtimi i një roli admin
            const string name = "admin@gmail.com";
            const string password = "admin1234";
            const string roleName = "Admin";

            //Krijojme nje rol Admin nqs ai nuk egziston
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = name,
                    Email = name,

                };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            const string journalistname = "journalist@gmail.com";
            const string journalistpassword = "journalist1234";
            const string journalistroleName = "Journalist";

            //Krijojme nje rol Admin nqs ai nuk egziston
            var role2 = roleManager.FindByName(roleName);
            if (role2 == null)
            {
                role2 = new IdentityRole(journalistroleName);
                var roleresult = roleManager.Create(role2);
            }

            var user2 = userManager.FindByName(journalistname);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = name,
                    Email = name,

                };
                var result = userManager.Create(user, journalistpassword);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }
            ////Krijimi i nje Journalist Role
            //var rolesForUser = userManager.GetRoles(user.Id);
            //if (!rolesForUser.Contains(role.Name))
            //{
            //    var result = userManager.AddToRole(user.Id, role.Name);
            //}


            //const string userRoleName = "Journalist";
            //role = roleManager.FindByName(userRoleName);
            //if (role == null)
            //{
            //    role = new IdentityRole(userRoleName);
            //    var roleresult = roleManager.Create(role);
            //}

        }
    }
}
