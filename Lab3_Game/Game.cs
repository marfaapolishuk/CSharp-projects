namespace Lab3_Game
{
    internal class Game
    {
        public void Start()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== ГРА МИСЛИВЕЦЬ ===");
            Console.WriteLine("Оберіть режим гри:");
            Console.WriteLine("1. Грати за одного мисливця");
            Console.WriteLine("2. Змагання між двома мисливцями");
            Console.Write("Вибрати (1 або 2): ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                PlaySinglePlayer();
            }
            else if (choice == "2")
            {
                PlayCompetition();
            }
            else
            {
                Console.WriteLine("Невірний вибір. Перезапустіть програму.");
            }
        }

        private void PlaySinglePlayer()
        {
            Hunter hunter = new Hunter("Leon", 100, 50, 5);

            Console.WriteLine("\nПочаткова інформація про мисливця:");
            hunter.ShowInfo();

            bool playing = true;
            while (playing)
            {
                Console.WriteLine("\n--- МЕНЮ ДІЙ (Один гравець) ---");
                Console.WriteLine("1. Полювати");
                Console.WriteLine("2. Купити стріли");
                Console.WriteLine("3. Переглянути інформацію");
                Console.WriteLine("4. Вийти");
                Console.Write("Оберіть номер дії: ");

                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        hunter.Hunt();
                        break;
                    case "2":
                        Console.Write("Купити стріли (ціна 1 стріли = 4 золота): ");
                        if (int.TryParse(Console.ReadLine(), out int count) && count > 0)
                        {
                            hunter.BuyArrows(count);
                        }
                        else
                        {
                            Console.WriteLine("Помилка: введіть коректне додатне число!");
                        }
                        break;
                    case "3":
                        hunter.ShowInfo();
                        break;
                    case "4":
                        playing = false;
                        Console.WriteLine("Гру завершено.");
                        break;
                    default:
                        Console.WriteLine("Невідома дія. Спробуйте ще раз.");
                        break;
                }

                if (hunter.Health <= 0)
                {
                    Console.WriteLine($"\n{hunter.Name} втратив все здоров'я! Гра закінчилася.");
                    hunter.ShowInfo();
                    playing = false;
                }
            }
        }
        private void PlayCompetition()
        {
            Console.WriteLine("\n--- ЗМАГАННЯ ДВОХ МИСЛИВЦІВ ---");
            Hunter hunter1 = new Hunter("Leon", 100, 50, 6);
            Hunter hunter2 = new Hunter("Chris", 100, 50, 6);

            Console.WriteLine("\nПочаткова інформація про мисливців:");
            hunter1.ShowInfo();
            hunter2.ShowInfo();

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n===== МЕНЮ ДІЙ ЗМАГАННЯ (Два гравці) =====");
                Console.WriteLine("1. Полювання");
                Console.WriteLine("2. Купити стріли");
                Console.WriteLine("3. Переглянути інформацію обох мисливців");
                Console.WriteLine("4. Вийти та порівняти результати");
                Console.Write("Оберіть дію: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string? huntChoice = ChooseHunter(hunter1.Name, hunter2.Name);
                        if (huntChoice == "1")
                        {
                            hunter1.Hunt();
                        }
                        else if (huntChoice == "2")
                        {
                            hunter2.Hunt();
                        }
                        else
                        {
                            Console.WriteLine("Невідомий мисливець.");
                        }
                        break;

                    case "2":
                        string? buyChoice = ChooseHunter(hunter1.Name, hunter2.Name);
                        if (buyChoice != "1" && buyChoice != "2")
                        {
                            Console.WriteLine("Невідомий мисливець.");
                            continue;
                        }

                        Console.Write("Купити стріли (ціна 1 стріли = 4 золота): ");
                        if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
                        {
                            if (buyChoice == "1")
                            {
                                hunter1.BuyArrows(number);
                            }
                            else if (buyChoice == "2")
                            {
                                hunter2.BuyArrows(number);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некоректна кількість стріл.");
                        }
                        break;

                    case "3":
                        Console.WriteLine();
                        hunter1.ShowInfo();
                        hunter2.ShowInfo();
                        break;

                    case "4":
                        isRunning = false;
                        Console.WriteLine("Змагання завершено!");
                        break;

                    default:
                        Console.WriteLine("Невідома команда. Спробуйте ще раз.");
                        break;
                }

                if (hunter1.Health <= 0 && hunter2.Health <= 0)
                {
                    Console.WriteLine("\nОбидва мисливці виснажені (0 здоров'я)! Гра закінчилася.");
                    isRunning = false;
                }
            }

            Console.WriteLine("\n=== РЕЗУЛЬТАТИ ЗМАГАННЯ ===");
            hunter1.ShowInfo();
            hunter2.ShowInfo();

            Console.WriteLine("\n=== ПОРІВНЯННЯ ЗДОБИЧІ ===");
            if (hunter1.Loot > hunter2.Loot)
            {
                Console.WriteLine($"Переможець: {hunter1.Name} із кількістю здобичі: {hunter1.Loot}!");
            }
            else if (hunter2.Loot > hunter1.Loot)
            {
                Console.WriteLine($"Переможець: {hunter2.Name} із кількістю здобичі: {hunter2.Loot}!");
            }
            else
            {
                Console.WriteLine($"Нічия! Обидва мисливці здобули однакову кількість здобичі: {hunter1.Loot}.");
            }
        }
        private string? ChooseHunter(string name1, string name2)
        {
            Console.WriteLine("Оберіть мисливця:");
            Console.WriteLine($"1. {name1}");
            Console.WriteLine($"2. {name2}");
            Console.Write("Ваш вибір: ");
            return Console.ReadLine();
        }
    }
}
