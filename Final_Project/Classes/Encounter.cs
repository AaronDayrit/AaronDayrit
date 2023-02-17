using System;
namespace Final_Project
{
	public class Encounter
	{
		public int CurrencyGained { get; private set; }
		public Player PlayerEntity { get; private set; }
		public Entity EnemyEntity { get; private set; } 
	
		public Encounter(Player player, Entity enemy, int currencyGained)
		{
			PlayerEntity = player;
			EnemyEntity = enemy;
			CurrencyGained = currencyGained;
		}


		/* RunEcounter(Player, Enemy)
		 * While(Player.CurrentHealth || Enemy.CurrentHealth > 0)
			* Prompt menu for the user to pick an attack
			* Generate random attack from enemy
			* 
			* Player attack
			* Enemy Attack
			* 
			* if(PlayerAttack.speed is > EnemyAttack)
				* Enemy.TakeDamage(Player.DealDamage(playerAttack))
				* if(Enemy.Health > 0)
					* Player.TakeDamage(Enemy.DealDamage(enemyAttack))
				* else
					* break 
			* else
				* vice versa 
		 */

		public void RunEncounter()
		{
            PlayerEntity.ResetStats();
            EnemyEntity.ResetStats();
            while (PlayerEntity.ReturnCurrentHealth() > 0 && EnemyEntity.ReturnCurrentHealth() > 0)
			{
                /* Energy Replenishment ----------------------------------------*/
                PlayerEntity.ReplenishEnergy();
                EnemyEntity.ReplenishEnergy();

                /* Determining attacks -----------------------------------------*/
                Attack playerAttack = new Attack(100000);
                do
				{
					string playerAttackName = CreateAttackMenu().RunMenu();
					playerAttack = GetPlayerAttack(playerAttackName);
                    //Console.WriteLine(-(PlayerEntity.ReturnEnergyReplenish().Value));
                    Console.WriteLine($"{PlayerEntity.ReturnEquipedAttacksList()[2].Name}: {PlayerEntity.ReturnEquipedAttacksList()[2].EnergyUsage}"); ;
				} while (PlayerCannotUseAttack(PlayerEntity, playerAttack));

                Attack enemyAttack = GenerateEnemyAttack();
                Console.WriteLine(enemyAttack.EnergyUsage);

                /* Determining outcome of Attacks ------------------------------*/
                if (playerAttack.Speed > enemyAttack.Speed)
				{
					PlayerAttacksFirst(playerAttack, enemyAttack);
				}
				else if(enemyAttack.Speed > playerAttack.Speed)
				{
					EnemyAttacksFirst(playerAttack, enemyAttack);
				}
				else
				{
					AttackSpeedAreSame(playerAttack, enemyAttack);
				}
                
            }

			/* Determining Winner of Encounter ---------------------------------*/
			DetermineResult();
		}

        /*-------------------------------------
			Helper Methods 
		 -------------------------------------*/

		private EncounterMenu CreateAttackMenu()
		{
            List<string> menuOptions = new List<string>();
            foreach (Attack attack in PlayerEntity.ReturnEquipedAttacksList())
            {
                menuOptions.Add(attack.Name);
            }
            EncounterMenu AttackMenu = new EncounterMenu("Choose an attack:", menuOptions, EnemyEntity.Art, PlayerEntity, EnemyEntity);
			return AttackMenu;
        }

        /*---------------------------
			Attack Methods
		 ---------------------------*/

        private Attack GenerateEnemyAttack()
		{
    
            Console.WriteLine(EnemyEntity.ReturnCurrentEnergy());
            foreach(Attack attack in EnemyEntity.ReturnEquipedAttacksList())
            {
                Console.WriteLine(attack.Name);
            }
            if (EnemyCannotUseAttack())
            {
                return new Attack("Rest", 0, 100, 0, -(EnemyEntity.ReturnEnergyReplenish().Value));
            }
            Random randomNum = new Random();
			int randomIndex = randomNum.Next(0, EnemyEntity.ReturnEquipedAttacksList().Count() );
			return EnemyEntity.ReturnEquipedAttacksList()[randomIndex];
		}

		private Attack GetPlayerAttack(string attackName)
		{
			foreach(Attack attack in PlayerEntity.ReturnEquipedAttacksList())
			{
				if (attack.Name == attackName)
					return attack;
			}
            return null;
		}

