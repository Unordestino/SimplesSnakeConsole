using System;
using System.Threading;


namespace SimplesSnakeConsole {
    public class Game {
        int Height = 20;
        int Width = 30;

        int[] X = new int[50];
        int[] Y = new int[50];

        int fruitX;
        int fruitY;

        int parts;
        int score;
        int temp = 90;

        ConsoleKeyInfo KeyInfo = new ConsoleKeyInfo();
        char Key = 'w';

        public bool Continue;

        Random rnd = new Random();

        public Game() {
            X[0] = 10;
            Y[0] = 15;
            Continue = true;
            Console.CursorVisible = false;
            fruitX = rnd.Next(2, (Width - 2));
            fruitY = rnd.Next(2, (Height - 2));
            parts = 3;
            score = 0;
        }

        public void CleanColor() {
            Console.ResetColor();
        }

        public void Msg() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.SetCursorPosition(5, 8);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Atenção a cobra em si não tem colisor mas as paredes sim                       ");
            Console.SetCursorPosition(5, 9);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("o desafio do game é que a cada comida coletada a cobrinha aumenta a velocidade ");
            Console.SetCursorPosition(5, 10);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Game criando por Biotec, Precione qual quer tecla para continuar!!!            ");
            Console.ReadKey();


            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
        }

        public void WriteBoard() {
               
            for (int i = 1; i <= 21; i++) {
                Console.SetCursorPosition(2, i);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("                                ");
            }// Color fundo tela

            for (int i = 1; i <= (Width + 2); i++) {
                Console.SetCursorPosition(i, 1);              
                Console.Write(".");
            }
            for (int i = 1; i <= (Width + 2); i++) {
                Console.SetCursorPosition(i, (Height + 2));
                Console.Write(".");
            }
            for (int i = 1; i <= (Height + 1); i++) {
                Console.SetCursorPosition(1, i);
                Console.Write(".");
            }
            for (int i = 1; i <= (Height + 1); i++) {
                Console.SetCursorPosition((Width + 2), i);
                Console.Write(".");

            }

            CleanColor();
        }

        public void Input() {
            if (Console.KeyAvailable) {
                KeyInfo = Console.ReadKey(true);
                Key = KeyInfo.KeyChar;
            }
        }

        public void WritePoint(int x, int y) {
           
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("#");
            CleanColor();
        }
        public void Logic() {
            Console.SetCursorPosition(40, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write($"Score: {score}");
            CleanColor();

            if (X[0] == fruitX) {
                if (Y[0] == fruitY) {
                    score++;
                    parts++;
                    temp--;
                    fruitX = rnd.Next(2, (Width-2));
                    fruitY = rnd.Next(2, (Height - 2));
                }
            }
            for(int i = parts; i >1; i--) {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }
            switch (Key) {
                case 'w':
                    Y[0]--;
                    break;
                case 's':
                    Y[0]++;
                    break;
                case 'd':
                    X[0]++;
                    break;
                case 'a':
                    X[0]--;
                    break;
            }
                
            for(int i = 0; i <= (parts -3); i++) {
                WritePoint(X[i], Y[i]);
                WritePoint(fruitX, fruitY);
                
            }
            if (X[0] >= 32 || X[0] < 2) {
                GameOver();
            } else if (Y[0] >= 23 || Y[0] < 2) {
                GameOver();
            }
                Thread.Sleep(temp);
        }

        public void GameOver() {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.SetCursorPosition(5, 8);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                                    ");
            Console.SetCursorPosition(5, 9);
            Console.Write("Deseja Continuar? 1 - Sim 2 - Não:  ");
            Console.SetCursorPosition(5, 10);
            Console.WriteLine("                                    ");
            Console.SetCursorPosition(40, 9);
            int.TryParse(Console.ReadLine(), out int op);
            switch (op) {
                case 1:
                    X[0] = 10;
                    Y[0] = 15;
                    Continue = true;
                    Console.CursorVisible = false;
                    fruitX = rnd.Next(2, (Width - 2));
                    fruitY = rnd.Next(2, (Height - 2));
                    parts = 3;
                    score = 0;
                    temp = 70;               
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Clear();
                    break;
                case 2:
                    Continue = false;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Clear();
                    Console.SetCursorPosition(5, 8);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Mt obrigado por jogar meu game        ");
                    Console.SetCursorPosition(5, 9);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Meu repositorio no git:               ");
                    Console.SetCursorPosition(5, 10);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(@"https://github.com/Unordestino       ");
                    Console.ReadKey();
                    CleanColor();
                    break;
                default:
                    Console.WriteLine("Opção invalida!");
                    break;
            }
           Console.Clear();
        }
    }
}
