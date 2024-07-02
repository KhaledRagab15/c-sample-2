using System;
using System.Threading;

namespace Khaled_Sample_2
{
    class SnakeGame
    {
        int height = 20;
        int width = 30;

        int[] X = new int[50];
        int[] Y = new int[50];

        int x_Fruit;
        int y_Fruit;

        int parts = 4; //initial parts of snake

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'W';

        Random random = new Random(); // random placement of fruit

        public SnakeGame()
        {
            X[0] = 4;
            Y[0] = 4;
            Console.CursorVisible = false;
            x_Fruit = random.Next(2, (width - 2));
            y_Fruit = random.Next(2, (height - 2));
        }

        public void WriteBoard() //draw of borders
        {
            Console.Clear();
            for (int i = 1; i <= (width + 2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("=");
            }
            for (int i = 1; i <= (width + 2); i++)
            {
                Console.SetCursorPosition(i, (height + 2));
                Console.Write("=");
            }
            for (int i = 1; i <= (height + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("=");
            }
            for (int i = 1; i <= (height + 1); i++)
            {
                Console.SetCursorPosition((width + 2), i);
                Console.Write("=");
            }
        }

        public void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = char.ToLower(keyInfo.KeyChar); // Ensure lowercase comparison
            }
        }

        public void write_Point(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
        }

        public void logic()
        {
            if (X[0] == x_Fruit && Y[0] == y_Fruit)
            {
                parts++; //increment for snake parts
                x_Fruit = random.Next(2, (width - 2));
                y_Fruit = random.Next(2, (height - 2));
            }

            for (int i = parts - 1; i > 0; i--)
            {
                X[i] = X[i - 1];
                Y[i] = Y[i - 1];
            }

            switch (key)
            {
                case 'w': //up
                    Y[0]--;
                    break;
                case 's'://down
                    Y[0]++;
                    break;
                case 'a': //left
                    X[0]--;
                    break;
                case 'd': //right
                    X[0]++;
                    break;
            }

            for (int i = 0; i < parts; i++)
            {
                write_Point(X[i], Y[i]);
            }
            write_Point(x_Fruit, y_Fruit);

            Thread.Sleep(100); // Adjust the speed of the snake
        }

        static void Main(string[] args)
        {
            SnakeGame snake = new SnakeGame();
            while (true)
            {
                snake.WriteBoard(); // draw of board
                snake.Input();
                snake.logic();
            }
        }
    }
}
