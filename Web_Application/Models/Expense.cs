using System.ComponentModel.DataAnnotations;

namespace Web_Application.Models;
/// Represents an individual expense record with an ID, monetary value, and description.
public class Expense{

    /// The unique identifier for each expense record.
    public int Id{ get; set; }

     /// The monetary value of the expense.
    public decimal Value{ get; set; }

    /// A textual description of the expense (required).
    [Required]
    public string?  Description{ get; set; }
}