        /*
		 	* if(PlayerAttack.speed is > EnemyAttack)
				* Enemy.TakeDamage(Player.DealDamage(playerAttack))
				* if(Enemy.Health > 0)
					* Player.TakeDamage(Enemy.DealDamage(enemyAttack))
				* else
					* break 
			* else
				* vice versa  
		  
		 */
        private void PlayerAttacksFirst(Attack playerAttack, Attack enemyAttack)
		{
			/* Player Attacks------------------------------------------------*/
			PlayerEntity.DeductEnergy(playerAttack);
			EnemyEntity.TakeDamage(PlayerEntity.DealDamage(playerAttack));
            //Thread.Sleep(2000);
            /* Enemy Attacks ------------------------------------------------*/
            if (EnemyEntity.ReturnCurrentHealth() > 0)
			{
                EnemyEntity.DeductEnergy(enemyAttack);
                PlayerEntity.TakeDamage(EnemyEntity.DealDamage(enemyAttack));
			}
        }

		private void EnemyAttacksFirst(Attack playerAttack, Attack enemyAttack)
		{
            /* Player Attacks------------------------------------------------*/
            EnemyEntity.DeductEnergy(enemyAttack);
            PlayerEntity.TakeDamage(EnemyEntity.DealDamage(enemyAttack));
            //Thread.Sleep(2000);
            /* Enemy Attacks ------------------------------------------------*/
            if (PlayerEntity.ReturnCurrentHealth() > 0)
            {
                PlayerEntity.DeductEnergy(playerAttack);
     
                EnemyEntity.TakeDamage(PlayerEntity.DealDamage(playerAttack));
            }
        }

		private void AttackSpeedAreSame(Attack playerAttack, Attack enemyAttack)
		{
            Random randomNum = new Random();
            int randomIndex = randomNum.Next(0, 2);
			if(randomIndex == 0)
			{
				PlayerAttacksFirst(playerAttack, enemyAttack);
			}
			else
			{
				EnemyAttacksFirst(playerAttack, enemyAttack);
			}
        }

		private bool PlayerCannotUseAttack(Player player, Attack attackUsed)
		{
			if(player.ReturnCurrentEnergy() - attackUsed.EnergyUsage > 0)
			{
				return false;
			}
            Console.WriteLine($"Not enough energy to use {attackUsed.Name}");
            return true;
		}

        private bool EnemyCannotUseAttack()
        {
            List<Attack> AttacksListRef = EnemyEntity.ReturnEquipedAttacksList();
            //AttacksListRef.Remove(AttacksListRef.Last());
            int attacksUnableToUse = 0;
            foreach (Attack attack in AttacksListRef)
            {
                if(attack.EnergyUsage > EnemyEntity.ReturnCurrentEnergy())
                {
                    attacksUnableToUse++;
                }
            }
            Console.WriteLine(attacksUnableToUse);
            if (attacksUnableToUse == EnemyEntity.ReturnEquipedAttacksList().Count())
            {
                return true;
            }
            return false;
        }

        /*---------------------------
			Determine Result
		---------------------------*/

		private Entity DetermineResult()
		{
            if (PlayerEntity.ReturnCurrentHealth() > 0)
            {
                PlayerEntity.AddCurrency(CurrencyGained);
                PrintWinScreen();
                Thread.Sleep(2000);

                // Enemy can drop their weapon
                Random randomNum = new Random();
                int randomIndex = randomNum.Next(1, 5);
                if (randomIndex == 1 && !PlayerEntity.ReturnAllWeaponNames().Contains(EnemyEntity.ReturnEquipedWeapon().Name))
                {
                    Console.Clear();
                    Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
                    Console.WriteLine($"\n\t{EnemyEntity.Name} dropped the {EnemyEntity.ReturnEquipedWeapon().Name}!\n", Console.ForegroundColor = ConsoleColor.Yellow);
                    Console.ResetColor();
                    Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
                    Thread.Sleep(2000);
                    PlayerEntity.PickUpWeapon(EnemyEntity.ReturnEquipedWeapon());
                }
                return PlayerEntity;
            }
			else
			{
                PlayerEntity.AddCurrency(CurrencyGained/2);
                PrintLossScreen();
                Thread.Sleep(2000);
                return EnemyEntity;
			}
        }

