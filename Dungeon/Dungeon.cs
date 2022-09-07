namespace Dungeon
{
    public static class Dungeon
    {
        static Random r = new Random();

        public static int MyX = 21;
        public static int MyY = 9;
        public static int rune = 0;
        public static int room = 0;

        static int CreateRandomSeed()
        {
            int[] num = { -1, -1, -1, -1 };
            int c = 0;
            int randomseed = r.Next(2, 5);

            int i = randomseed;
            while (i > 0) {
                int n = r.Next(0, 4);
                if (Array.IndexOf(num, n) == -1) {
                    num[c++] = n;
                    i--;

                    randomseed = randomseed * 10 + n;
                }
            }

            randomseed = randomseed * 100 + r.Next(1, Convert.ToInt32(Convert.ToString(randomseed).Substring(0, 1)) + 1) * 10 + r.Next(1, Convert.ToInt32(Convert.ToString(randomseed).Substring(0, 1)) + 1);

            return randomseed;
        }

        static void LocationDrawing(int[,] rooms)
        {
            for (int y = 2; y <= 16; ++y) {
                Console.SetCursorPosition(4, y);
                Console.WriteLine("                                   ");
            }
            Console.SetCursorPosition(17, 1);
            if (rooms[room, 0] == -1) {
                Console.WriteLine("═════════");
            }
            else if (rooms[room, 0] >= 0) {
                Console.WriteLine("╣       ╠");
            }
            else {
                Console.WriteLine("╣▒▒▒@▒▒▒╠");
            }

            Console.SetCursorPosition(39, 7);
            if (rooms[room, 1] == -1) {
                Console.WriteLine("║");
                Console.SetCursorPosition(39, 8);
                Console.WriteLine("║");
                Console.SetCursorPosition(39, 9);
                Console.WriteLine("║");
                Console.SetCursorPosition(39, 10);
                Console.WriteLine("║");
                Console.SetCursorPosition(39, 11);
                Console.WriteLine("║");
            }
            else if (rooms[room, 1] >= 0) {
                Console.WriteLine("╩");
                Console.SetCursorPosition(39, 8);
                Console.WriteLine(" ");
                Console.SetCursorPosition(39, 9);
                Console.WriteLine(" ");
                Console.SetCursorPosition(39, 10);
                Console.WriteLine(" ");
                Console.SetCursorPosition(39, 11);
                Console.WriteLine("╦");
            }
            else {
                Console.WriteLine("╩");
                Console.SetCursorPosition(39, 8);
                Console.WriteLine("▒");
                Console.SetCursorPosition(39, 9);
                Console.WriteLine("@");
                Console.SetCursorPosition(39, 10);
                Console.WriteLine("▒");
                Console.SetCursorPosition(39, 11);
                Console.WriteLine("╦");
            }


            Console.SetCursorPosition(17, 17);
            if (rooms[room, 2] == -1) {
                Console.WriteLine("═════════");
            }
            else if (rooms[room, 2] >= 0) {
                Console.WriteLine("╣       ╠");
            }
            else {
                Console.WriteLine("╣▒▒▒@▒▒▒╠");
            }

            Console.SetCursorPosition(3, 7);
            if (rooms[room, 3] == -1) {
                Console.WriteLine("║");
                Console.SetCursorPosition(3, 8);
                Console.WriteLine("║");
                Console.SetCursorPosition(3, 9);
                Console.WriteLine("║");
                Console.SetCursorPosition(3, 10);
                Console.WriteLine("║");
                Console.SetCursorPosition(3, 11);
                Console.WriteLine("║");
            }
            else if (rooms[room, 3] >= 0) {
                Console.WriteLine("╩");
                Console.SetCursorPosition(3, 8);
                Console.WriteLine(" ");
                Console.SetCursorPosition(3, 9);
                Console.WriteLine(" ");
                Console.SetCursorPosition(3, 10);
                Console.WriteLine(" ");
                Console.SetCursorPosition(3, 11);
                Console.WriteLine("╦");
            }
            else {
                Console.WriteLine("╩");
                Console.SetCursorPosition(3, 8);
                Console.WriteLine("▒");
                Console.SetCursorPosition(3, 9);
                Console.WriteLine("@");
                Console.SetCursorPosition(3, 10);
                Console.WriteLine("▒");
                Console.SetCursorPosition(3, 11);
                Console.WriteLine("╦");
            }
        }

        static void Win()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 5);
            Console.WriteLine(@"
     ║                              ║
     ║  ╲            ╱  │  │╲    │  ║
     ║   ╲          ╱   │  │ ╲   │  ║
     ║    ╲        ╱    │  │  ╲  │  ║
     ║     ╲  ╱╲  ╱     │  │   ╲ │  ║
     ║      ╲╱  ╲╱      │  │    ╲│  ║ 
     ║                              ║");
            while (true) { }
        }

        public static void Lose()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 5);
            Console.WriteLine(@"
   ║                                  ║
   ║  │      ╭─────╮  ╭─────  ╭─────  ║
   ║  │      │     │  │       │       ║
   ║  │      │     │  ╰────╮  ├─────  ║
   ║  │      │     │       │  │       ║
   ║  ╰───── ╰─────╯  ─────╯  ╰─────  ║ 
   ║                                  ║");
            while (true) { }
        }



        public static void Main()
        {
            string seed = "";

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(@" 
 ║                                                                ║
 ║  ╓─────╮  ╷     ╷  │╲    │  ╭─────╮  ╭─────  ╭─────╮  │╲    │  ║
 ║  ║     │  │     │  │ ╲   │  │     │  │       │     │  │ ╲   │  ║
 ║  ║     │  │     │  │  ╲  │  │  ╭──╮  ├─────  │     │  │  ╲  │  ║
 ║  ║     │  │     │  │   ╲ │  │  ╵  │  │       │     │  │   ╲ │  ║
 ║  ╙─────╯  ╰─────╯  │    ╲│  ╰─────╯  ╰─────  ╰─────╯  │    ╲│  ║ 
 ║                                                                ║");

            Console.WriteLine();

            Console.CursorSize = 100;

            int up = Console.CursorTop;

            Console.WriteLine(" ║ RANDOM SEED ║");
            Console.WriteLine(" ║ ENTER SEED ║");

            int down = Console.CursorTop - 1;

            Console.CursorTop = up;

            ConsoleKey menu;
            while ((menu = Console.ReadKey(true).Key) != ConsoleKey.Enter) {
                if (menu == ConsoleKey.UpArrow) {
                    if (Console.CursorTop > up) {
                        Console.CursorTop--;
                    }
                    else {
                        Console.CursorTop = down;
                    }
                }
                else if (menu == ConsoleKey.DownArrow) {
                    if (Console.CursorTop < down) {
                        Console.CursorTop++;
                    }
                    else {
                        Console.CursorTop = up;
                    }
                }
            }

            if (Console.CursorTop == up) {
                seed = Convert.ToString(CreateRandomSeed());
                Console.Clear();
                Console.Write(" ║ SEED: ");
                Console.Write(seed);
                Console.WriteLine(" ║");
            }
            else if (Console.CursorTop == down) {
                Console.Clear();
                Console.Write(" ║ ENTER SEED: ");
                seed = Console.ReadLine();
                Console.SetCursorPosition(16 + seed.Length, 0);
                Console.WriteLine("║");
            }

            Console.WriteLine(" ║ OK ║");
            Console.CursorTop--;
            while ((menu = Console.ReadKey(true).Key) != ConsoleKey.Enter) { }
            Console.Clear();

            int[] enter_exit = { 2, 3, 0, 1 };
            int[] enemy_spawn = { 10, 32, 4, 14 };

            int[,] rooms = new int[Convert.ToInt32(seed.Substring(0, 1)) + 2, 4];

            Enemy[] enemies = new Enemy[Convert.ToInt32(seed.Substring(0, 1)) + 2];

            for (int i = 0; i < Convert.ToInt32(seed.Substring(0, 1)) + 2; i++) {
                for (int e = 0; e < 4; e++) {
                    rooms[i, e] = -1;
                }
            }

            for (int i = 1; i < Convert.ToInt32(seed.Substring(0, 1)) + 1; i++) {
                int n = Convert.ToInt32(seed.Substring(i, 1));
                rooms[0, n] = i;

                rooms[i, enter_exit[n]] = 0;

                enemies[i] = new Enemy(enemy_spawn[r.Next(0, 2)], enemy_spawn[r.Next(2, 4)]);

                if (i == Convert.ToInt32(seed.Substring(Convert.ToInt32(seed.Substring(0, 1)) + 1, 1))) {
                    rooms[i, n] = Convert.ToInt32(seed.Substring(0, 1)) + 1;

                    rooms[Convert.ToInt32(seed.Substring(0, 1)) + 1, enter_exit[n]] = i;

                    rooms[Convert.ToInt32(seed.Substring(0, 1)) + 1, n] = -2;

                    enemies[Convert.ToInt32(seed.Substring(0, 1)) + 1] = new Enemy(enemy_spawn[r.Next(0, 2)], enemy_spawn[r.Next(2, 4)]);
                }
            }

            Console.CursorVisible = false;
            Console.WriteLine(@"
   ╔═════════════         ═════════════╗
   ║                                   ║
   ║                                   ║
   ║                                   ║
   ║                                   ║
   ║                                   ║
                                       
                                                       
                                                          
                                                            
                                       
   ║                                   ║
   ║                                   ║
   ║                                   ║
   ║                                   ║               
   ║                                   ║
   ╚═════════════         ═════════════╝");
            LocationDrawing(rooms);

            Console.SetCursorPosition(MyX, MyY);
            Console.WriteLine("!");

            while (true) {
                ConsoleKey key = default;
                if (Console.KeyAvailable) {
                    key = Console.ReadKey(true).Key;
                    while (Console.KeyAvailable) {
                        Console.ReadKey();
                    }
                }

                Console.SetCursorPosition(MyX, MyY);
                Console.WriteLine(" ");
                Console.SetCursorPosition(0, 25);

                if (key == ConsoleKey.UpArrow) {
                    if (MyY > 2) {
                        MyY--;
                    }
                    else if (MyX >= 18 && MyX <= 24) {
                        if (rooms[room, 0] >= 0) {
                            room = rooms[room, 0];
                            MyY = 16;
                            LocationDrawing(rooms);
                        }
                        else if (rooms[room, 0] == -2 && rune == 1) {
                            Win();
                        }
                    }
                }
                else if (key == ConsoleKey.RightArrow) {
                    if (MyX < 38) {
                        MyX++;
                    }
                    else if (MyY >= 8 && MyY <= 10) {
                        if (rooms[room, 1] >= 0) {
                            room = rooms[room, 1];
                            MyX = 4;
                            LocationDrawing(rooms);
                        }
                        else if (rooms[room, 1] == -2 && rune == 1) {
                            Win();
                        }
                    }
                }
                else if (key == ConsoleKey.DownArrow) {
                    if (MyY < 16) {
                        MyY++;
                    }
                    else if (MyX >= 18 && MyX <= 24) {
                        if (rooms[room, 2] >= 0) {
                            room = rooms[room, 2];
                            MyY = 2;
                            LocationDrawing(rooms);
                        }
                        else if (rooms[room, 2] == -2 && rune == 1) {
                            Win();
                        }
                    }
                }
                else if (key == ConsoleKey.LeftArrow) {
                    if (MyX > 4) {
                        MyX--;
                    }
                    else if (MyY >= 8 && MyY <= 10) {
                        if (rooms[room, 3] >= 0) {
                            room = rooms[room, 3];
                            MyX = 38;
                            LocationDrawing(rooms);
                        }
                        else if (rooms[room, 3] == -2 && rune == 1) {
                            Win();
                        }
                    }
                }

                Console.SetCursorPosition(MyX, MyY);
                Console.WriteLine("!");
                Console.SetCursorPosition(0, 25);

                if (rune == 0 && room == Convert.ToInt32(seed.Substring(Convert.ToInt32(seed.Substring(0, 1)) + 2, 1))) {
                    if (MyX == 21 && MyY == 9) {
                        rune = 1;

                        Console.SetCursorPosition(0, 18);
                        Console.WriteLine(@"
   ╔═══╗             
   ║ @ ║
   ╚═══╝");
                    }
                    else {
                        Console.SetCursorPosition(21, 9);
                        Console.WriteLine("@");
                        Console.SetCursorPosition(0, 25);
                    }
                }

                if (room != 0) {
                    enemies[room].Moving();
                }

                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
