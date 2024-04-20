
using System;
using System.Collections.Generic;

public partial class Program
{
    public static void Main()
    {
        Console.WriteLine("Creating and printing a pet");
        
        Pet trial = new Pet("Trial", 3.1, "pet", new AnimalAge(2, 3), AnimalGender.Female);        
        Console.WriteLine(trial.ToString());

        Console.WriteLine("\n\nGetting a collection of pets");
        List<Pet> petlist = Pet.CreatePets();
        //write the statement to get a list of pets - 2 marks
//(By calling the CreatePets() method)
//and display the resulting collection of pets
        foreach (Pet pet in petlist)
        {
            Console.WriteLine(pet.ToString());
        }

        double weight = 1.0;
        Console.WriteLine($"\n\nDisplaying all pets heavier than {weight}kg");
      foreach (Pet pet in petlist)
        {   
            if (pet.Weight > weight){
                Console.WriteLine(pet.ToString());
            }
            
        }

    string filename = "pets.json";
    Console.WriteLine($"\n\nSerializing the pets to the file {filename}");

    // Serialize the petlist to JSON and write it to a file
    string jsonString = JsonSerializer.Serialize(petlist);
    File.WriteAllText(filename, jsonString);



    }


public class Pet: Animal
{
    public string Name { get; }
    public double Weight { get; }

    public Pet(string name, double weight, string species, AnimalAge age, AnimalGender gender)
        : base(species, age, gender)
    {
        this.Name = name;
        this.Weight = weight;
    }


     public static List<Pet> CreatePets(){
        List<Pet> PetList = new List<Pet>();
        PetList.Add(new Pet("Jake", 3.1, "pet", new AnimalAge(2, 3), AnimalGender.Female));
        PetList.Add(new Pet("Oscar", 0.1, "pet", new AnimalAge(1, 0), AnimalGender.Hermaphrodite));
        PetList.Add(new Pet("Jake", 8.1, "pet", new AnimalAge(10, 4), AnimalGender.Male));
        PetList.Add(new Pet("Sylvester", 4.5, "pet", new AnimalAge(2, 4), AnimalGender.Female));
        PetList.Add(new Pet("Tweety", 0.2, "pet", new AnimalAge(0, 0), AnimalGender.Female));

        return PetList;
    }


    public override string ToString()
    {
        return $"{this.Name}, {this.Age.Month} mos, {this.Age.Day} days, {this.Weight} kgs, {this.Gender}";
    }
}

public class Animal
{
    public AnimalAge Age { get; }
    public AnimalGender Gender { get; }
    public string Species { get; }

    public Animal(string species, AnimalAge age, AnimalGender gender)
    {
        this.Species = species;
        this.Age = age;
        this.Gender = gender;
    }
}

public class AnimalAge
{
    public int Day {get;}
    public int Month {get;}

    public AnimalAge(int month, int day)
    { 
        this.Day = day; 
        this.Month = month;  
    }

    public override string ToString()
    {
        return $" {this.Month} mos, {this.Day} days ";
    }
}

[Flags]
public enum AnimalGender
{
    Male = 1,
    Female = 2,
    Hermaphrodite = 4
}

}