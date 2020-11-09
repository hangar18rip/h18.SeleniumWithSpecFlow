using h18.SeleniumWithSpecFlow.Core;
using Microsoft.Edge.SeleniumTools;
using TechTalk.SpecFlow;

namespace h18.SeleniumWithSpecFlow.Edge
{
    public class EdgeHook : HookBase<EdgeDriver, EdgeOptions, EdgeHookConfiguration>
    {
        public EdgeHook(ScenarioContext context) : base(context)
        {
        }

        protected override EdgeDriver GetDriver(EdgeOptions options)
        {
            options.UseChromium = true;
            return new EdgeDriver(options);
        }
    }
}
