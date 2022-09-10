namespace Dungeon
{
    /**
     * @description
     * This class defines an easy interface to the vector in 2d space
     * 
     * @param {double} x - coordinate by X
     * @param {double} y - coordinate by Y
     */
    public record Vector(double X, double Y);

    public class Enemy
    {
        private readonly const double OneHalfOfTheStep = 0.5;

        private Vector _position = default(Vector);

        /**
         * @description
         * This class defines an interface of the enemy
         * 
         * @param {int} x - position of the enemy by x
         * @param {int} y - position of the enemy by y
         */
        public Enemy(int x, int y)
        {
            _position = new Vector(x, y);
        }

        /**
         * @description
         * There is no Point in parameters, because it is expensive to recreate object every cycle
         * That is why there is inconsistence in code
         * 
         * @param {int} px - Player position by X
         * @param {int} py - Player position by Y
         * 
         * @returns {bool}
         */
        private bool IsPlayerStaysAtNearbyPosition(int px, int py)
        {
            int x = Convert.ToInt32(_position.X);
            int y = Convert.ToInt32(_position.Y);

            return Math.Abs(px - x) == 0 &&
                   Math.Abs(py - y) == 1 ||
                   Math.Abs(px - x) == 1 &&
                   Math.Abs(py - y) == 0;
        }

        /**
         * @description
         * There is no Point in parameters, because it is expensive to recreate object every cycle
         * That is why there is inconsistence in code
         * Enemy chases player every second frame
         * 
         * @param {int} px - Player position by X
         * @param {int} py - Player position by Y
         * 
         * @returns {void}
         */
        private void ChaseThePlayer(int px, int py)
        {
            int x = Convert.ToInt32(_position.X);
            int y = Convert.ToInt32(_position.Y);

            if (px > x)
            {
                _position.X += OneHalfOfTheStep;
            }
            else if (px < x)
            {
                _position.X -= OneHalfOfTheStep;
            }
            else if (py > y)
            {
                _position.Y += OneHalfOfTheStep;
            }
            else if (py < y)
            {
                _position.Y -= OneHalfOfTheStep;
            }
        }

        /**
         * @description
         * 1) This method defines a moving strategy
         * 2) Renders a enemy on the screen
         * 
         * @returns {void}
         */
        public void Moving()
        {
            int x = Convert.ToInt32(_position.X);
            int y = Convery.ToInt32(_position.Y);

            int playerX = Dungeon.MyX;
            int playerY = Dungeon.MyY;

            if (IsPlayerStaysAtNearbyPosition(playerX, playerY) == true)
            {
                Dungeon.Lose();
                return void;
            }

            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
            Console.SetCursorPosition(0, 25);

            ChaseThePlayer(playerX, playerY);

            Console.SetCursorPosition(x, y);
            Console.WriteLine("&");
            Console.SetCursorPosition(0, 25);
        }
    }
}