using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api;

public partial class SharecipedevContext : DbContext
{
    public SharecipedevContext()
    {
    }

    public SharecipedevContext(DbContextOptions<SharecipedevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public virtual DbSet<RecipeStep> RecipeSteps { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=Admin12!@;database=sharecipedev");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("PRIMARY");

            entity.ToTable("ingredients");

            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.Approved)
                .HasDefaultValueSql("'1'")
                .HasColumnName("approved");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PRIMARY");

            entity.ToTable("recipes");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.Approved)
                .HasDefaultValueSql("'1'")
                .HasColumnName("approved");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recipes_ibfk_1");
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(e => e.RecipeIngredientId).HasName("PRIMARY");

            entity.ToTable("recipe_ingredient");

            entity.HasIndex(e => e.IngredientId, "ingredient_id");

            entity.HasIndex(e => e.RecipeId, "recipe_id");

            entity.Property(e => e.RecipeIngredientId).HasColumnName("recipe_ingredient_id");
            entity.Property(e => e.Approved)
                .HasDefaultValueSql("'1'")
                .HasColumnName("approved");
            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.Measurement)
                .HasMaxLength(30)
                .HasColumnName("measurement");
            entity.Property(e => e.Ordered).HasColumnName("ordered");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recipe_ingredient_ibfk_2");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recipe_ingredient_ibfk_1");
        });

        modelBuilder.Entity<RecipeStep>(entity =>
        {
            entity.HasKey(e => new { e.RecipeStepId, e.RecipeId, e.Step }).HasName("PRIMARY");

            entity.ToTable("recipe_step");

            entity.HasIndex(e => new { e.RecipeId, e.Step }, "recipe_id").IsUnique();

            entity.Property(e => e.RecipeStepId)
                .ValueGeneratedOnAdd()
                .HasColumnName("recipe_step_id");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.Step).HasColumnName("step");
            entity.Property(e => e.StepText)
                .HasMaxLength(1000)
                .HasColumnName("step_text");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeSteps)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recipe_step_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(1000)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
