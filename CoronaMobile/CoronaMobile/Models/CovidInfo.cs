using AngleSharp;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaMobile.Models
{
    public class CovidInfo
    {
        public class Stats
        {
            public string Tests { get; set; }
            public string Infections { get; set; }
            public string InfectionsLastDay { get; set; }
            public string Recovered { get; set; }
            public string Died { get; set; }
        }

        public async Task<Stats> GetStatsAsync()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://xn--80aesfpebagmfblc0a.xn--p1ai/";
            var document = await BrowsingContext.New(config).OpenAsync(address);
            var cellSelector = "div.cv-countdown__item-value";
            var cells = document.QuerySelectorAll(cellSelector);

            var data = cells.Select(m => m.TextContent);

            var stats = new Stats();
            var dataConverted = data.ToArray();
            TrySetCovidStats(stats, dataConverted);

            return stats;
        }

        private static void TrySetCovidStats(Stats stats, string[] dataConverted)
        {
            try
            {
                stats.Tests = dataConverted[0];
                stats.Infections = dataConverted[1];
                stats.InfectionsLastDay = dataConverted[2];
                stats.Recovered = dataConverted[3];
                stats.Died = dataConverted[4];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw ex;
            }
        }
    }
}
