using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Protogame;
using Protoinject;
using System.Collections.Generic;
using System;
using System.Linq;

namespace PROJECT_SAFE_NAME
{
    public class PlayerEntity : ComponentizedEntity, IBoundingBox
    {
        private readonly INode _node;
        private readonly IHierarchy _hierarchy;
        private readonly I2DRenderUtilities _renderUtilities;
        private readonly IPlatforming _platforming;

        public PlayerEntity(
            INode node,
            IHierarchy hierarchy,
            IAssetManager assetManager,
            I2DRenderUtilities renderUtilities,
            IPlatforming platforming,
            PanningCameraComponent panningCameraComponent,
            string name,
            int id,
            int x,
            int y,
            Dictionary<string, string> attributes)
        {
            _node = node;
            _hierarchy = hierarchy;
            _renderUtilities = renderUtilities;
            _platforming = platforming;

            Transform.LocalPosition = new Vector3(x, y, 0);

            RegisterComponent(panningCameraComponent);

            Width = 16;
            Height = 16;
            Depth = 0;
            XSpeed = 0;
            YSpeed = 0;
            ZSpeed = 0;
        }

        public float Depth { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float XSpeed { get; set; }
        public float YSpeed { get; set; }
        public float ZSpeed { get; set; }

        public override bool Handle(IGameContext context, IEventEngine<IGameContext> eventEngine, Event @event)
        {
            var keyHeldEvent = @event as KeyHeldEvent;

            if (keyHeldEvent != null)
            {
                if (keyHeldEvent.Key == Keys.Up)
                {
                    _platforming.ApplyMovement(this, 0, -4, context.World.GetEntitiesForWorld(_hierarchy).OfType<IBoundingBox>(), x => x is SolidEntity);
                }
                if (keyHeldEvent.Key == Keys.Down)
                {
                    _platforming.ApplyMovement(this, 0, 4, context.World.GetEntitiesForWorld(_hierarchy).OfType<IBoundingBox>(), x => x is SolidEntity);
                }
                if (keyHeldEvent.Key == Keys.Left)
                {
                    _platforming.ApplyMovement(this, -4, 0, context.World.GetEntitiesForWorld(_hierarchy).OfType<IBoundingBox>(), x => x is SolidEntity);
                }
                if (keyHeldEvent.Key == Keys.Right)
                {
                    _platforming.ApplyMovement(this, 4, 0, context.World.GetEntitiesForWorld(_hierarchy).OfType<IBoundingBox>(), x => x is SolidEntity);
                }
            }

            return base.Handle(context, eventEngine, @event);
        }

        public override void Render(IGameContext gameContext, IRenderContext renderContext)
        {
            _renderUtilities.RenderRectangle(
                renderContext,
                new Rectangle(
                    (int)FinalTransform.AbsolutePosition.X,
                    (int)FinalTransform.AbsolutePosition.Y,
                    16,
                    16),
                Color.Red,
                true);

            base.Render(gameContext, renderContext);
        }
    }
}
