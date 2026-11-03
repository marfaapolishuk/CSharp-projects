namespace Lab3_Game2
{
    internal class Hunter : IHealable
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Gold { get; protected set; }
        public int Arrows { get; protected set; }
        public int Loot { get; protected set; }

        public Hunter(string name, int health, int gold, int arrows)
        {
            Name = name;
            Health = health;
            Gold = gold;
            Arrows = arrows;
            Loot = 0;
        }

        public virtual void Hunt()
        {
            if (Arrows <= 0)
            {
                Console.WriteLine($"{Name} не має стріл для полювання!");
                return;
            }

            if (Health <= 0)
            {
                Console.WriteLine($"{Name} виснажений і не може полювати!");
                return;
            }

            Console.WriteLine("Мисливець вирушив на полювання.");
            Arrows--;
            Console.WriteLine("-1 стріла");

            Health -= 10; // Стандартна втрата здоров'я

            Random rand = new Random();
            int foundLoot = rand.Next(0, 2);
           
           if (foundLoot > 0)
            {
                int foundGold = 15; // Нагорода для звичайного мисливця

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

        public void BuyArrows(int count)
        {
            int totalCost = count * 4;
            if (Gold >= totalCost)
            {
                Gold -= totalCost;
                Arrows += count;
                Console.WriteLine($"{Name} успішно придбав {count} стріл за {totalCost} золота.");
            }
            else
            {
                Console.WriteLine($"{Name} не має достатньо золота! Потрібно {totalCost}, а є лише {Gold}.");
            }
        }

        public virtual void Heal()
        {
            int healCost = 10;
            int healAmount = 25;

            if (Gold >= healCost)
            {
                if (Health >= 100)
                {
                    Console.WriteLine($"{Name} вже має максимальне здоров'я (100)!");
                    return;
                }

                Gold -= healCost;
                Health += healAmount;
                if (Health > 100) Health = 100;

                Console.WriteLine("+25 здоров'я");
                Console.WriteLine($"{Name} вилікувався за {healCost} золота! Здоров'я: {Health}");
            }
            else
            {
                Console.WriteLine($"{Name} має занадто мало золота для лікування!");
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"--- Мисливець: {Name} ---");
            Console.WriteLine($"Здоров'я: {Health}");
            Console.WriteLine($"Золото: {Gold}");
            Console.WriteLine($"Стріли: {Arrows}");
            Console.WriteLine($"Здобич: {Loot}");
            Console.WriteLine("-------------------------");
        }
    }
}
