using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHall2
{
    class Program
    {
        static int Main(string[] args)
        {
            Random random = new Random();
            int wins = 0;
            int losses = 0;
            int winCar = 0;
           
            int[] doors = new int[3];
            doors[0] = 1;
            doors[1] = 2;
            doors[2] = 3;
            
            int games = 0;
            int choice = 0;
            int badDoor = 0;
            int newDoor = 0;
            //Monty Hall problem is a paradox that shows the choice between two items is not always 50/50.
            // This is a simulation of the game that will record all wins and losses.
            //We first ask the user how many games theyd like to play.
                Console.WriteLine("This is a simulation of the Monty Hall Paradox. You will be given 3 doors to choose from.");
                Console.WriteLine("One of the has a car behind it the others have goats. After you choose I will open one of the doors that does not have a car.");
                Console.WriteLine("You can then choose to keep the door you have or trade it for the other remaining unopened door.");
                Console.WriteLine("The trick to this game is thinking its a 50/50 shot when deciding to keep or trade your door.");
                Console.WriteLine("This problem actually proves you have a 66% chance of winning if you switch doors! Find out for yourself.");
                Console.WriteLine();
                Console.WriteLine();
            while (true)
            {
                

                Console.WriteLine("How many times would you like to play?");
                
                bool success = int.TryParse(Console.ReadLine(), out games);
                
                if (success == true && games > 0)
                {
                    break;
                }
                Console.WriteLine("Please select 1 or more games.");
            }
            
            
            
            while (games > wins + losses)
            {



                //put a car behind door
                

                Random car = new Random();
                winCar = car.Next(1, 4);
                

                //here we have the users pick the door
                
                while (true)
                {
                    Console.WriteLine("Which Door would you like? 1, 2, or 3?");

                    bool success = int.TryParse(Console.ReadLine(), out choice);
                    
                    if (success == true && choice > 0 && choice < 4)
                    {
                        break;
                    }
                    Console.WriteLine("Hmmm I cant find that door. Please pick 1, 2, or 3.");
                }
                //if they do not pick a valid option
               



                //open unpicked door with goat (!= wincar)
                if (choice == 1)
                {
                    Random door1 = new Random();
                    badDoor = door1.Next(doors[1], doors[2]);


                    if (badDoor == winCar)
                    {


                        if (badDoor == winCar && winCar == doors[1])
                        {
                            badDoor = doors[2];
                        }
                        if (badDoor == winCar && winCar == doors[2])
                        {
                            badDoor = doors[1];
                        }
                    }
                    Console.WriteLine(+badDoor + " does not have a car.");
                    choice = doors[0];

                    if (badDoor == doors[1])
                    {
                        newDoor = doors[2];
                    }
                    else if (badDoor == doors[2])
                    {
                        newDoor = doors[1];
                    }
                }
                else if (choice == 2)
                {
                    int wrong = 0;
                    Random door1 = new Random();
                    wrong = door1.Next(doors[0], doors[2]);

                    while (wrong == doors[1])
                    {
                        Random door2 = new Random();
                        badDoor = door2.Next(doors[0], doors[2]);
                        wrong = door2.Next(doors[0], doors[2]);
                        badDoor = wrong;
                        if (badDoor == winCar)
                        {
                            if (badDoor == winCar && winCar == doors[0])
                            {
                                badDoor = doors[2];
                            }
                            if (badDoor == winCar && winCar == doors[2])
                            {
                                badDoor = doors[0];
                            }
                        }
                    
                    }
                    if (badDoor == doors[0])
                    {
                        newDoor = doors[2];
                    }
                    if (badDoor == doors[2])
                    {
                        newDoor = doors[0];
                    }
                    
                   
                    Console.WriteLine(+badDoor+ " does not have a car.");
                    choice = doors[1];
                }
                else if (choice == 3)
                {
                    Random door1 = new Random();
                    badDoor = door1.Next(doors[0], doors[1]);

                    if (badDoor == winCar)
                    {
                        if (badDoor == winCar && winCar == doors[0])
                        {
                            badDoor = doors[1];
                        }
                        if (badDoor == winCar && winCar == doors[1])
                        {
                            badDoor = doors[0];
                        }

                    }
                    Console.WriteLine(+badDoor + " does not have a car.");
                  
                    choice = doors[2];
                    if (badDoor == doors[0])
                    {
                        newDoor = doors[1];
                    }
                    else if (badDoor == doors[1])
                    {
                        newDoor = doors[0];
                    }
                }
                

                int stay = 0;
                stay += choice;



                //ask to switch
                Console.WriteLine("would you like to switch doors? y for yes, n for no.");
                string change = Console.ReadLine();
                
                    if (change == "y" || change == "Y")
                    {
                        // change door to door not chosen and not opened
                        choice = newDoor;
                        Console.WriteLine("You chose to switch to door " + choice + "!");
                        
                    }
                    else if (change == "n" || change == "N")
                    {
                        choice = stay;
                    }
                    else if (change != "n" || change != "N" || change != "y" || change != "Y")
                    {
                        Console.WriteLine("Please type y or n.");
                        change = Console.ReadLine();
                    }
                    
                    
                
               
                

                //make other doors goats
                if (choice != winCar)
                {

                    Console.WriteLine("Sorry! The car was behind door number " +winCar+"! :(");
                    losses++;


                }
                if (choice == winCar)

                {
                    Console.WriteLine("You found the car behind door number " + winCar + "! :D");
                    wins++;
                }
               


                

            }
            Console.WriteLine("You had "+wins + " wins and, " + losses + " losses.");
            Console.ReadKey();

            return wins;
               








        }
    }
}
