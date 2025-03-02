﻿// REVIEW Using : Import
using System;
using System.Collections.Generic;
using System.Threading;
using csharp_day_1.Models;

// NOTE Allow accesss to all other peices of code within the namespace, a way of grouping our code (filesystem)
namespace csharp_day_1
{
  // REVIEW Class : Class
  class Program
  {
    // REVIEW Method : Method
    // access modifier, return type, name, parameters
    static void Main(string[] args)
    {
      Console.Clear();
      Shelter myShelter = new Shelter();
      myShelter.AddPet(new Cat("Garfield", 5));
      myShelter.AddPet(new Cat("Felix", 3));
      myShelter.AddPet(new Cat("Mr. Snibbley", 105));
      myShelter.AddPet(new Cat("Sylvester", 1));
      myShelter.AddPet(new Dog("Fido"));
      myShelter.AddPet(new Dog("Spot"));
      myShelter.AddPet(new Dog("Clifford"));
      PrintAnimals(myShelter);
      // game logic loop
      bool adopting = true;
      while (adopting)
      {

        Console.WriteLine("\nWhat type of animal do you wish to adopt? (cat or dog)");
        string type = Console.ReadLine().ToLower();
        Console.WriteLine("Which one?");
        string name = Console.ReadLine().ToLower();
        if (type == "cat")
        {
          Cat c = myShelter.Cats.Find(c => c.Name.ToLower() == name);
          if (c == null)
          {
            Console.WriteLine("Sorry we don't have a Cat by that name");
          }
          else
          {
            Console.WriteLine(myShelter.Adopt(c));
            Console.WriteLine("Would you like to adopt another? (y/n)");
            var choice = Console.ReadKey().KeyChar;
            if (choice == 'n')
            {
              adopting = false;
            }
            else
            {
              Console.Clear();
              PrintAnimals(myShelter);
            }
          }
        }
        else if (type == "dog") { }
        else
        {
          Console.WriteLine("Sorry you must choose 'cat' or 'dog'");
        }
      }

    }

    private static void PrintAnimals(Shelter myShelter)
    {
      Console.WriteLine("Cats: ");
      for (int i = 0; i < myShelter.Cats.Count; i++)
      {
        Cat c = myShelter.Cats[i];
        Console.WriteLine(c.Name);
      }
      Console.WriteLine("\n");
      Console.WriteLine("Dogs: ");
      for (int i = 0; i < myShelter.Dogs.Count; i++)
      {
        Dog d = myShelter.Dogs[i];
        Console.WriteLine(d.Name);
      }
    }

    private static void starterCode()
    {
      // REVIEW Console.WriteLine (cw + tab ) : console.log
      //   Console.WriteLine("Hello World!");

      // SECTION Variables
      // let, const, var
      // implicit typing var (The variable type is implied by the set value)
      var x = "Hello";
      var z = 'a';
      var z2 = "a";
      // explicit typing uses the type as the varialbe declaration (does not require value assignment on initalization)
      string y = "World";
      char y2;

      // SECTION Strings
      // #region       //    REVIEW Concatenation : Concatenation
      string myString = x + " " + y;
      //    NOTE Interpolation : INterpolation (start stirng with $ to use variables in {})
      string myString2 = $"{x} {y}";
      //    alternate way to use interpolation 
      string myString3 = $"{0}, {1}";
      //   Console.WriteLine(myString3, x, y);
      //    the @ symbol allows for line breaks 
      string myString4 = @"
Hello World
      ";
      //   Console.WriteLine(myString4);


      // SECTION Console
      Console.Clear();
      // NOTE ReadLine gets input from the console
      Console.WriteLine("Hello What is your name?");
      Console.Write("Name: ");
      string name = Console.ReadLine();
      Console.WriteLine("Hello " + name);
      // color
      Console.ForegroundColor = ConsoleColor.Red;
      Console.BackgroundColor = ConsoleColor.Blue;
      Console.Clear();
      Console.WriteLine("It's a Me");
      Console.WriteLine(@"
       ------------
     /  (_)_   _    \
  /)      (_) (_)      \
 |       _          _   |
| _     (_)   _    (_) _ |
|(_)  _      (_)  _   (_)|
|____(_)_________(_)_____|
 \\\\\\\\\||||||||///////
          |      |
          |      |
          |      |
           \____/
      ");
      Thread.Sleep(1000);
      Console.ResetColor();
      Console.Clear();

      // SECTION Numbers
      // Number : Int, Float, Decimal
      // INT (Whole numbers), Float (decimals)
      // var num = 1.3;
      // double is denoted with a 'd'
      double num = 1.34;
      // float is denoted with 'f'
      float floatNum = 2.3f;
      // decimal is denoted with 'm'
      decimal bigNum = 32.434m;

      // SECTION Conditionals
      // (if, else if, else, switches) : (if, else if, else, switches)
      // === : == (there is no ===)
      // No 'Truthy'/'Falsey', No 'Undefined', No 'NaN'
      // Number Types are not 'nullable' meaning they will always have a value of at least 0
      if (num != null)
      {
        // do thing
      }

      // SECTION Arrays
      // Arrays : Arrays (Arrays are not as flexible in C# as in JS)
      String[] cats = new String[3];
      cats[0] = "Garfield";
      cats[1] = "Mr. Snibbley";
      cats[0] = null;
      // C# Alternative List
      // List<Type> (use Collections.Generic)
      // Must be instatiated
      // can use {} to add values at initalization
      List<String> catsList = new List<string>() { "Garfield", "Nermal" };
      // push : Add
      catsList.Add("Felix");
      // add at position
      catsList.Insert(0, "Heathcliff");
      // find : Find


      // SECTION Dictionary
      // {} : Dictionary (Do not us POCO )
      // Dictionry<KeyType, ValueType>
      Dictionary<String, int> studentIds = new Dictionary<String, int>();
      studentIds.Add("jimmy", 23);


      Console.WriteLine("Jimmy ID: " + studentIds["jimmy"]);
      // DANGER ZONE!
      if (studentIds.ContainsKey("tommy"))
      {
        Console.WriteLine("Tommy ID: " + studentIds["tommy"]);
      }
      Console.WriteLine("Can you Hear me?");

      // BONUS: Convert string to number from user input
      Console.WriteLine("Give me a number");
      string input = Console.ReadLine();
      // unsafe
      int inputNum = Int32.Parse(input);
      if (inputNum > 3)
      {
        Console.WriteLine("Thats bigger than 3");
      }
      bool gettingInput2 = true;
      while (gettingInput2)
      {
        Console.WriteLine("Give me another number");
        string input2 = Console.ReadLine();
        // try to conver input, if successfull set the value of the result to inputNum2 and return true
        if (Int32.TryParse(input2, out int inputNum2))
        {
          gettingInput2 = false;
          if (inputNum2 > 3)
          {
            Console.WriteLine("Thats bigger than 3");
          }
        }
        else
        {
          Console.WriteLine("not a number");
        }
      }


      // SECTION Loops
      // array.length : list.count
      for (int i = 0; i < catsList.Count; i++)
      {
        Console.WriteLine(catsList[i]);
      }



      // SECTION Using Classes
      Cat myCat = new Cat("Mr. Snibbley", 100);
      myCat.Name = "Capt. Jack";
    }
  }
}
