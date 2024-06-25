
/**
 *
 * @author Erin Jade Naidoo(ST10081245)
 */

//references
//code attribution
//Book Author: Andrew Troelsen & Phil Japikse
//Book Title: Pro C# 10 with.NET 6 Foundational Principles and Practices in Programming Eleventh Edition (prescribed textbook)

namespace RecipeApp.Models
{
    public class Ingredient
    {
        //Getters and Setters
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

        public Ingredient() { }

        public Ingredient(Ingredient ingredient)
        {
            Name = ingredient.Name;
            Quantity = ingredient.Quantity;
            Unit = ingredient.Unit;
            Calories = ingredient.Calories;
            FoodGroup = ingredient.FoodGroup;
        }
    }
}