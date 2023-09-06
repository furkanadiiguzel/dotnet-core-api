// Models/User.cs
public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    // Add other user properties as needed (e.g., role)
}

// Data/ApplicationDbContext.cs
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}
