using System;
namespace Final_Project
{
	public class Armstrong: Entity
	{
        public Armstrong(string name) : base(name)
        {
            TotalHealth = new KeyValuePair<int, double>(1, 300);
            TotalEnergy = new KeyValuePair<int, double>(1, 300);
            EnergyReplenish = new KeyValuePair<int, double>(1, 50);

            CurrentHealth = TotalHealth.Value;
            CurrentEnergy = TotalEnergy.Value;

            SetWeapon();
            SetAttacksList();

            Art = @"
                              ,,,,***,,,........,.                  
                           **&&&&&&&%%##(((/**......,               
                          #&&&&&&&&%%##((/**,,,,.  ...,*            
                        /&&&&&@@@&&%##((/*,,,,,,..  .,,*/           
                        #%&&&&&@&&%##(/*,,,,,,,,.......*((          
                       (%%%%%&&&&##((/********,..... ..,*/          
                       #%&%#&&&%&#&#%%##(((//*,.....   .*           
                       (**,..*(%%(*,.   .....  ....  ...,*          
                      *,**/#((,%&*#/#/,..,,....  .......,/          
                    **(/,,/((/*&&/*@.,/*,,,,,*,,.....  ...,         
                     *//%#%%#*%&#,,.,*/((((((*,..............       
                      /###/###%#/,.*,,,////*,,,...,.........,       
                       %%%/*/..,. ....,****/*,..............        
                       #(/###(((*,,,.,,,,,,***.......,.....         
                       ((#/,,...*,/*,,.. .,/*/.........,...         
                       /##%%%%###(/*,.,****,*,..........,*          
                        (####%%&%%%#((//****,........,....,*        
                         /(#%%&@%%&&#(**,,,............... .*,      
                       /&%**//((*///*,,.................   .,,,,**  
                     &&@%#*,..,,,,,,.................... . .,##*,,.,
               .%&%%&@&@&%/*,.*/,,......................   .(%#*,.,*
           %@&&&&,#&&&(,...*/,./(/*.,,,,................  .*/.   ...
         %&&%%%##(*,....,,,*,//,///***,,,..............  .. .,.  ...
            ";

        }

        private void SetWeapon()
        {
            Weapon weapon = new Weapon("Right Hand of America", 50);
            CurrentWeapon = weapon;
        }

        private void SetAttacksList()
        {
            Attack attack1 = new Attack("I have a dream!", 2, 70, 100, 60);
            Attack attack2 = new Attack("Nanomachines", 1.5, 75, 90, 35);
            Attack attack3 = new Attack("Mother of all Omelettes", 4, 40, 50, 100);
            EquipedAttacksList.Add(attack1);
            EquipedAttacksList.Add(attack2);
            EquipedAttacksList.Add(attack3);
        }
    }
}

