using System;
namespace Final_Project
{
	public class Entity: IEntity
	{
        public string Name { get; set;  } 
        protected double CurrentHealth { get; set; }
        protected double CurrentEnergy { get; set; }
        protected KeyValuePair<int, double> TotalHealth { get; set; }
        protected KeyValuePair<int, double> TotalEnergy { get; set; }

        protected KeyValuePair<int, double> EnergyReplenish { get; set; }

        protected Weapon CurrentWeapon { get; set; }
        protected List<Attack> EquipedAttacksList { get; set; }

        public string Art { get; set; }

        protected Entity(string name)
		{
            Name = name;
            EnergyReplenish = new KeyValuePair<int, double>(1, 25);
            EquipedAttacksList = new List<Attack>();
        }

		public void TakeDamage(double damageDealt)
		{
            CurrentHealth -= damageDealt;
		}

		public double DealDamage(Attack attackUsed)
		{
        
            PrintAttack(attackUsed, this);
            if (!DidAttackMiss(attackUsed))
            {
                PrintDamage(attackUsed, this);
                double totalDamage = attackUsed.Multiplier * CurrentWeapon.Damage;
                // if attack was rest
                if(totalDamage == 0)
                {
                    ReplenishEnergy();
                }
                return totalDamage;
            }
            //Thread.Sleep(2000);
            PrintMissed();
            return 0;
		}

        public void ReplenishEnergy()
        {
            if (CurrentEnergy + EnergyReplenish.Value > TotalEnergy.Value)
            {
                CurrentEnergy = TotalEnergy.Value;
            }
            else
            {
                
                CurrentEnergy += EnergyReplenish.Value;
            }
        }

        public void PrintAttack(Attack attack, Entity entity)
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
            if (this is Player)
            {
                Console.WriteLine($"\n\t{this.Name} used {attack.Name}!\n", Console.ForegroundColor = ConsoleColor.Cyan);
            }
            else
            {
                Console.WriteLine($"\n\t{this.Name} used {attack.Name}!\n", Console.ForegroundColor = ConsoleColor.Red);
            }
            Console.ResetColor();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
            Thread.Sleep(2000);
        }

        public void PrintDamage(Attack attack, Entity entity)
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
            if (this is Player)
            {
                Console.WriteLine($"\n\t{this.Name} dealt {attack.Multiplier * entity.CurrentWeapon.Damage} damage!\n", Console.ForegroundColor = ConsoleColor.Cyan);
            }
            else
            {
                Console.WriteLine($"\n\t{this.Name} dealt {attack.Multiplier * entity.CurrentWeapon.Damage} damage!\n", Console.ForegroundColor = ConsoleColor.Red);
            }
            Console.ResetColor();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
            Thread.Sleep(2000);
        }

        public void PrintMissed()
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
            Console.WriteLine($"\n\t{this.Name} missed!\n");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════");
            Thread.Sleep(2000);
        }

        public void DisplayUI()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"\tHeath  | {CurrentHealth}% ");
            for (int i = 0; i < CurrentHealth / 10; i++)
            {
                sb.Append("═");
            }

            sb.Append($"\n\tEnergy | {CurrentEnergy}% ");
            for (int i = 0; i < CurrentEnergy / 10; i++)
            {
                sb.Append("═");
            }

            if(this is Player)
            {
                Console.WriteLine($"\t{this.Name}");
                Console.WriteLine($"{sb.ToString()}\n", Console.ForegroundColor = ConsoleColor.Cyan);
            }
            else
            {
                Console.WriteLine($"\t{this.Name}");
                Console.WriteLine($"{sb.ToString()}\n", Console.ForegroundColor = ConsoleColor.Red);
            }
            Console.ResetColor();
        }

        public void ResetStats()
        {
            CurrentHealth = TotalHealth.Value;
            CurrentEnergy = TotalHealth.Value;
        }

        /*------------------------------
            Return Protected Properties 
         ------------------------------*/

        public List<Attack> ReturnEquipedAttacksList()
        {
            return this.EquipedAttacksList;
        }

        public double ReturnCurrentHealth()
        {
            return this.CurrentHealth;
        }

        public double ReturnCurrentEnergy()
        {
            return this.CurrentEnergy;
        }
        public KeyValuePair<int, double> ReturnTotalHealth()
        {
            return this.TotalHealth;
        }
        public KeyValuePair<int,double> ReturnTotalEnergy()
        {
            return this.TotalEnergy;
        }

        public KeyValuePair<int, double> ReturnEnergyReplenish()
        {
            return this.EnergyReplenish;
        }

        public void DeductEnergy(Attack attack)
        {
            CurrentEnergy -= attack.EnergyUsage;
        }

        public Weapon ReturnEquipedWeapon()
        {
            return this.CurrentWeapon;
        }


        /*------------------------------
            Helper Functions 
         ------------------------------*/

        private bool DidAttackMiss(Attack attackUsed)
        {
            if(attackUsed.Accuracy == 100)
            {
                return false;
            }
            Random random = new Random();
            int shotNum = random.Next(0, 101);
            if(shotNum > 0 && shotNum < attackUsed.Accuracy)
            {
                return false;
            }
            return true;
        }
    }
}

