using System;
namespace Final_Project
{
	public class Attack
	{
		public string Name { get; private set; }
		public double Multiplier { get; private set; }
        public double Accuracy { get; private set; }
		public double Speed { get; private set; }
		public double EnergyUsage { get; private set; }

        public Attack(string name, double multiplier, double accuracy, double speed, double energyUsage)
		{
			Name = name;
			Multiplier = multiplier;
			Accuracy = accuracy;
			Speed = speed;
			EnergyUsage = energyUsage;
		}

		// Overload of attack to have a placeholder for an attack that the player
		// will never be able to use, used for Ecounter.cs 
		public Attack(double energyUsage)
		{
			EnergyUsage = energyUsage;
		}

		public Attack returnAttack()
		{
			return this;
		}
	}
}

