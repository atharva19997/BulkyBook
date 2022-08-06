using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    //to add DB related things.
    public class ApplicationDBContext : DbContext   //Ctrl + . will show errors. Add Entity framework core by installing package from here or manually from nuget
    {
        //General Syntax needed to connect with entity framework.
        // ctor is snippet for default constructor.
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } //It will create a Category Table with name Categories and it will have 4 columns from category table!
        //This is known as code 1st approach. other is db 1st approach, where db is already created.
    }
}
