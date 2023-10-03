protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<User>().ToTable("users");
    modelBuilder.Entity<Role>().ToTable("roles");
    modelBuilder.Entity<UserRole>().ToTable("user_roles");

    modelBuilder.Entity<Quiz>().ToTable("quizzes");
    modelBuilder.Entity<Question>().ToTable("questions");
    modelBuilder.Entity<Category>().ToTable("categories");

    modelBuilder.Entity<User>()
        .HasMany(u => u.UserRoles)
        .WithOne(ur => ur.User)
        .HasForeignKey(ur => ur.UserId);

    modelBuilder.Entity<Role>()
        .HasMany(r => r.UserRoles)
        .WithOne(ur => ur.Role)
        .HasForeignKey(ur => ur.RoleId);

    modelBuilder.Entity<Quiz>()
        .HasOne(q => q.Category)
        .WithMany(c => c.Quizzes)
        .HasForeignKey(q => q.CategoryId)
        .OnDelete(DeleteBehavior.Restrict); // Adjust the delete behavior as needed

    modelBuilder.Entity<Question>()
        .HasOne(q => q.Quiz)
        .WithMany(qz => qz.Questions)
        .HasForeignKey(q => q.QuizId)
        .OnDelete(DeleteBehavior.Cascade); // Adjust the delete behavior as needed

    // Add additional configurations for other entities and relationships
}
