using System;
namespace Final_Project
{
	public class Player: Entity
	{
        public int BP { get; set; }
        public List<Weapon> WeaponsList { get; private set; }
        public Player(string name) : base(name)

		{
			TotalHealth = new KeyValuePair<int, double>(1, 100);
			TotalEnergy = new KeyValuePair<int, double>(1, 100);
			BP = 2000;
			WeaponsList = new List<Weapon>();

            CurrentHealth = TotalHealth.Value;
            CurrentEnergy = TotalHealth.Value;

            SetWeapon();
			SetAttacksList();
        }

        /*-----------------------------------
			Main Functionality
		 -----------------------------------*/

        public void UpgradeStat(string stat)
        {
            switch (stat)
            {
                case "Total Health":
                    
                    TotalHealth = new KeyValuePair<int, double>(TotalHealth.Key + 1, 100 + (TotalHealth.Key * 20));
                    break;
                case "Total Energy":
                    TotalEnergy = new KeyValuePair<int, double>(TotalEnergy.Key + 1, 100 + (TotalEnergy.Key * 20));
                    break;
                case "Energy Replenish":
                    EnergyReplenish = new KeyValuePair<int, double>(EnergyReplenish.Key + 1, EnergyReplenish.Value + 10);
                    break;
            }
        }

        public void AddCurrency(int amount)
        {
            BP += amount;
        }
        public void RemoveCurrency(int amount)
        {
            BP -= amount;
        }

        public void EquipWeapon(Weapon weaponToEquip)
        {
            CurrentWeapon = weaponToEquip;
        }

        public void EquipAttack(Attack attackToEquip)
        {
            EquipedAttacksList.Add(attackToEquip);
        }

        public void PickUpWeapon(Weapon weapon)
        {
            WeaponsList.Add(weapon);
        }

        /*-----------------------------------
			Helper Functions 
		 -----------------------------------*/
        private void SetWeapon()
		{
			Weapon highFrequencyBlade = new Weapon("High-Frequency Blade", 20);
			WeaponsList.Add(highFrequencyBlade);
			CurrentWeapon = highFrequencyBlade;

            Weapon yamato = new Weapon("Yamato", 1000000);
            WeaponsList.Add(yamato);
        }

		private void SetAttacksList()
		{
			Attack lightAttack = new Attack("Light Attack", 1, 100, 70, 25);
			Attack strongAttack = new Attack("Strong Attack", 1.4, 80, 50, 35);
            Attack Rest = new Attack("Rest", 0, 100, 0, -(EnergyReplenish.Value));
            EquipedAttacksList.Add(lightAttack);
            EquipedAttacksList.Add(strongAttack);
            EquipedAttacksList.Add(Rest);
        }

        public List<Weapon> ReturnWeaponsList()
        {
            return WeaponsList;
        }

        public List<string> ReturnAllWeaponNames()
        {
            List<string> names = new List<string>();
            foreach (Weapon weapon in WeaponsList)
            {
                names.Add(weapon.Name);
            }
            return names;
        }

        public List<string> ReturnAllAttackNames()
        {
            List<string> names = new List<string>();
            foreach (Attack attack in EquipedAttacksList)
            {
                names.Add(attack.Name);
            }
            return names;
        }
    }
}

