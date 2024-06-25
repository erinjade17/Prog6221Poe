using RecipeAppGUI;
using RecipeAppWPF;
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
    public class Methods
    {
        private Dictionary<string, Recipe> RecipeBook = new Dictionary<string, Recipe>();

        public delegate void CalorieNotification(string message);
        public event CalorieNotification NotifyHighCalories;

        public Methods()
        {
            NotifyHighCalories += message => Console.WriteLine(message);
        }

        public void RecipePrompts(Action<string> callback)
        {
            var inputDialog = new InputDialog("Enter Recipe name:");
            if (inputDialog.ShowDialog() == true)
            {
                string recipeName = inputDialog.Answer;
                if (!RecipeBook.ContainsKey(recipeName))
                {
                    var recipe = new Recipe { Name = recipeName };

                    // Prompt for number of ingredients
                    inputDialog = new InputDialog("Enter number of ingredients:");
                    if (inputDialog.ShowDialog() == true && int.TryParse(inputDialog.Answer, out int numIngredients))
                    {
                        for (int i = 0; i < numIngredients; i++)
                        {
                            // Prompt for each ingredient details
                            var ingredientNameDialog = new InputDialog($"Enter ingredient {i + 1} name:");
                            if (ingredientNameDialog.ShowDialog() == true)
                            {
                                string ingredientName = ingredientNameDialog.Answer;

                                var quantityDialog = new InputDialog($"Enter quantity for {ingredientName}:");
                                if (quantityDialog.ShowDialog() == true && double.TryParse(quantityDialog.Answer, out double quantity))
                                {
                                    var unitDialog = new InputDialog($"Enter unit for {ingredientName}:");
                                    if (unitDialog.ShowDialog() == true)
                                    {
                                        string unit = unitDialog.Answer;

                                        var caloriesDialog = new InputDialog($"Enter calories for {ingredientName} per unit:");
                                        if (caloriesDialog.ShowDialog() == true && double.TryParse(caloriesDialog.Answer, out double calories))
                                        {
                                            var foodGroupDialog = new InputDialog($"Enter food group for {ingredientName}:");
                                            if (foodGroupDialog.ShowDialog() == true)
                                            {
                                                string foodGroup = foodGroupDialog.Answer;

                                                var ingredient = new Ingredient
                                                {
                                                    Name = ingredientName.Trim(),
                                                    Quantity = quantity,
                                                    Unit = unit.Trim(),
                                                    Calories = calories,
                                                    FoodGroup = foodGroup.Trim()
                                                };
                                                recipe.Ingredients.Add(ingredient);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Prompt for number of steps
                    inputDialog = new InputDialog("Enter number of steps:");
                    if (inputDialog.ShowDialog() == true && int.TryParse(inputDialog.Answer, out int numSteps))
                    {
                        for (int i = 0; i < numSteps; i++)
                        {
                            var stepDialog = new InputDialog($"Enter step {i + 1}:");
                            if (stepDialog.ShowDialog() == true)
                            {
                                recipe.Steps.Add(stepDialog.Answer);
                            }
                        }
                    }

                    RecipeBook[recipeName] = recipe;
                    callback?.Invoke($"Recipe {recipeName} added.");
                }
                else
                {
                    callback?.Invoke($"Recipe {recipeName} already exists.");
                }
            }
        }

        public void DisplayRecipe(string recipeName, Action<string> displayAction)
        {
            if (RecipeBook.TryGetValue(recipeName, out Recipe recipe))
            {
                displayAction($"Recipe Name: {recipe.Name}\n");

                displayAction("Ingredients:");
                foreach (var ingredient in recipe.Ingredients)
                {
                    displayAction($"- {ingredient.Name}: {ingredient.Quantity} {ingredient.Unit} ({ingredient.Calories} calories), Food Group: {ingredient.FoodGroup}");
                }

                displayAction($"\nTotal Calories: {recipe.TotalCalories}\n");

                displayAction("Steps:");
                for (int i = 0; i < recipe.Steps.Count; i++)
                {
                    displayAction($"{i + 1}. {recipe.Steps[i]}\n");
                }
            }
            else
            {
                displayAction("Recipe not found.");
            }
        }

        public void ListRecipes(Action<string> listAction)
        {
            foreach (var recipeName in new SortedSet<string>(RecipeBook.Keys))
            {
                listAction(recipeName);
            }
        }

        public void ScaleRecipe(string recipeName, double scale, Action<string> displayAction)
        {
            if (RecipeBook.TryGetValue(recipeName, out Recipe recipe))
            {
                recipe.Scale(scale);
                CheckCalories(recipe);
                displayAction($"Recipe {recipeName} scaled. New details:\n");
                DisplayRecipe(recipeName, displayAction);
            }
            else
            {
                displayAction("Recipe not found.");
            }
        }

        public void RevertRecipe(string recipeName, Action<string> displayAction)
        {
            if (RecipeBook.TryGetValue(recipeName, out Recipe recipe))
            {
                recipe.Revert();
                displayAction($"Recipe {recipeName} reverted to original details:\n");
                DisplayRecipe(recipeName, displayAction);
            }
            else
            {
                displayAction("Recipe not found.");
            }
        }

        public void ClearRecipe(string recipeName, Action<string> displayAction)
        {
            if (RecipeBook.Remove(recipeName))
            {
                displayAction($"Recipe {recipeName} removed.");
            }
            else
            {
                displayAction("Recipe not found.");
            }
        }

        private void CheckCalories(Recipe recipe)
        {
            if (recipe.TotalCalories > 300)
            {
                NotifyHighCalories?.Invoke($"The recipe {recipe.Name} has {recipe.TotalCalories} calories.");
            }
        }

        public Dictionary<string, double> CalculateFoodGroupPercentages()
        {
            var foodGroupTotals = new Dictionary<string, double>();
            double totalQuantity = 0;

            foreach (var recipe in RecipeBook.Values)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    if (foodGroupTotals.ContainsKey(ingredient.FoodGroup))
                    {
                        foodGroupTotals[ingredient.FoodGroup] += ingredient.Quantity;
                    }
                    else
                    {
                        foodGroupTotals[ingredient.FoodGroup] = ingredient.Quantity;
                    }
                    totalQuantity += ingredient.Quantity;
                }
            }

            var foodGroupPercentages = new Dictionary<string, double>();
            foreach (var kvp in foodGroupTotals)
            {
                foodGroupPercentages[kvp.Key] = (kvp.Value / totalQuantity) * 100;
            }

            return foodGroupPercentages;
        }
    }
}
