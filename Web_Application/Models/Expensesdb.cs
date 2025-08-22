using Microsoft.EntityFrameworkCore;

namespace Web_Application.Models;
/// The Expensesdb class represents the Entity Framework database context
/// for interacting with the Expenses data.


public class Expensesdb : DbContext{

    /// A DbSet of Expense objects representing the 'Expenses' table in the database.
    /// Allows adding, updating, and deleting Expense records.
    public DbSet<Expense> Expenses {get; set;}

    /// Constructor that forwards the DbContextOptions to the base DbContext class.
    /// This enables configuration for the Expensesdb context to be set up externally
    public Expensesdb(DbContextOptions<Expensesdb> options )
    : base(options)
    {
        
    }
}
