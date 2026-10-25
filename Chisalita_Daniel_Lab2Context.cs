using Chisalita_Daniel_Lab2.Models;
using Microsoft.EntityFrameworkCore;

public class Chisalita_Daniel_Lab2Context(DbContextOptions<Chisalita_Daniel_Lab2Context> options) : DbContext(options)
{
    public DbSet<Book> Book { get; set; } = default!;
    public DbSet<Publisher> Publisher { get; set; } = default!;
    public DbSet<Author> Author { get; set; } = default!;
    public DbSet<Category> Category { get; set; } = default!;
    public DbSet<BookCategory> BookCategory { get; set; } = default!;
}