using System.Linq;
using Microsoft.Xna.Framework;
using Protoinject;
using Protogame;

namespace PROJECT_SAFE_NAME
{
    public class PanWorld : IWorld
    {
        private readonly IHierarchy _hierarchy;
        private readonly IAssetManager _assetManager;
        private readonly IAssetReference<LevelAsset> _levelAsset;
        private readonly ILevelManager _levelManager;
        private readonly ICoroutine _coroutine;

        private bool _hasStartedLoad;

        public PanWorld(
            INode worldNode,
            IHierarchy hierarchy,
            IAssetManager assetManager,
            ILevelManager levelManager,
            ICoroutine coroutine)
        {
            _hierarchy = hierarchy;
            _levelManager = levelManager;
            _coroutine = coroutine;

            _levelAsset = assetManager.Get<LevelAsset>("level.Pan");
        }

        public void Dispose()
        {
            // Unused.
        }

        public void RenderAbove(IGameContext gameContext, IRenderContext renderContext)
        {
        }

        public void RenderBelow(IGameContext gameContext, IRenderContext renderContext)
        {
            if (renderContext.IsFirstRenderPass())
            {
                // Render a background which matches the colour of our tiles.
                renderContext.GraphicsDevice.Clear(new Color(92, 138, 185, 1));
            }
        }

        public void Update(IGameContext gameContext, IUpdateContext updateContext)
        {
            if (!_hasStartedLoad)
            {
                // Asynchronously load the level using a coroutine.  This prevents the game from
                // stalling or lagging when loading large levels.
                _coroutine.Run(async () => await _levelManager.LoadAsync(this, _levelAsset.Asset));
                _hasStartedLoad = true;
            }
        }
    }
}
