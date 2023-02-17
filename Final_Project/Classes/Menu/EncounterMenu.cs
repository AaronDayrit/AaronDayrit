using System;
using System.Numerics;

namespace Final_Project
{
	public class EncounterMenu : Menu
	{
        public string EnemyArt { get; private set; }
        public Player PlayerEntity { get; private set; }
        public Entity EnemyEntity { get; private set; }

        public EncounterMenu(string prompt, List<string> options, string enemyArt, Player player, Entity enemy) : base(prompt, options)
        {
            EnemyArt = enemyArt;
            PlayerEntity = player;
            EnemyEntity = enemy;
        }

        public override void DisplayOptions(int selectedOptionIndex)
        {
            Console.WriteLine(EnemyArt);
            base.DisplayOptions(selectedOption);
            PlayerEntity.DisplayUI();
            EnemyEntity.DisplayUI();
        }
    }
}

