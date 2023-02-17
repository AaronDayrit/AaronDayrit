using System;
namespace Final_Project
{
	public interface IEntity
	{
		void TakeDamage(double damageDealt);
		double DealDamage(Attack attackUsed);
	}
}

