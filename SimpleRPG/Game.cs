using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG
{
    class Game
    {
        //player stats
        string playerName = "";
        int playerMaxHealth = 100;
        int playerHealth = 100;
        int playerDamage = 10;
        int playerHealing = 25;

        public void Start()
        {

            Welcome();

            int monstersRemaining = 5;

            bool alive = true;

            //fight until you die
            while (alive && monstersRemaining > 0)
            {
                Console.WriteLine("There are " + monstersRemaining + " monsters remaining.");
                alive = Encounter(20, 20);
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

        bool Encounter(int monsterHealth, int monsterDamage)
        {
            //Monster encounter!
            Console.WriteLine("");
            Console.WriteLine("A monster approaches!");

            //Player actions
            string action = "";
            bool survive = true;


            //Loop
            while (playerHealth > 0 && monsterHealth > 0)
            {
                Console.Write("What will you do? (Fight/Flee/Heal)");
                action = Console.ReadLine();
                if (action == "Fight" || action == "fight")
                {

                    survive = Fight(ref monsterHealth, ref monsterDamage);
                    if (!survive)
                    {
                        return false;
                    }
                }


                else if (action == "Flee" || action == "flee")
                {

                    survive = Flee();
                    if (survive)
                    {
                        return true;
                    }

                }

                else if (action == "Heal" || action == "heal")
                {

                    survive = Heal(ref monsterHealth, ref monsterDamage);
                    if (!survive)
                    {
                        return false;
                    }

                }

                else
                {
                    //no action
                    Console.WriteLine("Invalid");
                    Console.ReadLine();
                    continue;
                }

            }
            return survive;
        }
        bool Fight(ref int monsterHealth, ref int monsterDamage)
        {
            {
                //player attack
                Console.WriteLine(playerName + " attacks! The monster takes " + playerDamage + " damage!");
                monsterHealth -= playerDamage;
                Console.WriteLine("The monster has " + monsterHealth + " health remaining.");

                if (monsterHealth <= 0)
                {
                    //Monster defeat
                    Console.WriteLine(playerName + " defeated the monster!");
                    return true;
                }
            }

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
            return true;
        }


        bool Flee()
        {
            //escape
            Console.WriteLine(playerName + " got away safely...");
            return true;
        }

        bool Heal(ref int monsterHealth, ref int monsterDamage)
        {
            {
                //player heal
                Console.WriteLine(playerName + " drinks a vulnerary. " + playerName + " recovers " + playerHealing + " health.");
                playerHealth += playerHealing;

                if (playerHealth > playerMaxHealth)
                {
                    playerHealth = playerMaxHealth;
                }

                Console.WriteLine("The player has " + playerHealth + " health remaining.");
            }

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
            return true;
        }





    }
}
