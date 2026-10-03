using Bridge.Renderers;

namespace Bridge.Reports
{
    /// <summary>
    /// The abstraction: decides WHAT a report contains.
    /// HOW it is formatted is delegated to the renderer it holds (the "bridge").
    /// </summary>
    internal abstract class Report
    {
        protected readonly IReportRenderer Renderer;

        protected Report(IReportRenderer renderer)
        {
            Renderer = renderer;
        }

        public abstract string Generate();
    }
}
