using System.ComponentModel.DataAnnotations;

public class Category
{
    public int Id { get; set; }

    [Display(Name = "Category")]
    public string Name { get; set; }
    public string Description { get; set; }

    [Display(Name = "Items (In-Category)")]
    public int Items { get; set; }
}