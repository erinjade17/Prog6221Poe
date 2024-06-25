using System.Windows;

/**
 *
 * @author Erin Jade Naidoo (ST10081245)
 */

// references
// code attribution
// Book Author: Andrew Troelsen & Phil Japikse
// Book Title: Pro C# 10 with .NET 6 Foundational Principles and Practices in Programming Eleventh Edition (prescribed textbook)

namespace RecipeAppWPF
{
    // The InputDialog class represents a window that asks the user a question and gets an answer.
    public partial class InputDialog : Window
    {
        // Property to store the user's answer
        public string Answer { get; private set; }

        // Constructor that takes a question to display in the dialog
        public InputDialog(string question)
        {
            InitializeComponent(); // Initializes the components defined in the XAML file
            PromptTextBlock.Text = question; // Sets the question text in the TextBlock
        }

        // Event handler for the OK button click event
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Answer = InputTextBox.Text; // Gets the text entered by the user
            DialogResult = true; // Sets the dialog result to true, indicating that the user confirmed
        }

        // Event handler for the Cancel button click event
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Sets the dialog result to false, indicating that the user canceled
        }
    }
}
