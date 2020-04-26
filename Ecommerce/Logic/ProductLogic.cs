using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Logic
{
    public class ProductLogic
    {
        public static void Insert(Product product)
        {
            if (!Validate(product))
                return;

            if (Exists(product))
                return;

            ProductRepository.Insert(product);
        }

        public static void Update(Product product)
        {
            if (!Validate(product))
                return;

            if (Exists(product))
                return;

            ProductRepository.Update(product);
        }

        public static int CountProducts()
        {
            if (IsEmpty())
                return -1;

            return ProductRepository.GetProducts().Count();
        }

        public static void Remove(Product product)
        {
            if (Exists(product))
                ProductRepository.Remove(product);
        }

        public static bool IsEmpty()
        {
            return ProductRepository.IsEmpty();
        }

        public static bool Exists(Product product)
        {
            var repo = ProductRepository.GetProducts();

            foreach (var item in repo)
            {
                if (item.Id == product.Id)
                {
                    if(item.Name == product.Name)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static List<Product> GetProducts()
        {
            if (ProductRepository.IsEmpty())
            {
                throw new Exception("Empty list");
            }

            return ProductRepository.GetProducts();
        }

        public static Product GetProductById(int id)
        {
            return ProductRepository.GetProductById(id);
        }

        private static bool Validate(Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
                return false;

            if (string.IsNullOrEmpty(product.Description))
                return false;

            if (product.RetailPrice <= 0)
                return false;

            return !(product.PurchasePrice <= 0);
        }
    }
}
