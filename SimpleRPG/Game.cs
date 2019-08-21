using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    class Game
    {
        public void Start()
        {
            string playerName = "";
            int playerHealth = 100;

            //Welcome the player
            Console.Write("What is your name? ");
            playerName = Console.ReadLine();
            Console.WriteLine("Welcome, " + playerName + ".");

            //Monster encounter!
            int monsterDamage = 13;
            Console.WriteLine("");
            Console.WriteLine("A monster approaches!");

            //Player actions
            string action = "";
            Console.Write("What will you do? (Fight/Flee) ");
            action = Console.ReadLine();

            if (action == "Fight" || action == "fight")
            {
                //monster attack
                Console.WriteLine("The monster attacks " + playerName + " takes " + monsterDamage + " damage!");
                playerHealth = playerHealth - monsterDamage;
                Console.WriteLine(playerName + " Has " + playerHealth + " points of health remaining.");

                //player attack
                Console.WriteLine(playerName + " attacks! The monster is defeated!");
            }

            else if (action == "Flee" || action == "flee")
            {
                //escape
                Console.WriteLine(playerName + " got away safely...");
            }

            Console.ReadKey();
        }
    }
}
