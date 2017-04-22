using Microsoft.Xna.Framework;
using Protogame;

namespace PROJECT_SAFE_NAME
{
    public class PanningCameraComponent : IPrerenderableComponent
    {
        private IPanningCamera _panningCamera;

        public PanningCameraComponent(IPanningCamera panningCamera)
        {
            _panningCamera = panningCamera;
        }

        public void Prerender(ComponentizedEntity entity, IGameContext gameContext, IRenderContext renderContext)
        {
            _panningCamera.Apply(
                renderContext,
                new Vector2(
                    entity.FinalTransform.AbsolutePosition.X + 8 /* center of entity */,
                    entity.FinalTransform.AbsolutePosition.Y + 8 /* center of entity */));
        }
    }
}
