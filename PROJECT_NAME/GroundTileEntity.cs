using Microsoft.Xna.Framework;
using Protogame;

namespace PROJECT_SAFE_NAME
{
    public class GroundTileEntity : Entity, ITileEntity
    {
        private readonly ITileUtilities _tileUtilities;

        public GroundTileEntity(ITileUtilities tileUtilities, float x, float y, int tx, int ty)
        {
            _tileUtilities = tileUtilities;
            Transform.LocalPosition = new Vector3(x, y, 0);
            TX = tx;
            TY = ty;

            System.Console.WriteLine(Transform.LocalPosition);

            _tileUtilities.InitializeTile(this, "tileset.Ground");
        }

        public int TX { get; set; }
        public int TY { get; set; }
        public bool AppliedTilesetSettings { get; set; }
        public IAssetReference<TilesetAsset> Tileset { get; set; }

        public override void Render(IGameContext gameContext, IRenderContext renderContext)
        {
            base.Render(gameContext, renderContext);

            _tileUtilities.RenderTile(this, renderContext);
        }
    }
}
