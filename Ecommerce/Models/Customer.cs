using System.ComponentModel.DataAnnotations;

public class Customer 
{
    public int Id { get; set; }

    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Phone]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    [EmailAddress]
    public string Email { get; set; }
    public string Address { get; set; }

    [Display(Name = "Customer")]
    public string FullName 
    { 
        get 
        { 
            return FirstName + ' ' + LastName; 
        }
    }
}