using System;
using System.Diagnostics;
using System.Numerics;

namespace Final_Project
{
	public class Game
	{
        public Player Raiden { get; private set; }
        enum ecounters
        {
            armstrong,
            bladeWolf,
            jetstreamSam,
            mistral,
            monsoon,
            sundowner
        }

        public Game()
		{
            Raiden = new Player("Raiden");
		}

        /*---------------------------------------------------------
            Main Functions
         ----------------------------------------------------------*/

        public void InitializeGame()
		{
            DisplayAdjustScreenMenu();
            DisplayArt();
            DisplayUpgradeMenu();       
        }

        private void StartFight()
        {

            List<Encounter> encountersList = new List<Encounter>();
            encountersList.Add(new Encounter(Raiden, new Armstrong("Senator Armstrong"), 3000));
            encountersList.Add(new Encounter(Raiden, new BladeWolf("BladeWolf"), 1500));
            encountersList.Add(new Encounter(Raiden, new JetstreamSam("Jetstream Sam"), 2600));
            encountersList.Add(new Encounter(Raiden, new Mistral("Mistral"), 1800));
            encountersList.Add(new Encounter(Raiden, new Monsoon("Monsoon"), 2000));
            encountersList.Add(new Encounter(Raiden, new Sundowner("Sundowner"), 2200));

            encountersList[RandomEncounterValue()].RunEncounter();
            DisplayUpgradeMenu();

            //Cyborg newCybord = new Cyborg("Cyborg Nish", new KeyValuePair<int, double>(1, 50),
            //    new KeyValuePair<int, double>(1, 50), new KeyValuePair<int, double>(1, 25), 1);
            //Encounter newEncounter = new Encounter(Raiden, newCybord, 1200);
            //newEncounter.RunEncounter();
        }

        static int RandomEncounterValue()
        {
            var rnd = new Random();
            return rnd.Next(0, Enum.GetNames(typeof(ecounters)).Length);
        }

        /*----------------------------------------------------------------
            Upgrade Menu Functions
         ----------------------------------------------------------------*/

        private void DisplayUpgradeMenu()
        {
        
            bool looping = true;
            while (looping)
            {
                Menu upgradeMenu = new Menu($"BP: {Raiden.BP} | Select an option:",
                new List<string>
                {
                        "Fight", "Upgrade stats", "Equip weapon", "Purchase attacks", "Exit"
                }, ReturnUpgradeMenuImage()
                );
                switch (upgradeMenu.RunMenu())
                {
                    case "Fight":
                        StartFight();
                        looping = false;
                        break;
                    case "Upgrade stats":
                        DisplayStatsMenu();
                        break;
                    case "Equip weapon":
                        DisplayWeaponsMenu();
                        break;
                    case "Purchase attacks":
                        DisplayAttacksMenu();
                        break;
                    case "Exit":
                        looping = false;
                        break;
                }
            }
        }

