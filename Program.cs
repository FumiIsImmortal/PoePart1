
using System; 

namespace PoePart1 
{
    class RecipeIngredient 
    {
        public string IngredientName { get; set; } // Property to store the name of the ingredient
        public double Quantity { get; set; } // Property to store the quantity of the ingredient
        public string MeasurementUnit { get; set; } // Property to store the measurement unit of the ingredient
    }

    class RecipeStep 
    {
        public string Description { get; set; } // Property to store the description of the step
    }

    class Recipe 
    {
        private RecipeIngredient[] Ingredients { get; set; } // Array to store recipe ingredients
        private RecipeStep[] Steps { get; set; } // Array to store recipe steps

        // Method to display the recipe
        public void DisplayRecipe()
        {
            // Checking if ingredients are available
            if (Ingredients != null && Ingredients.Length > 0)
            {
                Console.WriteLine("Recipe Ingredients:");
                // Looping through each ingredient and displaying its details
                foreach (var ingredient in Ingredients)
                {
                    Console.WriteLine($"{ingredient.Quantity} {ingredient.MeasurementUnit} of {ingredient.IngredientName}");
                }
            }
            else
            {
                Console.WriteLine("No ingredients available.");
            }

            // Checking if steps are available
            if (Steps != null && Steps.Length > 0)
            {
                Console.WriteLine("\nRecipe Steps:");


                // Looping through each step and displaying its description
                for (int i = 0; i < Steps.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Steps[i].Description}");
                }
            }
            else
            {
                Console.WriteLine("No steps available.");
            }
        }

        // Method to scale the recipe by a factor
        public void ScaleRecipe(double factor)
        {
            if (Ingredients != null)
            {
                foreach (var ingredient in Ingredients)
                {
                    ingredient.Quantity *= factor;
                }
            }
        }

        // Method to reset ingredient quantities
        public void ResetQuantities()
        {
            if (Ingredients != null)
            {
                foreach (var ingredient in Ingredients)
                {
                    ingredient.Quantity /= 2;
                }
            }
        }

        // Method to clear the recipe
        public void ClearRecipe()
        {
            Ingredients = null;
            Steps = null;
        }


        // Method to enter recipe details
        public void EnterRecipeDetails()
        {
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());
            Ingredients = new RecipeIngredient[numIngredients];


            // Looping to input details for each ingredient
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter the name of ingredient {i + 1}: ");
                string name = Console.ReadLine();
                Console.Write($"Enter the quantity of {name}: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write($"Enter the unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                Ingredients[i] = new RecipeIngredient { IngredientName = name, Quantity = quantity, MeasurementUnit = unit };
            }

            Console.Write("\nEnter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());
            Steps = new RecipeStep[numSteps];


            // Looping to input details for each step
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string description = Console.ReadLine();
                Steps[i] = new RecipeStep { Description = description };
            }
        }
    }

    class Program // Main class containing the entry point of the program
    {
        static void Main(string[] args) // Main method
        {
            Recipe userRecipe = new Recipe(); // Creating an instance of Recipe class

            // Looping infinitely to interact with the user
            while (true)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Enter '1' to enter recipe details");
                Console.WriteLine("Enter '2' to display recipe");
                Console.WriteLine("Enter '3' to scale recipe");
                Console.WriteLine("Enter '4' to reset quantities");
                Console.WriteLine("Enter '5' to clear recipe");
                Console.WriteLine("Enter '6' to exit");
                Console.WriteLine("-----------------------------------");

                string choice = Console.ReadLine(); // Reading user's choice
                Console.WriteLine();

                // Switch statement to handle user's choice
                switch (choice)
                {
                    case "1":
                        userRecipe.EnterRecipeDetails(); // Call method to enter recipe details
                        break;
                    case "2":
                        userRecipe.DisplayRecipe(); // Call method to display recipe
                        break;
                    case "3":
                        Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                        double scaleFactor = double.Parse(Console.ReadLine());
                        userRecipe.ScaleRecipe(scaleFactor); // Call method to scale recipe
                        Console.WriteLine("\nScaled Recipe:");
                        userRecipe.DisplayRecipe(); // Display the scaled recipe
                        break;
                    case "4":
                        userRecipe.ResetQuantities(); // Call method to reset ingredient quantities
                        Console.WriteLine("\nOriginal Recipe after Reset:");
                        userRecipe.DisplayRecipe(); // Display the original recipe after reset
                        break;
                    case "5":
                        userRecipe.ClearRecipe(); // Call method to clear the recipe
                        Console.WriteLine("\nRecipe data cleared. You can enter a new recipe.");
                        break;
                    case "6":
                        Environment.Exit(0); // Exit the program
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid choice.");
                        break;
                }
            }
        }
    }
}

