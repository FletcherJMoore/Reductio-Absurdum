// See https://aka.ms/new-console-template for more information

using System.Numerics;

List<Product> products = new List<Product>()
{
new Product()
{
    Name = "Playing Cards",
    Price = 20.00M,
    Sold = false,
    ProductTypeId = 1,
    DateStocked = new DateTime(2024, 7, 5)
    },

new Product()
{
    Name = "Harry Potter Wand",
    Price = 100.00M,
    Sold = true,
    ProductTypeId = 2,
    DateStocked = new DateTime(2020, 1, 7)
},

new Product()
{
    Name = "Book of Spells",
    Price = 50.00M,
    Sold = true,
    ProductTypeId = 3,
    DateStocked = new DateTime(2024, 4, 15)
},

new Product()
{
    Name = "Potion of Swiftness",
    Price = 30.00M,
    Sold = false,
    ProductTypeId = 4,
    DateStocked = new DateTime(2021, 5, 30)
},
};

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Name = "Wand",
        Id = 1
    },

    new ProductType()
    {
       Name = "Apparel",
       Id = 2
    },

     new ProductType()
    {
       Name = "Enchanted Objects",
       Id = 3
    },

      new ProductType()
    {
       Name = "Potions",
       Id = 4
    }
};

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
    0. Exit
    1. Add Product 
    2. Delete Product 
    3. Update Product
    4. Seach Product
    5. View Products");

    choice = Console.ReadLine();
    {
        if (choice == "0")
        {
            Console.WriteLine("Goodbye!");
        }
        else if (choice == "1")
        {
            AddProduct();
        }
        else if (choice == "2")
        {
            DeleteProduct();
        }
        else if (choice == "3")
        {
            UpdateProduct();
        }
        else if (choice == "4")
        {
            SearchProduct();
        }
        else if (choice == "5") 
        {
            ViewProducts();
        }
    }

    void ViewProducts()
    {
        ListProducts();

        Product chosenProduct = null;

        while (chosenProduct == null)
        {
            Console.WriteLine("Please enter a plant number: ");
            try
            {
                int response = int.Parse(Console.ReadLine().Trim());
                chosenProduct = products[response - 1];
            }
            catch (FormatException)
            {
                Console.WriteLine("Please choose an existing item only!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Please choose an existing item only!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Do Better!");
            }
        }

        Console.WriteLine(@$"A {chosenProduct.Name} {(chosenProduct.Sold ? "was sold" : "is available")} for {chosenProduct.Price} ");
    }
}
void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Plants:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}
void AddProduct()
    {
        Console.WriteLine("Add a new product!");

        Console.WriteLine("Enter product name");
        string name = Console.ReadLine()!;

        Console.WriteLine("Enter product price");
        decimal price = decimal.Parse(Console.ReadLine()!.Trim());

        Console.WriteLine(@"Select a product type:
         1. Wands 
         2. Apparel 
         3. Enchanted Objects
         4. Potions");
        int productId = int.Parse(Console.ReadLine()!.Trim());


        Product product = new Product
        {
            Name = name,
            Price = price,
            ProductTypeId = productId,
        };

    products.Add(product);

    Console.WriteLine("Product has been posted!");
    }

    void DeleteProduct()
    {
        Console.WriteLine("Products up for sale.");

        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i].Name}");
        }

        Product RemoveProduct = null!;
        while (RemoveProduct == null)
        {
            Console.WriteLine("Choose the number of the product you would like removed.");
            try
            {
                int response = int.Parse(Console.ReadLine()!.Trim());
                RemoveProduct = products[response - 1];
            }
            catch (FormatException)
            {
                Console.WriteLine("Please choose an existing item only!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Please choose an existing item only!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Do Better!");
            }

        }
        products.Remove(RemoveProduct);
        Console.WriteLine($"You have successfully removed {RemoveProduct.Name}!");
    } 

void UpdateProduct()
{
    Console.WriteLine("Please select product to update:");
    Console.WriteLine("Products:");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());

            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do better!");
        }

        Console.WriteLine(@"Please choose a field to edit:
        0. Name
        1. Price
        2. Available
        3. Product Type ID");

        int index = products.IndexOf(chosenProduct);

        int choice = int.Parse(Console.ReadLine());
        if (choice == 0)
        {
            Console.WriteLine("Please enter new name");
            string newName = Console.ReadLine();
            products[index].Name = newName;
        }
        else if (choice == 1)
        {
            Console.WriteLine("Please enter new price");
            decimal newPrice = Convert.ToDecimal(Console.ReadLine());
            products[index].Price = newPrice;

        }
        else if (choice == 2)
        {
            Console.WriteLine(@"Please select an option:
        0. Sold
        1. Available");

            int newChoice = int.Parse(Console.ReadLine());

            if (newChoice == 0)
            {
                products[index].Sold = false;
            }
            else if (newChoice == 1)
            {
                products[index].Sold = true;
            }

        }
        else if (choice == 3)
        {
            Console.WriteLine(@"Please enter new Product Type ID:
           0. Potions
           1. Apparel
           2. Enchanted Objects
           3. Wands");

            int newID = int.Parse(Console.ReadLine());
            products[index].ProductTypeId = newID;
        }

    }
}
void SearchProduct()
{
    Console.WriteLine(@"Please select a product type ID:
    0. Potions
    1. Apparel
    2. Enchanted Objects
    3. Wands");

    int response = int.Parse(Console.ReadLine());

    List<Product> filteredProducts = products.FindAll(x => x.ProductTypeId == response);

    foreach (Product product in filteredProducts)
    {
        Console.WriteLine($"{product.Name}");
    }
    filteredProducts.Clear();
} 


      