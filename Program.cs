/* Purpose:To create a system to reflect the costs of financially sponsoring a Unicorn at the
Unicorn Rescue Society. The society works to promote the wellbeing and care of Unicorns
which, once thought to be extinct, are now making a comeback!
 * Input:sponsor, unicorn, option, donationAmount, sideWidth, backWidth, gateWidth, gateHeight, gateType, paintJob, meal
 * Output: penCost, gateCost, total
 * Author: Mihiri Kamiss
 * Date: 9/25/2022
*/

namespace UnicornRescueSociety
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declare inputs

            string sponser,
                unicorn,
                noPaint = "Original",
                noMeal = "None";
            char option,
                yesNo;
            double donationAmount = 0,
                sideWidth,
                backWidth,
                gateWidth,
                gateHeight,
                penCost,
                gateCost,
                total,
                donationTotal,
                extraFence,
                gateStyleCost = 1,
                paintCost = 0,
                mealCost = 0;
            int payPeriod = 1;

            //Ask for donation type

            Console.WriteLine("**Welcome to the Unicorn Rescue Society donation page**");
            Console.Write("\nWhat is the sponser's name?: ");
            sponser = Console.ReadLine();
            Console.Write("What would you like to name the unicorn?: ");
            unicorn = Console.ReadLine();

            //Ask for donation amount and pay period

            Console.WriteLine("All sponsers must make a donation.");
            Console.WriteLine("What type would you like to make?");
            Console.WriteLine("\t U - Unlimited");
            Console.WriteLine("\t M - Monthly");
            Console.WriteLine("\t O - One Time");
            Console.Write("Option: ");
            option = char.Parse(Console.ReadLine());
            option = char.ToUpper(option);
            switch (option)
            {
                case 'M':
                    Console.Write("Enter amount per month: ");
                    donationAmount = double.Parse(Console.ReadLine());
                    Console.Write("How many months? ");
                    payPeriod = int.Parse(Console.ReadLine());
                    break;

                case 'O':
                    Console.Write("Enter one time amount: ");
                    donationAmount = double.Parse(Console.ReadLine());
                    break;

                case 'U':
                    Console.Write("Enter amount per month: ");
                    donationAmount = double.Parse(Console.ReadLine());
                    break;

                default:
                    Console.WriteLine("No valid selection chosen, please try again.");
                    Environment.Exit(0);
                    break;

            }

            donationTotal = donationAmount * payPeriod;

            //Display total for donation

            Console.WriteLine($"The total donation amount is {donationTotal:c}");

            //Ask for pen size specifications
            Console.WriteLine("\n**Pen Accomodations**");
            Console.Write("\nWhat is the width of the two side walls (in feet)?: ");
            sideWidth = double.Parse(Console.ReadLine());
            Console.Write("What is the width of the back wall (in feet)? ");
            backWidth = double.Parse(Console.ReadLine());
            Console.Write("What is the width of the gate (in feet)? ");
            gateWidth = double.Parse(Console.ReadLine());
            Console.Write("What is the length of the gate (in feet)? ");
            gateHeight = double.Parse(Console.ReadLine());

            extraFence = (backWidth - gateWidth) * 12;

            //Calculate pen total not including gate
            penCost = (((sideWidth * 24) + (backWidth * 12) + extraFence) * 4);

            //Ask for paint job type

            Console.WriteLine("\n**Gate Style**");
            Console.WriteLine("\nAvailable gates (prices per square foot): ");
            Console.WriteLine("\t W - Wooden ($3)");
            Console.WriteLine("\t S - Silver ($8)");
            Console.WriteLine("\t G - Gold ($15)");
            Console.Write("Option: ");
            option = char.Parse(Console.ReadLine());
            option = char.ToUpper(option);

            switch (option)
            {
                case 'W':
                    gateStyleCost = 3;
                    break;

                case 'S':
                    gateStyleCost = 8;
                    break;

                case 'G':
                    gateStyleCost = 15;
                    break;
                default:
                    Console.WriteLine("Invalid gate style selection, please try again");
                    Environment.Exit(0);    
                    break;
            }

            //Calculate gate total
            gateCost = (gateWidth * gateHeight) * gateStyleCost;

            //Ask for paint job type
            Console.Write("\nWould you like to change the gate paint (Y/N)?: ");
            yesNo = char.Parse(Console.ReadLine());
            yesNo = char.ToUpper(yesNo);

            if (yesNo == 'Y')
            {
                    Console.WriteLine("Available paints:");
                    Console.WriteLine("\t M - Mood: Changes colour based on mood ($200)");
                    Console.WriteLine("\t A - Magic: Changes colour several times a day ($300)");
                    Console.WriteLine("\t R - Reflective: Reflects like a mirror ($150)");
                    Console.Write("Option: ");
                    option = char.Parse(Console.ReadLine()); 
                    option = char.ToUpper(option);

                switch (option)
                {
                    case 'M':
                        paintCost = 200;
                        break;

                    case 'A':
                        paintCost = 300;
                        break;

                    case 'R':
                        paintCost = 150;
                        break;

                    default:
                        Console.WriteLine("No valid option chosen, you will not be charged for a paint job.");
                        paintCost = 0;
                        break;

                }

            }
            else
            {
                paintCost = 0;
            }


            //Ask for meal upgrade type
            Console.WriteLine("\n**Meal Upgrade**");
            Console.Write("\nWould you like a meal upgrade (Y/N)?: ");
            yesNo = char.Parse(Console.ReadLine());
            yesNo = char.ToUpper(yesNo);

            if (yesNo == 'Y')
            {
                Console.WriteLine("Available meal upgrades:");
                Console.WriteLine("\t R - Add rainbow cookie treats ($1000)");
                Console.WriteLine("\t S - Special appetizers ($500)");
                Console.Write("Option: ");
                option = char.Parse(Console.ReadLine());
                option = char.ToUpper(option);

                switch (option)
                {
                    case 'R':
                        mealCost = 1000;
                        break;

                    case 'S':
                        mealCost = 500;
                        break;

                    default:
                        Console.WriteLine("No valid option chosen, you will not be charged for a meal upgrade.");
                        paintCost = 0;
                        break;
                }

            }
            else
            {
                mealCost = 0;
            }

            //Calculate total

            Console.WriteLine(mealCost);
            Console.WriteLine(paintCost);
            total = donationTotal + penCost + gateCost + paintCost + mealCost;

            //Display reciept

            Console.WriteLine("\n**Your Reciept**");
            Console.WriteLine($"\nDoner \t {sponser}");
            Console.WriteLine($"Unicorn Name \t {unicorn}");
            Console.WriteLine($"Donation Amount \t {donationTotal:c}");
            Console.WriteLine($"Wall Cost \t {penCost:c}");
            Console.WriteLine($"Gate Cost \t {gateCost:c}");

            if (paintCost == 0)
            {
                Console.WriteLine($"Gate Paint Cost \t {noPaint}");
            }
            else
            {
                Console.WriteLine($"Gate Paint Cost \t {paintCost:c}");
            }

            if (mealCost == 0)
            {
                Console.WriteLine($"Meal Upgrade \t {noMeal}");
            }
            else 
            {
                Console.WriteLine($"Meal Upgrade \t {mealCost:c}");
            }

            Console.WriteLine($"{sponser}, the total cost to sponser {unicorn} is {total:c}");
            Console.WriteLine("Thank you for your donation!");
            Console.ReadLine();
            
        }
    }
}