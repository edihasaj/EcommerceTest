using System.Collections.Generic;
using System.Linq;

public class CategoryRepository
{
    private static List<Category> _categories = new List<Category>()
    {
        new Category() { Id = 1, Name = "Tech", Description = "Technology products", Items = 0 },
        new Category() { Id = 2, Name = "Books", Description = "Hardcopy and e-books", Items = 0 }
    };

    public static void Insert(Category category)
    {
        if (_categories.Any())
        {
            int lastId = _categories.Last().Id;
            category.Id = ++lastId;
            _categories.Add(category);
        }
    }

    public static void Delete(int id)
    {
        _categories.Remove(_categories.Single(x=>x.Id == id));
    }

    public static List<Category> GetCategories()
    {
        return _categories;
    }

    public static Category GetCategoryById(int id)
    {
        return _categories.Single(x=>x.Id == id);
    }

    public static void Update(Category category)
    {
        _categories.Remove(_categories.Single(x => x.Id == category.Id));
        _categories.Add(category);
    }

    public static bool Exists(Category category)
    {
        foreach (var item in _categories)
        {

            if (item.Name == category.Name)
                if (item.Description == category.Description)
                    if (item.Items == category.Items)
                        if (item.Id == category.Id)
                            return true;

        }

        return false;
    }
}