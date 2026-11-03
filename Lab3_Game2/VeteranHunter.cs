namespace Lab3_Game2
{
    internal class VeteranHunter : Hunter
    {
        public VeteranHunter(string name, int health, int gold, int arrows): base(name, health, gold, arrows + 3)
        {

        }

        public override void Hunt()
        {
            if (Arrows <= 0)
            {
                Console.WriteLine($"{Name} (Ветеран) не має стріл для полювання!");
                return;
            }

            if (Health <= 0)
            {
                Console.WriteLine($"{Name} (Ветеран) виснажений!");
                return;
            }

            Console.WriteLine("Ветеран вирушив на полювання.");
            Arrows--;
            Console.WriteLine("-1 стріла");

            Health -= 5;

            Random rand = new Random();
            int foundLoot = rand.Next(0, 2);

            if (foundLoot > 0)
            {
                int foundGold = 20; // Бонус ветерана: більше золота за успіх

                Loot += foundLoot;
                Gold += foundGold;
                Console.WriteLine("+1 здобич");
                Console.WriteLine($"Отримано золота: {foundGold}");
            }
            else
            {
                Console.WriteLine("Полювання невдале.");
            }

            if (Health < 0) Health = 0;
        }

        public override void Heal()
        {
            int healCost = 8;
            int healAmount = 35;

            if (Gold >= healCost)
            {
                if (Health >= 100)
                {
                    Console.WriteLine($"{Name} (Ветеран) вже має максимальне здоров'я!");
                    return;
                }

                Gold -= healCost;
                Health += healAmount;
                if (Health > 100) Health = 100;

                Console.WriteLine("+35 здоров'я (бонус ветерана!)");
                Console.WriteLine($"{Name} (Ветеран) застосував польову медицину за {healCost} золота! Здоров'я: {Health}");
            }
            else
            {
                Console.WriteLine($"Недостатньо золота для лікування ветерана!");
            }
        }
    }
}
