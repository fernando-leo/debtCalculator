using StructureMap;

namespace DebtCalc.IoC
{
	public class BoundContextToResolve
	{
        ConfigurationExpression _config;

        public BoundContextToResolve(ConfigurationExpression config)
        {
            _config = config;
        }

        protected void Register<TFor, TUse>()
            where TUse : TFor
        {
            _config.For<TFor>().Use<TUse>();
        }
    }
}
