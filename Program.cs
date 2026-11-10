using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueDungeon0125
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //статы и начальная позиция
            Console.OutputEncoding = Encoding.Unicode;
            int playerHealth = 100, maxHealth = 100, gold = 0,
                posX = 0, posY = 3;

            // считывание и обработка данных (урон)
            int enemyDamage;
            Console.Write("Введите урон противника: ");
            int.TryParse(Console.ReadLine(), out enemyDamage);
            playerHealth -= enemyDamage;
            if (playerHealth < 0)
            {
                playerHealth = 0;
            }
            Console.SetCursorPosition(0, 3);
            

            //переменные для поля
            int mapWidth = 10, mapHeight = 10, playerInputPosition = 15,
                hudCursorPosition = 13;

            // вывод игрового поля
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j< mapWidth; j++)
                {
                    Console.Write("# ");
                }
                Console.WriteLine();
            }
            // вывод персонажа
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(posX, posY);
            Console.Write("H");
            Console.ResetColor();
            Console.SetCursorPosition(0, hudCursorPosition);

            // вывод строки состояния
            Console.WriteLine($"♥️[{playerHealth}/{maxHealth}] ${gold, -5}");
            
            // передвижение игрока
            while (true)
            {
                Console.SetCursorPosition(0, playerInputPosition);
                Console.Write("Двинуться: ");
                var key = Console.ReadKey();
                int stepX = 0, stepY = 0;
                switch (key.Key)
                {
                    //right
                    case ConsoleKey.D:
                        if (posX / 2 == mapWidth - 1)
                            continue;
                        stepX += 2;

                        break;
                    //down
                    case ConsoleKey.S:
                        if (posY-3 == mapWidth - 1)//поле сдвинуто на три строки вниз, добавил такой же шаг в границы
                            continue;
                        stepY += 1;
                        break;
                    //left
                    case ConsoleKey.A:
                        if (posX / 2 == 0)
                            continue;
                        stepX -= 2;
                        break;
                    //up
                    case ConsoleKey.W:
                        if (posY-3 == 0)//поле сдвинуто на три строки вниз, добавил такой же шаг в границы
                            continue;
                        stepY -= 1;
                        break;
                }

                //вывод положения игрока по имеющимся данным после проверки клавиши
                Console.SetCursorPosition(posX, posY);
                Console.Write("#");
                posX += stepX;
                posY += stepY;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(posX, posY);
                Console.Write("H");
                Console.ResetColor();
            
            }
        }
    }
}
