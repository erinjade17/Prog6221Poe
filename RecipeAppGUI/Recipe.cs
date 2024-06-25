using RecipeAppGUI;
using System;
using System.Collections.Generic;
using System.Linq;

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
    public class Recipe
    {
        // Property to store the name of the recipe
        public string Name { get; set; }

        // List to store the ingredients of the recipe
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        // List to store the steps of the recipe
        public List<string> Steps { get; set; } = new List<string>();

        // Private list to store the original ingredients for scaling purposes
        private List<Ingredient> OriginalIngredients { get; set; }

        // Property to calculate the total calories of the recipe
        public double TotalCalories => Ingredients.Sum(i => i.Calories * i.Quantity);

        // Method to scale the quantities of the ingredients by a given factor
        public void Scale(double factor)
        {
            // Save the original ingredients if not already saved
            if (OriginalIngredients == null)
            {
                OriginalIngredients = Ingredients.Select(i => new Ingredient(i)).ToList();
            }

            // Scale each ingredient's quantity by the factor
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        // Method to revert the ingredients to their original quantities
        public void Revert()
        {
            // Revert to original ingredients if they exist
            if (OriginalIngredients != null)
            {
                Ingredients = OriginalIngredients;
                OriginalIngredients = null;
            }
        }

        // Override ToString method to provide a formatted string representation of the recipe
        public override string ToString()
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine($"Recipe: {Name}");
            result.AppendLine("Ingredients:");

            // Append each ingredient's details to the result string
            foreach (var ingredient in Ingredients)
            {
                result.AppendLine($"{ingredient.Name}, {ingredient.Quantity} {ingredient.Unit}, {ingredient.Calories} calories/unit");
            }

            result.AppendLine("Steps:");

            // Append each step to the result string
            for (int i = 0; i < Steps.Count; i++)
            {
                result.AppendLine($"{i + 1}. {Steps[i]}");
            }

            // Append the total calories to the result string
            result.AppendLine($"Total Calories: {TotalCalories}");
            return result.ToString();
        }
    }
}
