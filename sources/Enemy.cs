using Dungeon.Geometry.Primitives;
using Dungeon.Geometry.Enumerations;
using Dungeon.Testing;

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

	/// <summary>
	/// Renders a symbol on the screen (Console)
	/// </summary>
	/// <param name="position">Position of the given symbol on the screen</param>
	/// <param name="symbol">Symbol that is placed on the screen</param>
	private void RenderSymbolAt(Vector position, string symbol)
    {
        Console.SetCursorPosition(Convert.ToInt32(position.X), Convert.ToInt32(position.Y));
        Console.WriteLine(symbol);
        Console.SetCursorPosition(0, 25);
    }

    /// <summary>
    /// Clears a symbol at given position
    /// </summary>
    /// <param name="position">Position of the symbol on screen</param>
    private void ClearAt(Vector position)
    {
        RenderSymbolAt(position, " ");
    }

    /// <summary>
    /// Renders the enemy on the screen at its position
    /// </summary>
    private void Render()
    {
        RenderSymbolAt(_position, "&");
    }

    protected sealed override Vector GetPlayerPosition()
    {
        return new Vector(Dungeon.MyX, Dungeon.MyY);
    }

	/// <summary>
	/// This method defines moving strategy of the enemy
	/// and renders itself on the screen (Console). 
	/// </summary>
	/// <remarks>
	/// It checks every cycle that "the player is nearby to the enemy"
	/// and if it is true then it makes the player lose.
	/// </remarks>
	public override void Move()
    {
        int x = Convert.ToInt32(_position.X);
        int y = Convert.ToInt32(_position.Y);

        var position = GetPlayerPosition();

        int playerX = Convert.ToInt32(position.X);
        int playerY = Convert.ToInt32(position.Y);

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
