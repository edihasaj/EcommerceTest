using System;
using System.Collections.Generic;

namespace Ecommerce.Logic
{
    public class ProductLogic
    {
        public static void Insert(Product product)
        {
            if (product == null)
                return;

            if (Exists(product))
                return;

            ProductRepository.Insert(product);
        }

        public static void Update(Product product)
        {
            if (product == null)
                return;

            ProductRepository.Update(product);
        }

        public static int CountProducts()
        {
            if (IsEmpty())
                return -1;

            int result = 0;
            var repo = ProductRepository.GetProducts();

            foreach (var item in repo)
                result++;

            return result;
        }

        public static void Remove(Product product)
        {
            if (product == null)
                return;

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
    }
}
