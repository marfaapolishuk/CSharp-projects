namespace Lab3_Game
{
    internal class Hunter
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Gold { get; private set; }
        public int Arrows { get; private set; }
        public int Loot { get; private set; } 

        public Hunter(string name, int health, int gold, int arrows)
        {
            Name = name;
            Health = health;
            Gold = gold;
            Arrows = arrows;
        }

        public void Hunt()
        {
            if (Arrows <= 0)
            {
                Console.WriteLine($"{Name} не має стріл для полювання! Потрібно купити стріли.");
                return;
            }

            if (Health <= 0)
            {
                Console.WriteLine($"{Name} занадто виснажений і не може полювати (0 здоров'я)!");
                return;
            }

            Console.WriteLine("Мисливець вирушив на полювання.");

            Arrows--;     
            Console.WriteLine("-1 стріла");

            Health -= 10;  

            Random rand = new Random();
            int foundLoot = rand.Next(0, 2);

            if (foundLoot > 0)
            {
                int foundGold = 15;

                Loot += foundLoot;
                Gold += foundGold;

                Console.WriteLine("+1 здобич");
                Console.WriteLine($"Отримано золота: {foundGold}");
            }
            else
            {
                Console.WriteLine($"Полювання невдале.");
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
