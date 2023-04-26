// See https://aka.ms/new-console-template for more information
using System;

namespace RecipeApplication
{
    class Ingredient
    {//varible
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        
        //storing names on varibles
        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }

    class Step
    {
        public string Description { get; set; }

        public Step(string description)
        {
            Description = description;
        }
    }

    class Recipe
    {
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<string> Steps { get; set; } = new List<string>();


        public Recipe()
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

        public void Reset()
        {
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Quantity /= 2;
            }
        }

        public void Clear()
        {
            Array.Clear(ingredients, 0, ingredients.Length);
            Array.Clear(steps, 0, steps.Length);
        }
    }

    class Program
    {
        static void Main(string[] args)
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


