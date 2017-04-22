using Microsoft.Xna.Framework;
using Protogame;
using Protoinject;

// This instructs Protogame that the PanGameConfiguration class should
// be used for configuration.
[assembly: Configuration(typeof(PROJECT_SAFE_NAME.PanGameConfiguration))]

namespace PROJECT_SAFE_NAME
{
    /// <summary>
    /// The main game configuration, which configures the dependency injection kernel
    /// (and loads the modules for it) and constructs the game instance.
    /// </summary>
    public class PanGameConfiguration : IGameConfiguration
    {
        public void ConfigureKernel(IKernel kernel)
        {
            // The core module is a module needed by every game.
            kernel.Load<ProtogameCoreModule>();

            // The asset module allows you to use the Protogame asset system
            // including IAssetManager.  Most other modules depend on this, but if for
            // example, you just wanted a mostly XNA-like game with Protogame's entity
            // and world system, you could omit this, and load content using XNA/MonoGame's
            // LoadContent method.
            kernel.Load<ProtogameAssetModule>();

            // The events module listens for input from hardware (such as keyboard, mouse
            // and gamepads) and propagates them through the event system.  Without this
            // module, you won't be able to respond to input as events.  Instead you'd need
            // to use the XNA/MonoGame APIs for keyboard, mouse and gamepads directly.
            kernel.Load<ProtogameEventsModule>();

            // The level module provides APIs for reading and loading level assets.  You must load
            // this module if want to use the ILevelManager to load levels.
            kernel.Load<ProtogameLevelModule>();

            // The camera module provides APIs for setting up common types of cameras.  In this case,
            // we're using it for IPanningCamera, which sets up a panning camera in a 2D world.
            kernel.Load<ProtogameCameraModule>();

            // The platforming module provides APIs for movement in 2D games.  Despite it's name, it
            // has methods which are useful in non-platformers as well, such as detecting collisions with
            // solid entities (which we use in this game).  For more complex 2D games it might not be
            // suitable or performant for non-platformers.
            kernel.Load<ProtogamePlatformingModule>();

            // The profiler module shows a sidebar with profiling information as the game runs.
            kernel.Load<ProtogameProfilingModule>();

            // This is the module specific to this game.
            kernel.Load<PanModule>();
        }
        
        public Game ConstructGame(IKernel kernel)
        {
            return new PanGame(kernel);
        }
    }
}