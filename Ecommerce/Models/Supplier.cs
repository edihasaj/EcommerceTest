using System.ComponentModel.DataAnnotations;

public class Supplier
{
    public int Id { get; set; }

    [Display(Name = "Contact Name")]
    public string ContactName { get; set; }

    [Display(Name = "Contact Title")]
    public string ContactTitle { get; set; }

    [Display(Name = "Company Name")]
    public string CompanyName { get; set; }

    [Phone]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}