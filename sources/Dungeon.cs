using Dungeon.Geometry.Primitives;

namespace Dungeon
{
    public enum PositionType
    {
		Left = 3,
		Right = 1,
		Top = 0,
		Bottom = 2
    }

    public record Position(Vector Coordinate, PositionType Type);
    /**
     * @description
     * This class presents a player itself
     */
    public static class Dungeon
    {
        static Random r = new Random();

      	public static int MyX = 21;
        public static int MyY = 9;
        private static int rune = 0;
        private static int room = 0;

		/// <summary>
		///     This method draws horizontal door.
		/// </summary>
		/// <remarks>
		///     <para>If door is type of -1 then it is a wall.<br/></para>
		///     <para>If door is type of 0 then it is a simple door.<br/></para>
		///     <para>If door is type of +1 then is is door with key.<br/></para>
		/// </remarks>
		/// <param name="rooms">Array of elements of room</param>
		private static void DrawHorizontalDoor(Position position, int[,] rooms)
        {
			var coordinates = position.Coordinate;
			var type = (int)position.Type;

			int x = Convert.ToInt32(coordinates.X);
            int y = Convert.ToInt32(coordinates.Y);

			Console.SetCursorPosition(x, y);

			if (rooms[room, type] == -1)
			{
				Console.WriteLine("║");
				Console.SetCursorPosition(x, y + 1);
				Console.WriteLine("║");
				Console.SetCursorPosition(x, y + 2);
				Console.WriteLine("║");
				Console.SetCursorPosition(x, y + 3);
				Console.WriteLine("║");
				Console.SetCursorPosition(x, y + 4);
				Console.WriteLine("║");
			}
			else if (rooms[room, type] >= 0)
			{
				Console.WriteLine("╩");
				Console.SetCursorPosition(x, y + 1);
				Console.WriteLine(" ");
				Console.SetCursorPosition(x, y + 2);
				Console.WriteLine(" ");
				Console.SetCursorPosition(x, y + 3);
				Console.WriteLine(" ");
				Console.SetCursorPosition(x, y + 4);
				Console.WriteLine("╦");
			}
			else
			{
				Console.WriteLine("╩");
				Console.SetCursorPosition(x, y + 1);
				Console.WriteLine("▒");
				Console.SetCursorPosition(x, y + 2);
				Console.WriteLine("@");
				Console.SetCursorPosition(x, y + 3);
				Console.WriteLine("▒");
				Console.SetCursorPosition(x, y + 4);
				Console.WriteLine("╦");
			}
		}

		/// <summary>
		///     This method vertical draws door.
		/// </summary>
		/// <remarks>
		///     <para>If door is type of -1 then it is a wall.<br/></para>
		///     <para>If door is type of 0 then it is a simple door.<br/></para>
		///     <para>If door is type of +1 then is is door with key.<br/></para>
		/// </remarks>
		/// <param name="rooms">Array of elements of room</param>
	    private static void DrawVerticalDoor(Position position, int[,] rooms)
        {
            var coordinates = position.Coordinate;
            var type = (int)position.Type;

			Console.SetCursorPosition(Convert.ToInt32(coordinates.X), Convert.ToInt32(coordinates.Y));

			if (rooms[room, type] == -1)
			{
				Console.WriteLine("═════════");
			}
			else if (rooms[room, type] >= 0)
			{
				Console.WriteLine("╣       ╠");
			}
			else
			{
				Console.WriteLine("╣▒▒▒@▒▒▒╠");
			}
		}

		private static void DrawLeftDoor(int[,] rooms)
		{
			var position = new Position(new Vector(3, 7), PositionType.Left);

			DrawHorizontalDoor(position, rooms);
		}

		private static void DrawRightDoor(int[,] rooms)
		{
            var position = new Position(new Vector(39, 7), PositionType.Right);

			DrawHorizontalDoor(position, rooms);
		}

        private static void DrawTopDoor(int[,] rooms)
        {
			var position = new Position(new Vector(17, 1), PositionType.Top);

			DrawVerticalDoor(position, rooms);
		}

        private static void DrawBottomDoor(int[,] rooms)
        {
			var position = new Position(new Vector(17, 17), PositionType.Bottom);

			DrawVerticalDoor(position, rooms);
		}

        /// <summary>
        ///   Creates random seed of the current location
        /// </summary>
        /// <remarks>
        ///   Describe algorithm here
        /// </remarks>
		private static int CreateRandomSeed()
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

        /// <summary>
        /// This method draws location out of rooms
        /// </summary>
        /// <param name="rooms"></param>
        private static void DrawLocation(int[,] rooms)
        {
            for (int y = 2; y <= 16; ++y) {
                Console.SetCursorPosition(4, y);
                Console.WriteLine("                                   ");
            }

            DrawLeftDoor(rooms);
            DrawTopDoor(rooms);
			DrawRightDoor(rooms);
            DrawBottomDoor(rooms);
        }

        private static void Win()
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
			DrawLocation(rooms);

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
							DrawLocation(rooms);
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
							DrawLocation(rooms);
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
							DrawLocation(rooms);
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
							DrawLocation(rooms);
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
                    enemies[room].Move();
                }

                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