        private void PrintWinScreen()
        {
			Console.Clear();
            Console.WriteLine("\n\n\n═══════════════════════════════════════════════════════════════════════════");
            string art = @"                                             
                                                                      
                                  ##&&&&&@@@@(                            
                                 &((#%&%#&&@@@&                           
                                  /#%%((.,(&.#                            
                                  %%(*/    @@                             
                                    , .*.*/*%,              #/@           
                           ,*./. ..((.##@,,@%#,&(         %////,          
                          ,.%(((//..%%@@*. .. ./@@     @/*/*,             
                         *,/... ., **..*,.   . ..@(  /.//,                
                         ...,/,//..* @....,,   ..%/.*/,        @%%&&/     
                        .(,*,. *.*.,*...   ,@.,/,**,&%%%%%&%%&%&(%%&&@    
                      ,*,(,#.           .... .,/*.,/..(#%%%#%#&&&%@&#     
                     */,,,,.      ..,,....,&%(*##(&&%(#&*//##&%(//&%&/    
                    (,..  .      **&,.,.,/#*((//**           &/**/%&&     
                   */,.. /      /,***(@@@#,,*.&#/            #***@#&@     
                   &*#,,#,   /////%&@@###(/*,/*@/&               (&@&*,   
                    .,/*.    ,,,*,#/,***,.,@(, .@&&           %**#(@/..&  
                  *.#.%.      ... ,...  . ,..,,.&@@&          ,,,&(@/.... 
                     .,#,    . ,,...   .   .(**,,%@@%            @/&. .../
                    *(*,      .. .(....  */(( ...*@@&              (,../  
                   (&       /. .(*,..     .(***,(.@(@(           .  .  .  
                  &(        ,.  (.. .      .,,.,(,/(/,            *%#     
                 @(         ,..(,  ,         /,,,/#,/             ,       
                @#          (.,.  .           .,*.%@@                     
               @%%%%%((#,*  //.( /             **&@#*/#                   
              &%#%&(#%/**.,,#//&%#             %&(@@&*/#                  
            #&///(/&#/&#. (/,//%/@&.           #@(%&@&*,/(@               
         ,,&%&.**,,(,,*. ##,&,*#%@%@%.        (**,*(&@#/#(&&&@@           
     (%#&,@///.,,.#,**&,.#,**,/*((##*&       /,,.,.,/&%&#&#@@@@@@@@%&%@&  
    ,((%&%****,/,*/(&#((/#((/((#(/%#(#.     /**,,/,./(%,.&&#/#&%&&&@&%&((%
     //%%%%%%%&&(((     (#((%#####&&(((@   ***..,,,,/(/(&/(#*/*//((&&/((/(
			";
            Console.WriteLine(art);
            Console.WriteLine(@"
                __   _______ _   _   _    _  _____ _   _ 
                \ \ / /  _  | | | | | |  | ||  _  | \ | |
                 \ V /| | | | | | | | |  | || | | |  \| |
                  \ / | | | | | | | | |/\| || | | | . ` |
                  | | \ \_/ / |_| | \  /\  /\ \_/ / |\  |
                  \_/  \___/ \___/   \/  \/  \___/\_| \_/
			");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
        }

        private void PrintLossScreen()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n═══════════════════════════════════════════════════════════════════════════");
            string art = @"
                                                                      
                                (/*(/,(                               
                               */,..(**                               
                                *((/(.                                
                           /#    *,..*    (,                          
         ((.***,,*    . //,**.,#/*...(/#,.*../. .    ,,,*.,,(*        
     ,,,.*,,**.*.,&....,.,..(//,***(****##%,,,,,,,..%*./ **,,*,,,,    
                            .,  ./(,*/.  ...                          
                             ., .,**,,. ,,                            
                              .,....,.,,.                             
                              . /.. ,.* .                             
                              #./*,.,,*..                             
                             .,#.,*,*,.%..                            
                             ,,...,,....,.                            
                            .,,,,. ...,,...                           
                            .,,*,..#..,,,,.                           
                            ...,,., ,.,,...                           
                            ...,,., ,..,...                           
                             ..,,     ,,..                            
                             (.,.    ..,./                            
                            ,#,..,   ,.,,#.                           
                            ,, ..,   ,.. ..                           
                            . ,..,   ,.., .                           
                             ,**.     .,/.                            
                               ,.     ..                              
                               **     /,                              
                               /,     *.                              
                              .#.    *...                                               
			";
            Console.WriteLine(art);
            Console.WriteLine(@"
                __   _______ _   _   _     _____ _____ _____ 
                \ \ / /  _  | | | | | |   |  _  /  ___|_   _|
                 \ V /| | | | | | | | |   | | | \ `--.  | |  
                  \ / | | | | | | | | |   | | | |`--. \ | |  
                  | | \ \_/ / |_| | | |___\ \_/ /\__/ / | |  
                  \_/  \___/ \___/  \_____/\___/\____/  \_/   
			");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
        }
    }
}


