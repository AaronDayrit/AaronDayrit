using System;
namespace Final_Project
{
	public class Cyborg: Entity
	{ 
		public Cyborg(string name, KeyValuePair<int, double> totalHealth, KeyValuePair<int, double> totalEnergy,
            KeyValuePair<int, double> energyReplenish, double weaponUpgradeMultiplier) : base(name)
		{
            TotalHealth = totalHealth;
            TotalEnergy = totalEnergy;
            EnergyReplenish = energyReplenish;

            CurrentHealth = TotalHealth.Value;
            CurrentEnergy = TotalEnergy.Value;

            SetWeapon(weaponUpgradeMultiplier);
            SetAttacksList();


            Art = @"
                                                            
                    %@@@@@@@@@@@&%%%                                
                  @@@@@@@@@@@@&%%##((/(                             
                 @@@@@@@@@@@@@&%##((/**/                            
               *@@@@@@@@@@@@@&%##(*.,,.*/                           
              ,,.#%&&&@@&&&&&#(,***,,.*.*.    .,,,,,,*              
              ,,/#(((/****((/%(/*,,,.,...*.  .....,,,,***           
              ,,**//(#####(/****,,........*     ....,,,,,***(       
              ,.,******////**,,,,.... ..,,&,,... ........,,,//**,   
               ..,,*********,,,..... ..,,. ....,..   .   .,,,.,,,..,
            .  //,.,,********/*... . .,,.,.   ..,,,..    ..  ....   
               ////(.,,****,**... ...... .    ..,..,*/*,..  ...     
                ////./.,,,,,,,... .... ..  ...,*,,,,..,.***,..      
                ****,..*.,,,,..... .. .   ...///***/.,.,.,,,......  
                **,***.....,.... .  ..    .,((*..*.   .,***,.       
               ****, ,...,......   .     . (,,#.  #//////((/*,,,.  .
              ****.  .,.   ,,...,. .    .,**..(%%#(((((((/(///*,... 
              ,,*...,.  .        .. . ...,.(#%%%%%((%((/(((//**,....
             .**,.*..*   .    ... .  ..,,.(#####%%##(/(((((//**,,,. 
             ,,**..,., .,,.......    .,*  ,**////((##(/%%##(/**,,, .
              *,.. .., .,,,  ..      *,.  ((##%%%%##(((/*##((//(.*/(
               .   ...  .(((. ,     .,/  ,**///((((##%%#(/**##,(&##@
                ......* %%%%**...,,,,,.  .,,*****//(#(/**/(@%#(##(((
               .. .....,/%....,..,,../  /.. *..,*,**,.*((#@&%(((((/(
            ";

        }

        private void SetWeapon(double weaponUpgradeMultiplier)
        {
            Weapon highFrequencyMachete = new Weapon("High-Frequency Machete", 10 * weaponUpgradeMultiplier);
            CurrentWeapon = highFrequencyMachete;
        }

        private void SetAttacksList()
        {
            Attack lightAttack = new Attack("Light Attack", 1, 100, 70, 20);
            Attack crossSlash = new Attack("Cross Slash", 1.2, 90, 70, 40);
            EquipedAttacksList.Add(lightAttack);
            EquipedAttacksList.Add(crossSlash);
        }
    }
}

