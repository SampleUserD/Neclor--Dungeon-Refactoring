using Dungeon.Geometry.Primitives;
using Dungeon.Geometry.Enumerations;
using Dungeon.Experimental;

namespace Dungeon;

public class Enemy : IEnemy
{
    private const double OneHalfOfTheStep = 0.5;

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
            _position = _position + OneHalfOfTheStep * Directions.Right;
        }
        else if (px < x)
        {
            _position = _position + OneHalfOfTheStep * Directions.Left;
        }
        else if (py > y)
        {
            _position = _position + OneHalfOfTheStep * Directions.Down;
        }
        else if (py < y)
        {
            _position = _position + OneHalfOfTheStep * Directions.Up;
        }
    }

    private void RenderSymbolAt(Vector position, string symbol)
    {
        Console.SetCursorPosition(Convert.ToInt32(position.X), Convert.ToInt32(position.Y));
        Console.WriteLine(symbol);
        Console.SetCursorPosition(0, 25);
    }

    private void ClearAt(Vector position)
    {
        RenderSymbolAt(position, " ");
    }

    private void Render()
    {
        RenderSymbolAt(_position, "&");
    }

    /**
     * @description
     * 1) This method defines a moving strategy
     * 2) Renders a enemy on the screen
     * 
     * @returns {void}
     */
    public void Move()
    {
        int x = Convert.ToInt32(_position.X);
        int y = Convert.ToInt32(_position.Y);

        int playerX = Dungeon.MyX;
        int playerY = Dungeon.MyY;

        if (IsPlayerStaysAtNearbyPosition(playerX, playerY) == true)
        {
            Dungeon.Lose();
            return;
        }

        ClearAt(_position);
        ChaseThePlayer(playerX, playerY);
        Render();
    }
}
