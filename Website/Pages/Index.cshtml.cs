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

            if(SearchTerms != null && SearchTerms != "")
            {
                string[] array = SearchTerms.Split(' ');
                int count = 0;
                foreach(string k in array)
                {
                    array[count] = k.ToLower();
                    count++;
                }

                Entrees = Entrees.Where(entree => Entrees.ToString() != null && (entree.ToString().Contains(SearchTerms, StringComparison.OrdinalIgnoreCase) || array.Any(entree.Description.ToLower().Contains)));
                Sides = Sides.Where(side => Sides.ToString() != null && (side.ToString().Contains(SearchTerms, StringComparison.OrdinalIgnoreCase) || array.Any(side.Description.ToLower().Contains)));
                Drinks = Drinks.Where(drink => Drinks.ToString() != null && (drink.ToString().Contains(SearchTerms, StringComparison.OrdinalIgnoreCase) || array.Any(drink.Description.ToLower().Contains)));


            }

            if(Category.Count() != 0)
            {
                bool[] cont = new bool[3];

                foreach(string item in Category)
                {
                    switch (item)
                    {
                        case "Entree":
                            cont[0] = true;
                            break;
                        case "Side":
                            cont[1] = true;
                            break;
                        case "Drink":
                            cont[2] = true;
                            break;
                    }
                }
                if (!cont[0])
                {
                    Entrees = new List<IOrderItem>();
                }
                if (!cont[1])
                {
                    Sides = new List<IOrderItem>();
                }
                if (!cont[2])
                {
                    Drinks = new List<IOrderItem>();
                }
            }

            ///?PriceMin=0&PriceMax=1&Category=Side&CalorieMin=0&CalorieMax=100&SearchTerms=vokun

            if (CalorieMin != null && CalorieMax == null)
            {
                Entrees = Entrees.Where(entree => entree.Calories >= CalorieMin);
                Sides = Sides.Where(side => side.Calories >= CalorieMin);
                Drinks = Drinks.Where(drink => drink.Calories >= CalorieMin);
            }

            if (CalorieMin == null && CalorieMax != null)
            {
                Entrees = Entrees.Where(entree => entree.Calories <= CalorieMax);
                Sides = Sides.Where(side => side.Calories <= CalorieMax);
                Drinks = Drinks.Where(drink => drink.Calories <= CalorieMax);
            }

            if (CalorieMin != null && CalorieMax != null)
            {
                Entrees = Entrees.Where(entree => entree.Calories >= CalorieMin && entree.Calories <= CalorieMax);
                Sides = Sides.Where(side => side.Calories >= CalorieMin && side.Calories <= CalorieMax);
                Drinks = Drinks.Where(drink => drink.Calories >= CalorieMin && drink.Calories <= CalorieMax);
            }

            if (PriceMin != null && PriceMax == null)
            {
                Entrees = Entrees.Where(entree => entree.Price >= PriceMin);
                Sides = Sides.Where(side => side.Price >= PriceMin);
                Drinks = Drinks.Where(drink => drink.Price >= PriceMin);
            }

            if (PriceMin == null && PriceMax != null)
            {
                Entrees = Entrees.Where(entree => entree.Price <= PriceMax);
                Sides = Sides.Where(side => side.Price <= PriceMax);
                Drinks = Drinks.Where(drink => drink.Price <= PriceMax);
            }

            if (PriceMin != null && PriceMax != null)
            {
                Entrees = Entrees.Where(entree => entree.Price >= PriceMin && entree.Price <= PriceMax);
                Sides = Sides.Where(side => side.Price >= PriceMin && side.Price <= PriceMax);
                Drinks = Drinks.Where(drink => drink.Price >= PriceMin && drink.Price <= PriceMax);
            }

            Entrees = Entrees.ToList();
            Sides = Sides.ToList();
            Drinks = Drinks.ToList();

            /*
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
            Drinks = Menu.FilterByPrice(Drinks, PriceMin, PriceMax);*/
        }
    }
}
