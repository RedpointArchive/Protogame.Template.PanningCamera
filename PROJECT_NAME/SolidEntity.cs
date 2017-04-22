using Microsoft.Xna.Framework;
using Protogame;

namespace PROJECT_SAFE_NAME
{
    public class SolidEntity : Entity, ISolidEntity
    {
        public SolidEntity(float x, float y, float width, float height)
        {
            Transform.LocalPosition = new Vector3(x, y, 0);
            Width = width;
            Height = height;
        }
    }
}
