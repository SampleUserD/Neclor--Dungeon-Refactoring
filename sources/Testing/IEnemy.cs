using Dungeon.Geometry.Primitives;

namespace Dungeon.Testing; 
public abstract class IEnemy
{
    abstract public void Move();
    abstract protected Vector GetPlayerPosition();
}
