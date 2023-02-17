using System;
namespace Final_Project
{
	public class BladeWolf : Entity
	{
        public BladeWolf(string name) : base(name)
        {
            TotalHealth = new KeyValuePair<int, double>(1, 130);
            TotalEnergy = new KeyValuePair<int, double>(1, 130);
            EnergyReplenish = new KeyValuePair<int, double>(1, 45);

            CurrentHealth = TotalHealth.Value;
            CurrentEnergy = TotalEnergy.Value;

            SetWeapon();
            SetAttacksList();

            Art = @"
                                                               @@@@   
                                                      ,     . ...,/ 
                                                  ..       ... ...,*
                                             ,,.           .........
                            .           *,..           ..........,,.
                        ..,..     /.....             ...............
                      ... .     ,,,.          .    .................
                     .  .,*//(#,...             .,.,,...............
                   ,.,*@@@&,,...             .***,,,,,..............
                   .,&%*//*...             ,***,,,,,.....,...,,...  
                 ..(****/,,.            .,,,,,,......  ..   ...     
                ..#*//**,.            .....,.    .,   .......  ..   
               ,@(/**,,.              .,//,,..... ....   .....,,..  
              @(//**,,.     .      . ..*//*../**,,,...  ...   .,,,..
            (//////((/.         ......*** ../(/,*,,.     ..  ..**,..
           /*/*(%&&%#(.       .,.........     .***,..........,*,,*..
         #,*//#&#/*,,.    ,*,*,,............  ....,........*(&((,...
         ///(//,**.,..*,.,,*/.. ......,,.................*.*/(#(....
         &/ ..,,.**.*,,(.........................   . ........,.....
             *.,.*,,..,,...............................,,...........
            ../.,.................          ..........,.,...........
            *. ..............                (/,,.......,..........(
           (........,...                     *****......   .,.  .../
           /,,.,,                             ,/(/,*....        .../
                                               .....,...      ......
                                            . .. ....*,.    .......,
                                         .....    . ,*.............,
            ";

        }

        private void SetWeapon()
        {
            Weapon weapon = new Weapon("Beowulf Gauntlets", 25);
            CurrentWeapon = weapon;
        }

        private void SetAttacksList()
        {
            Attack attack1 = new Attack("Rising Dragon", 2, 100, 80, 60);
            Attack attack2 = new Attack("Air Hike", 1.8, 90, 100, 50);
            Attack attack3 = new Attack("Beast Uppercut", 1.4, 80, 100, 50);
            EquipedAttacksList.Add(attack1);
            EquipedAttacksList.Add(attack2);
            EquipedAttacksList.Add(attack3);
        }
    }
}