        private string ReturnUpgradeMenuImage()
        {
            return @"





                                  ,,***,*                           
                          ,,,**/**,***(/(//(                        
                         ,**,//(//((#(///##//(                      
                       .,,,,//,**/////((((#%#&*,                    
                      ..,,,,,*,**//((///(((((*,.,*                  
                     .,,*,,,,,,*,,,*,(*(*(/*#(/,/(,                 
                    ,,,,..... .,.,..*(,(#/%&@@@/*,,                 
                    ........,,,...,,,.,,**/(#(@@,/                  
                      .*.... .,./*,,.....,,*/*%((*..                
                       *......(.,***/(((/*@&,.*(#(,.                
                       ,(... ,  ..**/#(/**(@@@%.,/,                 
                             ,*   ****/(*,*%&%(#,*,(                
                            . .     ..&,...,,(,.   .                
                             .#   ... ,..,(&(,                      
                             ./      .%..*/%@**..,,,*               
                            ..@,      ../*(*....,/(##**,,           
                         ....,&%......#%(#%/..*(%,*,,**.../***   / *
             ,         ..*% ..(#.,..*//**,**,,,,,,,..,,,,**...,....*
            ....   *//(*,....,,,..*,*/////#%@@&/(//@@@/.......,,....
        %  .. .**,......*.,/.,.//*,,%*,....,,,...,,,,.,,**#,,*%%(/%#
        ....,.......*@/**/**/*//,(%%*,,,,,,,,,,,,,,,,,..,,,,,.,,,,*(
        .,... ......,.*#*,*////,,,.,,,,,,.,,,,,*..,....,,,,*,*%&(*,,
        (..,,.,... .....,**,,..,,*.,,.,,,,,,,,,,.,,,,,,,,,%..,##****
            ";
        }

        /*-----------------------------------
            Upgrading Stats
         -----------------------------------*/

        private void DisplayStatsMenu()
        {
            bool looping = true;
            while (looping)
            {
                StoreMenu StatsStore = new StoreMenu($"BP: {Raiden.BP} | Select an option:", InstantiateStatsMenuOptions(), ReturnStatsMenuImage());
                Console.WriteLine(Raiden.ReturnTotalHealth());
                switch (StatsStore.RunMenu().Split('|').First().Trim())
                {
                    case "Total Health":
                        Console.WriteLine("works");
                        if (IsUpgradePurchasable(Raiden.ReturnTotalHealth().Key * 1000))
                        {
                            Raiden.RemoveCurrency(Raiden.ReturnTotalHealth().Key * 1000);
                            Raiden.UpgradeStat("Total Health");
                        }
                        break;
                    case "Total Energy":
                        if (IsUpgradePurchasable(Raiden.ReturnTotalEnergy().Key * 1000))
                        {
                            Raiden.RemoveCurrency(Raiden.ReturnTotalEnergy().Key * 1000);
                            Raiden.UpgradeStat("Total Energy");
                        }
                        break;
                    case "Energy Replenish":
                        if (IsUpgradePurchasable(Raiden.ReturnTotalEnergy().Key * 1000))
                        {
                            Raiden.RemoveCurrency(Raiden.ReturnTotalEnergy().Key * 1000);
                            Raiden.UpgradeStat("Energy Replenish");
                        }
                        break;
                    case "Exit":
                        looping = false;
                        break;
                }
            }
        }

        private List<KeyValuePair<string,string>> InstantiateStatsMenuOptions()
        {
            return
            new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>( $"Total Health     | {Raiden.ReturnTotalHealth().Key * 1000}BP",
                                                      $"\t{Raiden.ReturnTotalHealth().Value}HP => {100 + (Raiden.ReturnTotalHealth().Key*20)}HP"),

                    new KeyValuePair<string, string>( $"Total Energy     | {Raiden.ReturnTotalEnergy().Key * 1000}BP",
                                                      $"\t{Raiden.ReturnTotalEnergy().Value}NRG => {100 + (Raiden.ReturnTotalEnergy().Key*20)}NRG"),

                    new KeyValuePair<string, string>( $"Energy Replenish | {Raiden.ReturnEnergyReplenish().Key * 1000}BP",
                                                      $"\t{Raiden.ReturnEnergyReplenish().Value}NRG/ROUND => {Raiden.ReturnEnergyReplenish().Value + 10}NRG/ROUND"),
                    new KeyValuePair<string, string>( "Exit","")
                };
        }

        private bool IsUpgradePurchasable(double cost)
        {
            if(Raiden.BP > cost)
            {
                return true;
            }
            return false;
        }

        private string ReturnStatsMenuImage()
        {
            return @"



                                      ,/                            
                                   ,**/(#%##(                       
                                 */./((##(((##(                     
                                ****(((#(#/###                      
                                 *(**(##%%##&(*                     
                                 /##%%(((#/(/(                      
                                  #/.%%#//#/#                       
                                 /###&%&&%&&%%,                     
                             (#(/(@%**@(%%(#(*&&/%#                 
                     (/##%%%%@&&&&#/%*&#%%%%%&@@%%%%%%*  **         
                      ##%&&&&&&&@@#@(@&@#@######%#@%(@&&@&          
                     *%@@&&&&&&%@%@@&%&%&&%@&##%&@@&%%&&&%          
                     (&&(%&@@&@@@@@@@@@@#%&&@&&@&@@@@#(&@&          
                    *((&&%&@@@@@@@@@@@@@@@@@@@@@@@@@@%&&&%          
                   *%*@@@@@/%#(%#&&&&&&&/&@@#&&&&@@@@@@&&&&%        
                   #@@#&@&&##/&%&(&#&&#%/##@(&&&&@% %@&&&&&&        
                #(#(&%@&    #*@%&&&&&%#&&((%%&&&%     &%#&&&#       
                &%%&(#/#    ##%&&&%&&%&%&(#%@@%%(       *&@@/%%%%   
             %&%%&&&&%      &&(%%%&&@&&@#&&%&@#%#        (&@#((%.(  
            ,&&&*&&%#      /&(&&&%@&%&&#%&@&&&%%%         #&#@&%&&& 
          &&@&@(&%*        #&#&%@&&&&&%@&#@%%@%(&          &%#@&%&&&
          ,%@%#%*         %&&&&&&#&&#&&@@%##&&&&%&           (%%/%#/
          %,.%(   .,     #&&(&%&&@#&#@@&&@@&*%&&&&            ,%(&% 
          (#%%  /(%&*   #&@&&&&/&@@@%@@&%&#%(%@&&&%            /.%& 
         ##@@#(#&%     #&@@&&&@@@@@@@&&&&&&&%#%#%@&#           #@%% 
            ";
        }

        /*-----------------------------------
            Equiping weapons
        -----------------------------------*/

        private void DisplayWeaponsMenu()
        {
            bool looping = true;

            while (looping)
            {
                
                string option = InstantiateWeaponsMenu().RunMenu().Replace("- EQUIPED", string.Empty);
                if (option == "Exit")
                {
                    looping = false;
                }
                else
                {
                    foreach (Weapon weapon in Raiden.WeaponsList)
                    {
                        if (weapon.Name == option && weapon != Raiden.ReturnEquipedWeapon())
                        {
                            Raiden.EquipWeapon(weapon);
                        }
                    };
                }
            }
        }

        //private List<string> InstantiateWeaponsMenuOptions()
        //{
        //    List<string> playerWeaponsList = new List<string>();
        //    foreach (Weapon weapon in Raiden.ReturnWeaponsList())
        //    {
        //        if (weapon == Raiden.ReturnEquipedWeapon())
        //        {
        //            playerWeaponsList.Add($"{weapon.Name} - EQUIPED");
        //        }
        //        else
        //        {
        //            playerWeaponsList.Add($"{weapon.Name}");
        //        }
        //    }
        //    playerWeaponsList.Add("Exit");
        //    return playerWeaponsList;
        //}

        private StoreMenu InstantiateWeaponsMenu()
        {
            List<KeyValuePair<string, string>> playerWeaponsList = new List<KeyValuePair<string, string>>();
            foreach (Weapon weapon in Raiden.ReturnWeaponsList())
            {
                if (weapon == Raiden.ReturnEquipedWeapon())
                {
                    playerWeaponsList.Add(new KeyValuePair<string, string>($"{weapon.Name} - EQUIPED", $"\tDAMAGE: - {weapon.Damage}HP -"));
                }
                else
                {
                    playerWeaponsList.Add(new KeyValuePair<string, string>($"{weapon.Name}", $"\tDAMAGE: - {weapon.Damage}HP -"));
                }
            }
            playerWeaponsList.Add(new KeyValuePair<string, string>("Exit", ""));

            return new StoreMenu($"BP: {Raiden.BP} | Select an option:", playerWeaponsList, ReturnWeaponsMenuImage());
        }

        private string ReturnWeaponsMenuImage()
        {
            return @"   
                                                             ...
                                                            .,. 
                                                          ./.   
                                                            
                                                       //.      
                                                     **..       
                                                   . .*.        
                                                  (.,.,         
                                                ..***           
                                              //*//             
                                            #(/**               
                                          ,(///                 
                                         #(/(%                  
                                       #%((@                    
                                     %&(#@                      
                                   %&#%&                        
                                 &&%&@                          
                               %&%&@                            
                             &&%&&                              
                           %&%%%                                
                         %&@%%                                  
                       #(###.                                   
                     #%###                                      
                   #%(((.                                       
                 #%((/                                          
               (#///.                                           
             ((///                                              
           (/(/(                                                
         /***#                                                  
       **,(                                                     
            ";
        }

        /*-----------------------------------
            Purchasing Attacks
        -----------------------------------*/

        private void DisplayAttacksMenu()
        { 

            bool looping = true;
            while (looping)
            {
                string option = InstantiateAttacksMenu().RunMenu();
                string optionName = option.Split('-')[1].Trim();
                switch (optionName)
                {
                    case "Cross Slash":
                        if (IsAttackPurchasable(option))
                        {
                            Attack newAttack = new Attack("Cross Slash", 1.2, 90, 70, 40);
                            Raiden.EquipAttack(newAttack);
                            Raiden.RemoveCurrency(ReturnCost(option));
                        }
                        break;
                    case "Sweep Kick":
                        if (IsAttackPurchasable(option))
                        {
                            Attack newAttack = new Attack("Sweep Kick", 0.8, 100, 95, 15);
                            Raiden.EquipAttack(newAttack);
                            Raiden.RemoveCurrency(ReturnCost(option));
                        }
                        break;
                    case "Thunderstrike":
                        if (IsAttackPurchasable(option))
                        {
                            Attack newAttack = new Attack("Thunderstrike", 2, 80, 95, 55);
                            Raiden.EquipAttack(newAttack);
                            Raiden.RemoveCurrency(ReturnCost(option));
                        }
                        break;
                    case "Jaw Breaker":
                        if (IsAttackPurchasable(option))
                        {
                            Attack newAttack = new Attack("Jaw Breaker", 1.4, 70, 85, 30);
                            Raiden.EquipAttack(newAttack);
                            Raiden.RemoveCurrency(ReturnCost(option));
                        }
                        break;
                    case "Flurry Kick":
                        if (IsAttackPurchasable(option))
                        {
                            Attack newAttack = new Attack("Flurry Kick", 1.6, 80, 90, 40);
                            Raiden.EquipAttack(newAttack);
                            Raiden.RemoveCurrency(ReturnCost(option));
                        }
                        break;
                    case "Stormbringer":
                        if (IsAttackPurchasable(option))
                        {
                            Attack newAttack = new Attack("Stormbringer", 2.5, 60, 100, 60);
                            Raiden.EquipAttack(newAttack);
                            Raiden.RemoveCurrency(ReturnCost(option));
                        }
                        break;
                    case "Bloodshed":
                        if (IsAttackPurchasable(option))
                        {
                            Attack newAttack = new Attack("Bloodshed", 3, 90, 60, 70);
                            Raiden.EquipAttack(newAttack);
                            Raiden.RemoveCurrency(ReturnCost(option));
                        }
                        break;
                    case "Exit":
                        looping = false;
                        break;
                }
            }
        }

        public bool IsAttackPurchasable(string option)
        {
            if (option.Contains("PURCHASED"))
            {
                return false;
            }
            if(Raiden.BP < ReturnCost(option))
            {
                return false;
            }
            return true;
        }

        private int ReturnCost(string option)
        {
            //string parsedInput = option.Split("BP").First();
            //return int.Parse(parsedInput.Substring(parsedInput.Length - 4));
            string parsedInput = option.Split("BP").First();
            string amount = parsedInput.Split(" ").Last();
            return int.Parse(amount);
        }


        //string parsedInput = option.Split("BP").First();
        //string amount = parsedInput.Split(" ").Last();
        //return int.Parse(amount);

        private StoreMenu InstantiateAttacksMenu()
        {
            return
                new StoreMenu($"BP: {Raiden.BP} | Select an option:",
                new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>( Raiden.ReturnAllAttackNames().Contains("Light Attack") ?  "- Light Attack -  | 1000BP - PURCHASED" : "- Light Attack -   | 1000BP",
                                    "\tMultiplier: 1\n\tAccuracy: 100\n\tSpeed: 70\n\tEnergy Usage: 25"),

                        new KeyValuePair<string, string>( Raiden.ReturnAllAttackNames().Contains("Strong Attack") ?  "- Strong Attack - | 1000BP - PURCHASED" : "- Storng Attack -   | 1000BP",
                                    "\tMultiplier: 1.4\n\tAccuracy: 80\n\tSpeed: 50\n\tEnergy Usage: 35"),

                        new KeyValuePair<string, string>( Raiden.ReturnAllAttackNames().Contains("Cross Slash") ?  "- Cross Slash -   | 3000BP - PURCHASED" : "- Cross Slash -   | 3000BP",
                                                          "\tMultiplier: 1.2\n\tAccuracy: 90\n\tSpeed: 70\n\tEnergy Usage: 40"),

                        new KeyValuePair<string, string>( Raiden.ReturnAllAttackNames().Contains("Sweep Kick") ? "- Sweep Kick -    | 5000BP - PURCHASED" : "- Sweep Kick -    | 5000BP",
                                                          "\tMultiplier: 0.8\n\tAccuracy: 100\n\tSpeed: 95\n\tEnergy Usage: 15"),

                        new KeyValuePair<string, string>( Raiden.ReturnAllAttackNames().Contains("Thunderstrike") ? "- Thunderstrike - | 10000BP - PURCHASED" : "- Thunderstrike - | 10000BP",
                                                          "\tMultiplier: 2\n\tAccuracy: 80\n\tSpeed: 95\n\tEnergy Usage: 55"),

                        new KeyValuePair<string, string>( Raiden.ReturnAllAttackNames().Contains("Jaw Breaker") ? "- Jaw Breaker -   | 8000BP - PURCHASED" : "- Jaw Breaker -   | 8000BP ",
                                                          "\tMultiplier: 1.4\n\tAccuracy: 70\n\tSpeed: 85\n\tEnergy Usage: 30"),

                        new KeyValuePair<string, string>( Raiden.ReturnAllAttackNames().Contains("Flurry Kick") ? "- Flurry Kick -   | 8500BP - PURCHASED" : "- Flurry Kick -   | 8500BP",
                                                          "\tMultiplier: 1.6\n\tAccuracy: 80\n\tSpeed: 90\n\tEnergy Usage: 40"),

                        new KeyValuePair<string, string>( Raiden.ReturnAllAttackNames().Contains("Stormbringer") ? "- Stormbringer -  | 12000BP - PURCHASED" : "- Stormbringer -  | 12000BP",
                                                          "\tMultiplier: 2.5\n\tAccuracy: 60\n\tSpeed: 100\n\tEnergy Usage: 60"),

                        new KeyValuePair<string, string>( Raiden.ReturnAllAttackNames().Contains("Bloodshed") ? "- Bloodshed -     | 15000BP - PURCHASED" : "- Bloodshed -     | 15000BP ",
                                                          "\tMultiplier: 3\n\tAccuracy: 90\n\tSpeed: 60\n\tEnergy Usage: 70"),

                        new KeyValuePair<string, string>( "- Exit -","")
                    }, ReturnAttacksMenuImage()
                ) ;
        }


        //private int ReturnPrice(string option)
        //{
     
        //}

        private string ReturnAttacksMenuImage()
        {
            return @"






                                           ((                       
        *,,*&&(%%&&&&&%%####%          ,%&&,% &%#&&&*        (%%####
        (/%%%%(*/((((((#%%((####%%#%%%#&%&#&%%%&&&&&&%%&&@&&%%      
         %&&&&&&&&&&&&&&&&@@&&@@@@@&&&& %,&&%%&&&%%%&&&&@&          
                                           #&@@#   %@&&%            
                                                   %,&%%            
         . */@@&&&&&&&&%&(#%            (%(&@%                  //(/
         /#%%%(///(#(((((#%%#%(#%%%#%%%%&&@#&%#%##((//****,,*       
         #&&&@&&&&&&&&&&&&&&&@&@@@@@@@&%%&%&%%                      
                                                            
                                        %%&%&%%                  (%#
                                        %&&&&%%&&&&&&&&&&&@&&%%##   
                                        %&&&&%&&&&&&@&%@@*%         
                                        #%%%&%&%%#%@&&&&&%          
                                            #@     %%%&             
                                                  *%%&%             
            ";
        }

        /*------------------------------------------
            Main Menu Functions
         ------------------------------------------*/

        private void DisplayStartMenu()
        {
            Menu startMenu = new Menu("Select an option:", new List<string> { "Start", "Exit" });
            switch (startMenu.RunMenu())
            {
                case "Start":
                    StartFight();
                    break;
                case "Exit":
                    Console.Clear();
                    break;
            }
        }

        private void DisplayArt()
        {
            Console.Clear();
            Console.WriteLine(@"
















        ___  ___ _____ _____ ___   _       _____  _____  ___  ______ 
        |  \/  ||  ___|_   _/ _ \ | |     |  __ \|  ___|/ _ \ | ___ \
        | .  . || |__   | |/ /_\ \| |     | |  \/| |__ / /_\ \| |_/ /
        | |\/| ||  __|  | ||  _  || |     | | __ |  __||  _  ||    / 
        | |  | || |___  | || | | || |____ | |_\ \| |___| | | || |\ \ 
        \_|  |_/\____/  \_/\_| |_/\_____/  \____/\____/\_| |_/\_| \_|
                ______ _____ _____ _____ _   _ _____    _____ 
                | ___ \_   _/  ___|_   _| \ | |  __ \  / __  \
                | |_/ / | | \ `--.  | | |  \| | |  \/  `' / /'
                |    /  | |  `--. \ | | | . ` | | __     / /  
                | |\ \ _| |_/\__/ /_| |_| |\  | |_\ \  ./ /___
                \_| \_|\___/\____/ \___/\_| \_/\____/  \_____/
            ");
            Console.WriteLine("\n\n\n\n\n\n\tPress any button\n\n\n");
            Console.ReadKey();
        }

        private void DisplayAdjustScreenMenu()
        {
            Console.WriteLine(@"
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@     - Lengthen or withen console until box is fully visible         @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@      - Press any button to continue                                 @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@                                                                     @@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            ");
            Console.ReadKey();
        }
    }
}

