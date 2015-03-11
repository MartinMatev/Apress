﻿using System;
using System.Collections.Generic;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> productEnum)
        {
            decimal total = 0m;
            foreach (Product prod in productEnum)
            {
                total += prod.Price;
            }

            return total;
        }

        public static IEnumerable<Product> FilterByCategory(this IEnumerable<Product> productEnum, string categoryParam)
        {
            foreach (Product prod in productEnum)
            {
                if (prod.Category == categoryParam)
                {
                    yield return prod;
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum, Func<Product, bool> selectorparam)
        {
            foreach (Product prod in productEnum)
            {
                if (selectorparam(prod))
                {
                    yield return prod;
                }
            }
        }
    }
}