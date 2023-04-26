// See https://aka.ms/new-console-template for more information
using System;

namespace RecipeApplication
{
    // variables
    class ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        //Addding names on variable
        public ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }

    class Steps
    {
        public string Description { get; set; }

        public Steps(string description)
        {
            Description = description;
        }
    }
    //used array to display the ingredient and steps
    class DisplayingRecipe
    {

        private Ingredient[] ingredients;
        private Step[] steps;

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<string> Steps { get; set; } = new List<string>();

        //used loop to display ingredient
        public DisplayingRecipe()
        {
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            ingredients = new Ingredient[numIngredients];

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter the name of ingredient {i + 1}: ");
                string name = Console.ReadLine();

                Console.Write($"Enter the quantity of {name}: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write($"Enter the unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                ingredients[i] = new Ingredient(name, quantity, unit);
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            steps = new Step[numSteps];

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter the description for step {i + 1}: ");
                string description = Console.ReadLine();

                steps[i] = new Step(description);
            }
        }
        // Method to display ingredient details
        public void Display()
        {
            Console.WriteLine("Ingredients:");

            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
            }

            Console.WriteLine("Steps:");

            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i].Description}");
            }
        }

        public void Scale(double factor)
        {
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }
        // Method to reset ingredient quantities to original values
        public void Reset()
        {
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Quantity /= 2;
            }
        }
        // Method to clear all data to enter a new recipe
        public void Clear()
        {
            Array.Clear(ingredients, 0, ingredients.Length);
            Array.Clear(steps, 0, steps.Length);
        }
    }
    //used while loop to enter multiple statements
    //
    class program
    {
        public static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Display recipe");
                Console.WriteLine("2. Scale recipe");
                Console.WriteLine("3. Reset quantities");
                Console.WriteLine("4. Clear recipe");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipe.Display();
                        break;
                    case 2:
                        Console.Write("Enter scaling factor: ");
                        double factor = double.Parse(Console.ReadLine());
                        recipe.Scale(factor);
                        break;
                    case 3:
                        recipe.Reset();
                        break;
                    case 4:
                        recipe.Clear();
                        recipe = new Recipe();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
} 


