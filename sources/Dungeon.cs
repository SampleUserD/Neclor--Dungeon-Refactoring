using Dungeon.Geometry.Primitives;
using Dungeon.Geometry.Enumerations;

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
   
    public static class Dungeon
    {
        private static readonly Random r = new Random();

        private static readonly Vector LeftBound = new Vector(3, 7);
        private static readonly Vector RightBound = new Vector(39, 7);
        private static readonly Vector TopBound = new Vector(17, 1);
        private static readonly Vector BottomBound = new Vector(17, 17);
        private static readonly Vector Center = new Vector(21, 9);

        public static int MyX = Convert.ToInt32(Center.X);
        public static int MyY = Convert.ToInt32(Center.Y);
        
        private static int rune = 0;
        private static int room = 0;

        /// <summary>
        /// This method draws the given symbol at given position
        /// </summary>
        /// <param name="coordinate">Coordinate of the given symbol</param>
        /// <param name="symbol">Rendering symbol</param>
        private static void RenderSymbolAt(Vector coordinate, char symbol)
        {
            var x = Convert.ToInt32(coordinate.X);
            var y = Convert.ToInt32(coordinate.Y);

            Console.SetCursorPosition(x, y);
            Console.WriteLine(symbol);
        }
        
        /// <summary>
        /// Clear symbol at given position
        /// </summary>
        /// <param name="position">Given position</param>
        private static void ClearAt(Vector position)
        {
            RenderSymbolAt(position, ' ');
        }

        private static void RenderSymbolsInHorizontalDirection(Vector coordinate, string symbols)
        {
            for (int index = 0, length = symbols.Length; index < length; index++)
            {
                var x = Convert.ToInt32(coordinate.X);
                var y = Convert.ToInt32(coordinate.Y) + index;

                RenderSymbolAt(new Vector(x, y), symbols[index]);
            }
        }

        private static void RenderSymbolsInVerticalDirection(Vector coordinate, string symbols)
        {
            var x = Convert.ToInt32(coordinate.X);
            var y = Convert.ToInt32(coordinate.Y);

            Console.SetCursorPosition(x, y);
            Console.WriteLine(symbols);
        }

        /// <summary>
        /// This method draws horizontal door.
        /// </summary>
        /// <remarks>
        ///     <para>If door is type of -1 then it is a wall.<br/></para>
        ///     <para>If door is type of 0 then it is a simple door.<br/></para>
        ///     <para>If door is type of +1 then is is door with key.<br/></para>
        /// </remarks>
        /// <param name="rooms">Array of elements of room</param>
        private static void DrawHorizontalUnit(Position position, int[,] rooms)
        {
            var coordinates = position.Coordinate;
            var type = (int)position.Type;

            var x = Convert.ToInt32(coordinates.X);
            var y = Convert.ToInt32(coordinates.Y);

            if (rooms[room, type] == -1)
            {
                RenderSymbolsInHorizontalDirection(new Vector(x, y), "║║║║║");
            }
            else if (rooms[room, type] == -2)
            {
                RenderSymbolsInHorizontalDirection(new Vector(x, y), "╩▒@▒╦");
            }
            else if (rooms[room, type] >= 0)
            {
                RenderSymbolsInHorizontalDirection(new Vector(x, y), "╩   ╦");
            }
            else
            {
                throw new Exception($"Unsupported unit type: {type}");
            }
        }

        /// <summary>
        /// This method vertical draws door.
        /// </summary>
        /// <remarks>
        ///     <para>If door is type of -1 then it is a wall.<br/></para>
        ///     <para>If door is type of 0 then it is a simple door.<br/></para>
        ///     <para>If door is type of +1 then is is door with key.<br/></para>
        /// </remarks>
        /// <param name="rooms">Array of elements of room</param>
        private static void DrawVerticalUnit(Position position, int[,] rooms)
        {
            var coordinates = position.Coordinate;
            var type = (int)position.Type;

            var x = Convert.ToInt32(coordinates.X);
            var y = Convert.ToInt32(coordinates.Y);

            if (rooms[room, type] == -1)
            {
                RenderSymbolsInVerticalDirection(new Vector(x, y), "═════════");
            }
            else if (rooms[room, type] == -2)
            {
                RenderSymbolsInVerticalDirection(new Vector(x, y), "╣▒▒▒@▒▒▒╠");
            }
            else if (rooms[room, type] >= 0)
            {
                RenderSymbolsInVerticalDirection(new Vector(x, y), "╣       ╠");
            }
            else
            {
                throw new Exception($"Unsupported unit type: {type}");
            }
        }

        private static void DrawLeftUnit(int[,] rooms)
        {
            var position = new Position(LeftBound, PositionType.Left);

            DrawHorizontalUnit(position, rooms);
        }

        private static void DrawRightUnit(int[,] rooms)
        {
            var position = new Position(RightBound, PositionType.Right);

            DrawHorizontalUnit(position, rooms);
        }

        private static void DrawTopUnit(int[,] rooms)
        {
            var position = new Position(TopBound, PositionType.Top);

            DrawVerticalUnit(position, rooms);
        }

        private static void DrawBottomUnit(int[,] rooms)
        {
            var position = new Position(BottomBound, PositionType.Bottom);

            DrawVerticalUnit(position, rooms);
        }

        private static void DrawLocationLayout()
        {
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

        }

        /// <summary>
        /// This method draws location out of rooms
        /// </summary>
        /// <param name="rooms">Array of rooms</param>
        private static void DrawLocation(int[,] rooms)
        {
            for (int y = 2; y <= 16; ++y)
            {
                Console.SetCursorPosition(4, y);
                Console.WriteLine("                                   ");
            }

            DrawLeftUnit(rooms);
            DrawTopUnit(rooms);
            DrawRightUnit(rooms);
            DrawBottomUnit(rooms);
        }

        /// <summary>
        /// Get door's type at given position
        /// </summary>
        /// <param name="rooms">Array of rooms</param>
        /// <param name="type">Given position</param>
        private static int GetDoorTypeInCurrentRoomAt(int[,] rooms, PositionType type)
        {
            return rooms[room, (int)type];
        }

        /// <summary>
        /// Checks there is the simple door at given position or not 
        /// (simple means with no rune, but no wall)
        /// </summary>
        /// <param name="rooms">Array of rooms</param>
        /// <param name="type">Given position</param>
        private static bool IsDoorSimpleInCurrentRoomAt(int[,] rooms, PositionType type)
        {
            return GetDoorTypeInCurrentRoomAt(rooms, type) >= 0;
        }

        /// <summary>
        /// Checks there is the wall at given position or not
        /// </summary>
        /// <param name="rooms">Array of rooms</param>
        /// <param name="type">Given position</param>
        private static bool IsWallInCurrentRoomAt(int[,] rooms, PositionType type)
        {
            return GetDoorTypeInCurrentRoomAt(rooms, type) == -1;
        }

        /// <summary>
        /// Checks there is the door with rune at given position or not
        /// </summary>
        /// <param name="rooms">Array of rooms</param>
        /// <param name="type">Given position</param>
        private static bool IsDoorWithRuneInCurrentRoomAt(int[,] rooms, PositionType type)
        {
            return GetDoorTypeInCurrentRoomAt(rooms, type) == -2;
        }

        /// <summary>
        /// Checks that player wins or not
        /// </summary>
        /// <returns>"rune" field</returns>
        private static bool IsPlayerWin()
        {
            return (rune == 1);
        }

        /// <summary>
        /// Check if the player is out of left bound
        /// </summary>
        private static bool IsPlayerOutOfLeftBound()
        {
            return MyX + Directions.Left.X > LeftBound.X;
        }

        /// <summary>
        /// Check if the player is out of right bound
        /// </summary>
        private static bool IsPlayerOutOfRightBound()
        {
            return MyX + Directions.Right.X < RightBound.X;
        }

        /// <summary>
        /// Check if the player is out of top bound
        /// </summary>
        private static bool IsPlayerOutOfTopBound()
        {
            return MyY + Directions.Up.Y > TopBound.Y;
        }

        /// <summary>
        /// Check if the player is out of bottom bound
        /// </summary>
        private static bool IsPlayerOutOfBottomBound()
        {
            return MyY + Directions.Down.Y < BottomBound.Y;
        }

        /// <summary>
        /// Check if the player passes through one of the vertical doors
        /// </summary>
        private static bool IsPlayerPassThroughVerticalDoor()
        {
            return (MyX >= 18 && MyX <= 24);
        }

        /// <summary>
        /// Check if the player passes through one of the horizontal doors
        /// </summary>
        private static bool IsPlayerPassThroughHorizontalDoor()
        {
            return (MyY >= 8 && MyY <= 10);
        }

        /// <summary>
        /// Checks player can pass through the rune door (beat the game) or not
        /// </summary>
        /// <param name="rooms">Array of rooms</param>
        /// <param name="type">Given position</param>
        /// <returns></returns>
        private static bool CanPlayerPassThroughTheRuneDoorAt(int[,] rooms, PositionType type)
        {
            return 
                IsDoorWithRuneInCurrentRoomAt(rooms, type) == true &&
                IsPlayerWin() == true;
        }

        /// <summary>
        /// Describes strategy of movement of the player
        /// </summary>
        /// <param name="direction">Direction of movement</param>
        private static void Move(Vector direction)
        {
            MyX += Convert.ToInt32(direction.X);
            MyY += Convert.ToInt32(direction.Y);
        }

        /// <summary>
        /// Translate player to the point
        /// </summary>
        /// <param name="point">Translation point</param>
        private static void GoTo(Vector point)
        {
            MyX = Convert.ToInt32(point.X);
            MyY = Convert.ToInt32(point.Y);
        }

        /// <summary>
        /// Moves player to room at given position
        /// </summary>
        /// <param name="rooms">Array of rooms</param>
        /// <param name="type">Position of the door</param>
        private static void GoToRoomAt(int[,] rooms, PositionType type)
        {
            room = GetDoorTypeInCurrentRoomAt(rooms, type);
        }

        /// <summary>
        /// Creates random seed of the current location
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
        /// This method draws player at its current position
        /// </summary>
        private static void DrawPlayer()
        {
            RenderSymbolAt(new Vector(MyX, MyY), '!');
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
            
            DrawLocationLayout();
            DrawLocation(rooms);
            DrawPlayer();

            while (true) 
            {
                ConsoleKey key = default;

                if (Console.KeyAvailable) {
                    key = Console.ReadKey(true).Key;
                    while (Console.KeyAvailable) {
                        Console.ReadKey();
                    }
                }

                ClearAt(new Vector(MyX, MyY));

                if (key == ConsoleKey.UpArrow) 
                {
                    if (IsPlayerOutOfTopBound() == true) 
                    {
                        Move(Directions.Up);
                    }
                    else if (IsPlayerPassThroughVerticalDoor() == true) 
                    {
                        if (IsDoorSimpleInCurrentRoomAt(rooms, PositionType.Top) == true) 
                        {
                            GoToRoomAt(rooms, PositionType.Top);
                            GoTo(new Vector(MyX, BottomBound.Y - Directions.Down.Y));

                            DrawLocation(rooms);
                        }
                        else if (CanPlayerPassThroughTheRuneDoorAt(rooms, PositionType.Top) == true) 
                        {
                            Win();
                        }
                    }
                }
                else if (key == ConsoleKey.RightArrow) 
                {
                    if (IsPlayerOutOfRightBound() == true) 
                    {
                        Move(Directions.Right);
                    }
                    else if (IsPlayerPassThroughHorizontalDoor() == true) 
                    {
                        if (IsDoorSimpleInCurrentRoomAt(rooms, PositionType.Right) == true) 
                        {
                            GoToRoomAt(rooms, PositionType.Right);
                            GoTo(new Vector(LeftBound.X - Directions.Left.X, MyY));

                            DrawLocation(rooms);
                        }
                        else if (CanPlayerPassThroughTheRuneDoorAt(rooms, PositionType.Right) == true) 
                        {
                            Win();
                        }
                    }
                }
                else if (key == ConsoleKey.DownArrow) 
                {
                    if (IsPlayerOutOfBottomBound() == true) 
                    {
                        Move(Directions.Down);
                    } 
                    else if (IsPlayerPassThroughVerticalDoor() == true) 
                    {
                        if (IsDoorSimpleInCurrentRoomAt(rooms, PositionType.Bottom) == true) 
                        {
                            GoToRoomAt(rooms, PositionType.Bottom);
                            GoTo(new Vector(MyX, TopBound.Y - Directions.Up.Y));

                            DrawLocation(rooms);
                        }
                        else if (CanPlayerPassThroughTheRuneDoorAt(rooms, PositionType.Bottom) == true) 
                        {
                            Win();
                        }
                    }
                }
                else if (key == ConsoleKey.LeftArrow) 
                {
                    if (IsPlayerOutOfLeftBound() == true)
                    {
                        Move(Directions.Left);
                    }
                    else if (IsPlayerPassThroughHorizontalDoor() == true) 
                    {
                        if (IsDoorSimpleInCurrentRoomAt(rooms, PositionType.Left) == true) 
                        {
                            GoToRoomAt(rooms, PositionType.Left);
                            GoTo(new Vector(RightBound.X - Directions.Right.X, MyY));

                            DrawLocation(rooms);
                        }
                        else if (CanPlayerPassThroughTheRuneDoorAt(rooms, PositionType.Left) == true) 
                        {
                            Win();
                        }
                    }
                }

                DrawPlayer();

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
