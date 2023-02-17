using System;
namespace Final_Project
{
	public class Sundowner : Entity
	{
        public Sundowner(string name) : base(name)
        {
            TotalHealth = new KeyValuePair<int, double>(1, 180);
            TotalEnergy = new KeyValuePair<int, double>(1, 180);
            EnergyReplenish = new KeyValuePair<int, double>(1, 35);

            CurrentHealth = TotalHealth.Value;
            CurrentEnergy = TotalEnergy.Value;

            SetWeapon();
            SetAttacksList();

            Art = @"
                           (%********                                   
                        (((((##%%%%%%&@@                            
                    //*///((####%%%%&&&&@@@@.                       
                  ****//(((###%%%%&&&&&&&&@@@@@                     
                 //***///((##%%&&&&&%%/@&&&&&&&@* *.                
                ///****//((##%%%&&&&&%%%&&&&&&%%&(*,/*.             
               ,**/*****///*##%%%%%&&&&&&&&&&%#,*/,,,,*//           
              ,*//******,/((((###%%%%&&&&&/*/**,,...,,,*,*          
            ,*..//******/(((((#####%%&&&&//.,,,,,,..,,,****         
           **,,.//********//*,,...,***(#%%/*.,,,,,,..,,,**,**       
          *..  ./*,.... .**#/*...,***///(#***.*****,.,,,*,*,,       
          ,.  ..*,.......*/##((//*///((#%%#*,,.*****,,,,*,,,        
         ,..  ..**,,,,.,**/%%##((##(((#%%%#*,,/.***//*,.,,,*        
         ..  ....**,,,,,,**(####(.,**/(##%#*,........ .,**#****     
        *..  ...#**,,...,,.,*..,*(((/*,.,/(,.,.....*.,..,,*/,,**    
         .     ..#*...,,,....,*////(((/**//,,,.,..  ,,. .......,*/( 
                . *,.,,,,..     .*.*(*,,**,..,..*,,,       ....,,*//
                .  ,....,,...,...,**/*,.,...,,,*..     ...........,,
                . , ,........,,*/(***,,..,..,..*       .............
                 ..,. . ..*,,,,,,***,.....*,..,        .............
                  ,,.........   .......,..........  ................
                    ...... .    . .**,,,*,........   ...............
                      ........  .....,,**,........ ................ 
                   ..   .,...  .   ..,.,,,........................  
            ";

        }

        private void SetWeapon()
        {
            Weapon weapon = new Weapon("Bloodlust", 40);
            CurrentWeapon = weapon;
        }

        private void SetAttacksList()
        {
            Attack attack1 = new Attack("Wirlwind", 2, 80, 80, 45);
            Attack attack2 = new Attack("Cyclone", 1.8, 90, 85, 30);
            Attack attack3 = new Attack("Red Sun", 2.5, 100, 50, 80);
            EquipedAttacksList.Add(attack1);
            EquipedAttacksList.Add(attack2);
            EquipedAttacksList.Add(attack3);
        }
    }
}

