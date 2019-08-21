using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    class Game
    {
        string playerName = "";
        int playerHealth = 100;

        public void Start()
        {

            Welcome();

            int monstersRemaining = 5;

            bool alive = true;

            //fight until you die
            while (alive && monstersRemaining > 0)
            {
                Console.WriteLine("There are " + monstersRemaining + " monsters remaining.");
                alive = Encounter(20);
                monstersRemaining--;
            }

            //wait for user input before closing
            Console.ReadKey();

        }

        void Welcome()
        {
            //Welcome the player
            Console.Write("What is your name? ");
            playerName = Console.ReadLine();
            Console.WriteLine("Welcome, " + playerName + ".");
        }

        bool Encounter(int monsterDamage)
        {
            //Monster encounter!
             Console.WriteLine("");
            Console.WriteLine("A monster approaches!");

            //Player actions
            string action = "";
            Console.Write("What will you do? (Fight/Flee) ");
            action = Console.ReadLine();

            //Loop
            for (int count = 0;
                count < 1;)
                if (action == "Fight" || action == "fight")
            {
                //monster attack
                Console.WriteLine("The monster attacks " + playerName + " takes " + monsterDamage + " damage!");
                playerHealth = playerHealth - monsterDamage;
                Console.WriteLine(playerName + " Has " + playerHealth + " points of health remaining.");

                if (playerHealth <= 0)
                {
                    //Player deafat
                    Console.WriteLine(playerName + " was deafted...");
                    return false;
                }

                //player attack
                Console.WriteLine(playerName + " attacks! The monster is defeated!");
                    count++;
            }

            else if (action == "Flee" || action == "flee")
            {
                //escape
                Console.WriteLine(playerName + " got away safely...");
                    count++;
            }

            else
            {
                Console.WriteLine("Invalid");
                    Console.ReadLine();
            }
            return true;
        }
        

    }
}
