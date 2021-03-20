using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Players.Any())
                {
                    var playersData = File.ReadAllText("../Infrastructure/data/SeedData/playerData.json");
                    var players = JsonSerializer.Deserialize<List<Player>>(playersData);
                    foreach (var item in players)
                    {
                        context.Players.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Awards.Any())
                {
                    var awardData = File.ReadAllText("../Infrastructure/data/SeedData/awardsData.json");
                    var awards = JsonSerializer.Deserialize<List<Award>>(awardData);
                    foreach (var item in awards)
                    {
                        context.Awards.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.TAward.Any())
                {
                    var TawardData = File.ReadAllText("../Infrastructure/data/SeedData/teamAwards.json");
                    var tAwards = JsonSerializer.Deserialize<List<TournamentAward>>(TawardData);
                    foreach (var item in tAwards)
                    {
                        context.TAward.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Stories.Any())
                {

                    var StoryData = File.ReadAllText("../Infrastructure/data/SeedData/story.json");
                    var stories = JsonSerializer.Deserialize<List<General>>(StoryData);
                    foreach (var item in stories)
                    {
                        context.Stories.Add(item);
                    }
                    await context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}