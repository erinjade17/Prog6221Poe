# Prog6221Poe
RecipeApp - README
Overview
RecipeApp is a Windows Presentation Foundation (WPF) application that allows users to manage recipes. Users can add, display, list, scale, revert, clear recipes, and show a pie chart of food group percentages in the recipes. This project utilizes C# and follows the principles and practices outlined in "Pro C# 10 with .NET 6" by Andrew Troelsen & Phil Japikse.
Features
1.	Add Recipe: Allows users to add a new recipe by entering details such as ingredients, their quantities, and steps.
2.	Display Recipe: Displays the details of a specified recipe.
3.	List Recipes: Lists all the recipes available.
4.	Scale Recipe: Scales the ingredients of a recipe by a given factor.
5.	Revert Recipe: Reverts the ingredients of a recipe to their original quantities.
6.	Clear Recipe: Removes a specified recipe from the recipe book.
7.	Show Pie Chart: Displays a pie chart showing the percentage of food groups in all recipes.
Project Structure
The project is divided into several parts:
1.	Models: Contains the business logic and data structures for recipes and ingredients.
2.	Views: WPF windows and user interfaces, including the main window and input dialogs.
3.	Controllers: Handles the user interactions and updates the views accordingly.
File Descriptions
•	MainWindow.xaml: The main interface of the application where users can interact with the recipe management functions.
•	MainWindow.xaml.cs: The code-behind for MainWindow.xaml, handling event logic for the UI elements.
•	InputDialog.xaml: A simple dialog window to prompt the user for input.
•	InputDialog.xaml.cs: The code-behind for InputDialog.xaml, handling the logic for user input.
•	PieChartWindow.xaml: A window to display the pie chart of food group percentages.
•	PieChartWindow.xaml.cs: The code-behind for PieChartWindow.xaml, managing the pie chart display.
•	Recipe.cs: Defines the Recipe class, which holds the recipe details.
•	Ingredient.cs: Defines the Ingredient class, which holds the ingredient details.
•	Methods.cs: Contains methods to manage recipes, including adding, displaying, listing, scaling, reverting, and clearing recipes.
Usage
Prerequisites
•	Visual Studio or any C# IDE.
•	.NET 6 SDK.
•	LiveCharts.Wpf library for displaying pie charts.
Running the Application
1.	Clone or download the repository.
2.	Open the solution in Visual Studio.
3.	Restore the NuGet packages, if necessary.
4.	Build and run the application.
Adding a Recipe
1.	Click on the "Add Recipe" button.
2.	Follow the prompts to enter the recipe name, ingredients, and steps.
Displaying a Recipe
1.	Click on the "Display Recipe" button.
2.	Enter the name of the recipe you want to display.
Listing All Recipes
1.	Click on the "List All Recipes" button.
Scaling a Recipe
1.	Click on the "Scale Recipe" button.
2.	Enter the name of the recipe you want to scale and the scaling factor.
Reverting a Recipe
1.	Click on the "Revert Recipe" button.
2.	Enter the name of the recipe you want to revert.
Clearing a Recipe
1.	Click on the "Clear Recipe" button.
2.	Enter the name of the recipe you want to clear.
Showing Pie Chart
1.	Click on the "Show Pie Chart" button to display the pie chart of food group percentages.
References
•	Book: "Pro C# 10 with .NET 6: Foundational Principles and Practices in Programming Eleventh Edition" by Andrew Troelsen & Phil Japikse.
Author
Erin Jade Naidoo (ST10081245)
License
This project is licensed under the MIT License - see the LICENSE file for details.
