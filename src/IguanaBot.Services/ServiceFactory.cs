using IguanaBot.Services.Corona;
using IguanaBot.Services.League;
using IguanaBot.Services.Nasa;
using IguanaBot.Services.Pokedollar;
using IguanaBot.Services.Interfaces;

namespace IguanaBot.Services
{
    public static class ServiceFactory
    {
        private static readonly ICoronaServiceProvider _coronaServiceProvider;
        private static readonly ILeagueServiceProvider _leagueServiceProvider;
        private static readonly IPokedollarServiceProvider _pokedollarProvider;
        private static readonly INasaServiceProvider _nasaServiceProvider;

        public static ICoronaServiceProvider GetCoronaServiceProvider()
        {
            return _coronaServiceProvider ?? new CoronaServiceProvider();
        }

        public static ILeagueServiceProvider GetLeagueServiceProvider()
        {
            return _leagueServiceProvider ?? new LeagueServiceProvider();
        }

        public static IPokedollarServiceProvider GetPokedollarServiceProvider()
        {
            return _pokedollarProvider ?? new PokedollarServiceProvider();
        }

        public static INasaServiceProvider GetNasaServiceProvider()
        {
            return _nasaServiceProvider ?? new NasaServiceProvider();
        }
    }
}
