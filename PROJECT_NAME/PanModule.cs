using Protogame;
using Protoinject;

namespace PROJECT_SAFE_NAME
{
    /// <summary>
    /// The dependency injection configuration for the game.  This contains additional bindings
    /// specific to your game that you want to set up.
    /// </summary>
    public class PanModule : IProtoinjectModule
    {
        public void Load(IKernel kernel)
        {
            // Binds the event binder; this instructs Protogame to bind events according
            // to PanInputBinder.  You can bind multiple IEventBinder's and events will
            // propagate through all of them.
            kernel.Bind<IEventBinder<IGameContext>>().To<PanInputBinder>();

            // We must bind our entities to names so that when the level loader
            // reads the Ogmo level, it can map the names of tilesets and entities
            // to the C# classes.  You must do .AllowManyPerScope() otherwise the kernel
            // will return the same object when multiple instances should be loaded.
            kernel.Bind<ISolidEntity>().To<SolidEntity>().AllowManyPerScope();
            kernel.Bind<ITileEntity>().To<GroundTileEntity>().Named("Ground").AllowManyPerScope();
            kernel.Bind<IEntity>().To<PlayerEntity>().Named("Player").AllowManyPerScope();
        }
    }
}

