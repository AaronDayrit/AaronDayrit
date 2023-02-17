using System;
namespace Final_Project
{
	public class Weapon
	{
		public string Name { get; private set; }
		public double Damage { get; private set; }

		public Weapon(string name, double damage)
		{
			Name = name;
			Damage = damage;
		}

        public Weapon(Weapon weapon)
        {
			Name = weapon.Name;
			Damage = weapon.Damage;
        }
	}
}

