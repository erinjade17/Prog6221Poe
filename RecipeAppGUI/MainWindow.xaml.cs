using RecipeApp.Models; // Reference to the Models namespace containing the Methods class
using System;
using System.Windows;

// Author: Erin Jade Naidoo(ST10081245)

// References and Code Attribution
// Book Author: Andrew Troelsen & Phil Japikse
// Book Title: Pro C# 10 with .NET 6 Foundational Principles and Practices in Programming Eleventh Edition (prescribed textbook)

namespace RecipeAppWPF
{
    public partial class MainWindow : Window
    {
        // Instance of Methods class to handle recipe-related operations
        private Methods recipeMethods = new Methods();

        public MainWindow()
        {
            InitializeComponent(); // Initialize the components defined in the XAML file
        }

        // Event handler for Add Recipe button click
        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Call RecipePrompts method from recipeMethods and add the recipe
            recipeMethods.RecipePrompts(AddRecipe);
        }

        // Event handler for Display Recipe button click
        private void DisplayRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Prompt the user to enter the recipe name to display
            string recipeName = PromptForInput("Enter the Recipe name to display:");
            OutputTextBox.Text = string.Empty; // Clear the output text box
            // Call DisplayRecipe method and update the OutputTextBox with the recipe details
            recipeMethods.DisplayRecipe(recipeName, (message) => OutputTextBox.Text += message + "\n");
        }

        // Event handler for List Recipes button click
        private void ListRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = "Recipes:\n"; // Initialize the output text box with a header
            // Call ListRecipes method and list all recipes in the OutputTextBox
            recipeMethods.ListRecipes((recipeName) => OutputTextBox.Text += recipeName + "\n");
        }

        // Event handler for Scale Recipe button click
        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Prompt the user to enter the recipe name to scale
            string recipeName = PromptForInput("Enter the Recipe name to scale:");
            // Prompt the user to enter the scaling factor
            string scaleInput = PromptForInput("Enter scaling factor (e.g., 0.5, 2, 3):");
            if (double.TryParse(scaleInput, out double scale))
            {
                // Call ScaleRecipe method and update the OutputTextBox with the scaled recipe details
                recipeMethods.ScaleRecipe(recipeName, scale, (message) => OutputTextBox.Text += message + "\n");
            }
            else
            {
                // Show a message box if the scaling factor is invalid
                MessageBox.Show("Invalid scaling factor.");
            }
        }

        // Event handler for Revert Recipe button click
        private void RevertRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Prompt the user to enter the recipe name to revert
            string recipeName = PromptForInput("Enter the Recipe name to revert:");
            // Call RevertRecipe method and update the OutputTextBox with the reverted recipe details
            recipeMethods.RevertRecipe(recipeName, (message) => OutputTextBox.Text += message + "\n");
        }

        // Event handler for Clear Recipe button click
        private void ClearRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Prompt the user to enter the recipe name to clear
            string recipeName = PromptForInput("Enter the Recipe name to clear:");
            // Call ClearRecipe method and update the OutputTextBox with the cleared recipe details
            recipeMethods.ClearRecipe(recipeName, (message) => OutputTextBox.Text += message + "\n");
        }

        // Event handler for Show Pie Chart button click
        private void ShowPieChartButton_Click(object sender, RoutedEventArgs e)
        {
            // Calculate the percentages of food groups in the recipes
            var foodGroupPercentages = recipeMethods.CalculateFoodGroupPercentages();
            // Show the pie chart with the calculated percentages
            ShowPieChart(foodGroupPercentages);
        }

        // Helper method to prompt the user for input using a custom input dialog
        private string PromptForInput(string message)
        {
            InputDialog inputDialog = new InputDialog(message);
            if (inputDialog.ShowDialog() == true)
            {
                return inputDialog.Answer; // Return the user's input if the dialog result is true
            }
            return string.Empty; // Return an empty string if the dialog result is false
        }

        // Callback method to add the recipe message to the OutputTextBox
        private void AddRecipe(string message)
        {
            OutputTextBox.Text += message + "\n";
        }

        // Helper method to show the pie chart in a new window
        private void ShowPieChart(Dictionary<string, double> foodGroupPercentages)
        {
            var pieChartWindow = new PieChartWindow(foodGroupPercentages);
            pieChartWindow.Show(); // Show the pie chart window
        }
    }
}
