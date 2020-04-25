using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CategoryTest
    {
        Category Category;
        Category CategoryEmpty;
        Category CategoryUpdate;

        [SetUp]
        public void SetUp()
        {
            Category = new Category()
            {
                Id = 1,
                Name = "Tech",
                Description = "Technology products",
                Items = 0
            };


            CategoryEmpty = new Category()
            {
                Id = 1,
                Name = "",
                Description = "",
                Items = 0
            };

            CategoryUpdate = new Category()
            {
                Id = 1,
                Name = "Kitchen",
                Description = "Nothing",
                Items = 0
            };
        }

        [TestCase(1)]
        public void GetCategoryById_NameTest(int id)
        {
            var result = CategoryRepository.GetCategoryById(id);

            Assert.AreEqual(Category.Name, result.Name);
        }

        [TestCase(1)]
        public void GetCategoryById_DescriptonTest(int id)
        {
            var result = CategoryRepository.GetCategoryById(id);

            Assert.AreEqual(Category.Description, result.Description);
        }

        [TestCase(1)] // should fail
        public void GetCategoryById_Test(int id)
        {
            Category result = CategoryRepository.GetCategoryById(id);

            Assert.AreEqual(CategoryEmpty, result);
        }

        [TestCase(1)]
        public void UpdateCategory_TestById(int id)
        {
            CategoryRepository.Update(CategoryUpdate);
            var resultAfter = CategoryRepository.GetCategoryById(id);

            Assert.AreEqual(CategoryUpdate, resultAfter);
        }

        [Test]
        public void CategoryExists_Test()
        {
            //var result = CategoryRepository.Exists(Category);
            //Assert.IsTrue(result);
        }



    }
}