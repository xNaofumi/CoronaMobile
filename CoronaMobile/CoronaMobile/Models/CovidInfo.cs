using System;
using System.Collections.Generic;
using AngleSharp;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaMobile.Models
{
    class CovidInfo
    {

        public class CovidStats
        {
            public string Tests { get; set; }
            public string Infections { get; set; }
            public string InfectionsLastDay { get; set; }
            public string Recovered { get; set; }
            public string Died { get; set; }
        }

        public async Task<CovidStats> GetStatsAsync()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://xn--80aesfpebagmfblc0a.xn--p1ai/";
            var document = await BrowsingContext.New(config).OpenAsync(address);
            var cellSelector = "div.cv-countdown__item-value";
            var cells = document.QuerySelectorAll(cellSelector);
            
            var data = cells.Select(m => m.TextContent);

            var stats = new CovidStats();
            var dataConverted = data.ToArray();
            try
            {
                stats.Tests = dataConverted[0];
                stats.Infections = dataConverted[1];
                stats.InfectionsLastDay = dataConverted[2];
                stats.Recovered = dataConverted[3];
                stats.Died = dataConverted[4];
            } 
            catch
            {
                return null;
            }

            return stats;
        }
    }
}
