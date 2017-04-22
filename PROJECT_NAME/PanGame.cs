using Microsoft.Xna.Framework;
using Protoinject;
using Protogame;

namespace PROJECT_SAFE_NAME
{
    public class PanGame : CoreGame<PanWorld>
    {
        public PanGame(IKernel kernel) : base(kernel)
        {
        }

        protected override void ConfigureRenderPipeline(IRenderPipeline pipeline, IKernel kernel)
        {
            var graphicsFactory = kernel.Get<IGraphicsFactory>();

            // This render pass is for 2D sprite batched rendering.  In this pass, calls
            // to I2DRenderUtilities will work.
            pipeline.AddFixedRenderPass(graphicsFactory.Create2DBatchedRenderPass());

#if DEBUG
            // Show the profiler sidebar with most of the default visualisers.  You can write your
            // own visualisers to show values and graphs in real-time.
            var profilerRenderPass = kernel.Get<IProfilerRenderPass>();
            profilerRenderPass.Position = ProfilerPosition.TopRight;
            profilerRenderPass.Visualisers.Add(kernel.Get<IKernelMetricsProfilerVisualiser>());
            profilerRenderPass.Visualisers.Add(kernel.Get<IGraphicsMetricsProfilerVisualiser>());
            profilerRenderPass.Visualisers.Add(kernel.Get<IGCMetricsProfilerVisualiser>());
            profilerRenderPass.Visualisers.Add(kernel.Get<IOperationCostProfilerVisualiser>());
            pipeline.AddFixedRenderPass(profilerRenderPass);
#endif
        }

        protected override void PrepareGraphicsDeviceManager(GraphicsDeviceManager graphicsDeviceManager)
        {
            // Set the window / game area size to 800x600.
            graphicsDeviceManager.PreferredBackBufferWidth = 800;
            graphicsDeviceManager.PreferredBackBufferHeight = 600;
        }
    }
}
