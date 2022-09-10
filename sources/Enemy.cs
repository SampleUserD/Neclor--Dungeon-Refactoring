namespace Dungeon
{
    public class Enemy
    {
        private Double x, y;

        public Enemy(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Moving()
        {
            if (Math.Abs(Dungeon.MyX - Convert.ToInt32(x)) == 0 && Math.Abs(Dungeon.MyY - Convert.ToInt32(y)) == 1 || Math.Abs(Dungeon.MyX - Convert.ToInt32(x)) == 1 && Math.Abs(Dungeon.MyY - Convert.ToInt32(y)) == 0) 
            {
                Dungeon.Lose();
            }

            Console.SetCursorPosition(Convert.ToInt32(x), Convert.ToInt32(y));
            Console.WriteLine(" ");
            Console.SetCursorPosition(0, 25);

            if (Dungeon.MyX > Convert.ToInt32(x)) 
            {
                x += 0.5;
            }
            else if (Dungeon.MyX < Convert.ToInt32(x)) 
            {
                x -= 0.5;
            }
            else if (Dungeon.MyY > Convert.ToInt32(y)) 
            {
                y += 0.5;
            }
            else if (Dungeon.MyY < Convert.ToInt32(y)) 
            {
                y -= 0.5;
            }

            Console.SetCursorPosition(Convert.ToInt32(x), Convert.ToInt32(y));
            Console.WriteLine("&");
            Console.SetCursorPosition(0, 25);
        }
    }
}
