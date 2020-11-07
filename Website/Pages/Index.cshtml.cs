using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BleakwindBuffet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// stores Entree List
        /// </summary>
        public IEnumerable<IOrderItem> Entrees { get; set; }


        /// <summary>
        /// stores Side List
        /// </summary>
        public IEnumerable<IOrderItem> Sides { get; set; }

        /// <summary>
        /// stores Drink List
        /// </summary>
        public IEnumerable<IOrderItem> Drinks { get; set; }

        /// <summary>
        ///  Stores filter for Categories
        /// </summary>
        public string[] Category { get; set; }

        /// <summary>
        /// Stores filter for price min
        /// </summary>
        public double? PriceMin { get; set; }

        /// <summary>
        /// Stores filter for price max
        /// </summary>
        public double? PriceMax { get; set; }

        /// <summary>
        /// Stores filter for calorie min
        /// </summary>
        public int? CalorieMin { get; set; }

        /// <summary>
        /// Stores filter for calorie max
        /// </summary>
        public int? CalorieMax { get; set; }

        /// <summary>
        /// stores term 
        /// </summary>
        public string SearchTerms { get; set; }


        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the filters, gets new lists using the filters, and reloads the page
        /// </summary>
        /// <param name="SearchTerms">Phrase to search for</param>
        /// <param name="Category">Entree, Side, or Drink</param>
        /// <param name="PriceMin">Min price</param>
        /// <param name="PriceMax">Max price</param>
        /// <param name="CalorieMin">min Calorie</param>
        /// <param name="CalorieMax">max Calorie</param>
        public void OnGet(string SearchTerms, string[] Category, double? PriceMin, double? PriceMax, int? CalorieMin, int? CalorieMax)
        {
            this.SearchTerms = SearchTerms;
            this.Category = Category;
            this.PriceMin = PriceMin;
            this.PriceMax = PriceMax;
            this.CalorieMin = CalorieMin;
            this.CalorieMax = CalorieMax;
            Entrees = Menu.Entrees();
            Sides = Menu.Sides();
            Drinks = Menu.Drinks();

            Entrees = Menu.Search(Entrees, SearchTerms);
            Sides = Menu.Search(Sides, SearchTerms);
            Drinks = Menu.Search(Drinks, SearchTerms);

            Entrees = Menu.FilterByCategory(Entrees, Category);
            Sides = Menu.FilterByCategory(Sides, Category);
            Drinks = Menu.FilterByCategory(Drinks, Category);

            Entrees = Menu.FilterByCalories(Entrees, CalorieMin, CalorieMax);
            Sides = Menu.FilterByCalories(Sides, CalorieMin, CalorieMax);
            Drinks = Menu.FilterByCalories(Drinks, CalorieMin, CalorieMax);

            Entrees = Menu.FilterByPrice(Entrees, PriceMin, PriceMax);
            Sides = Menu.FilterByPrice(Sides, PriceMin, PriceMax);
            Drinks = Menu.FilterByPrice(Drinks, PriceMin, PriceMax);
        }
    }
}
