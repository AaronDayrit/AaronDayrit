using System;
namespace Final_Project
{
	public class Mistral : Entity
	{
        public Mistral(string name) : base(name)
        {
            TotalHealth = new KeyValuePair<int, double>(1, 150);
            TotalEnergy = new KeyValuePair<int, double>(1, 150);
            EnergyReplenish = new KeyValuePair<int, double>(1, 30);

            CurrentHealth = TotalHealth.Value;
            CurrentEnergy = TotalEnergy.Value;

            SetWeapon();
            SetAttacksList();

            Art = @"
                                                            
                       //*//***///((((//                            
                     .*/**#(///////(((*/////                        
                     .,.,,//*,*///(//*/**,,**,,                     
                    ,*##(**#/*,*/////,//(,*/***,                    
                   (@&%#/**(/,,,,****/*(//,***,*..                  
                   &&&#(*,*(*,,,*/****/,*/*.,*,,,,.                 
                   @&#(/*,,/*,,,///****,/**,***/,,*                 
                   @%#(*,**/*,.,/*(/,**,**,,.*/***,.                
                  /***,/,**/,,.,,/(/,//****,/*/*,,,..               
                  , , ..(,,/,,,.,***,(/*/**,/,/,,,...               
                  &#//#@..,,,,, .*,*,##*/*,,/**/.,.,.               
                  &%#(&....,,,,. ,**//(//*,,,*....,,                
                  /%%%%( ...,*,,.,***,****,,,..*****(##(%*          
                 ..&&&%,,...,**,..,*//(**//,,,,,***/(**(%%%&&       
        *..        .%#&/,,,,,*(((,..,,//((*,,.,,*/(//(((##%%@@%     
        **,...   ....%/*.....**(%#,.*,/**,...,,*****/((%%%##@@%(,//(
        /*,....  ,,/,..       ..*/,,,*/(/*////////(((%%%%(///*((/**,
        ,,.. .  .....         .,.,,,*/*,. ..,,***/%@@%((*,/(*..**..*
        ,,..      ...       ..,,,,*/((,,,.  ....,**(#(*,*/,. .,@#.,*
             ..    ...     ...*,,*///,..  ..,*(##(..,..*@/. .//*..,.
        ,....  ... ....   ,,.....,**,..... ..,,**/((.,...*   .. .**,
        ..... ..... .....*,... . ,.. ......,*,*/...,,.,.,.  .. .*,,,
            ";

        }

        private void SetWeapon()
        {
            Weapon weapon = new Weapon("L'Étranger", 30);
            CurrentWeapon = weapon;
        }

        private void SetAttacksList()
        {
            Attack attack1 = new Attack("Marches Du Ciel", 2, 70, 80, 65);
            Attack attack2 = new Attack("Lumiere Du Ciel", 1.5, 100, 80, 30);
            Attack attack3 = new Attack("Cercle De L'ange", 1.8, 80, 85, 50);
            EquipedAttacksList.Add(attack1);
            EquipedAttacksList.Add(attack2);
            EquipedAttacksList.Add(attack3);
        }
    }
}

