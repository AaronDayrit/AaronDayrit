using System;
namespace Final_Project
{
	public class Monsoon : Entity
	{
        public Monsoon(string name) : base(name)
        {
            TotalHealth = new KeyValuePair<int, double>(1, 150);
            TotalEnergy = new KeyValuePair<int, double>(1, 150);
            EnergyReplenish = new KeyValuePair<int, double>(1, 45);

            CurrentHealth = TotalHealth.Value;
            CurrentEnergy = TotalEnergy.Value;

            SetWeapon();
            SetAttacksList();

            Art = @"
                              ,*                                      
                    ,,,..,....,.........                            
              ,,,.,,........................                        
           **,.,,,............................                      
         .****,,.............................. . .......            
         *.*(*,,.....  .....        .#.  ..  . ...                  
        ***(#*,......  ...,....     ...    ..*,,                    
         ,*/(/*.. ..   ..,***,..    ,.*      .***                   
         ,,,,,......     . ..,...*,,..**      ***.                  
          ,........  .           ***.  .    .***,*                  
           ....../,.,/. . .,,...,**..     ,/*******                 
             ...**/.....***,,,#//*,...    *(//*****.                
                . ,/%#/*,,...,#**,. ..    ,///******                
                   #%,/****,.*,,,,  .,    .//***/(///*              
                    *&&/,,,,...,,.        ./*/***//*****            
                      ((,,...........     ./*****((((*****,         
                      /#,.........    .  .///***.*/////*******.     
                       .. .**..      ... .//**,.   ./////*********  
                         (***,,.. .,.. .,/***,..      .*//**,****** 
                        ******,....*,,***,*.,.......    .*********,*
            ";

        }

        private void SetWeapon()
        {
            Weapon weapon = new Weapon("Dystopia", 35);
            CurrentWeapon = weapon;
        }

        private void SetAttacksList()
        {
            Attack attack1 = new Attack("Force of Magnetism", 2, 70, 90, 40);
            Attack attack2 = new Attack("Stabbing Despair", 2.2, 100, 80, 30);
            Attack attack3 = new Attack("Memes", 2.8, 60, 85, 80);
            EquipedAttacksList.Add(attack1);
            EquipedAttacksList.Add(attack2);
            EquipedAttacksList.Add(attack3);
        }
    }
}


