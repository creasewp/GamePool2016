namespace GamePool2016.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GamePool2016.Data.GamePoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GamePool2016.Data.GamePoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (!context.Teams.Any())
            {
                CreateTeamsAndGame(context, "AFR Celebration Bowl", "ABC", "12/17/2016 9:00:00 AM");
                CreateTeamsAndGame(context, "Gildan New Mexico Bowl", "ESPN", "12/17/2016 11:00:00 AM");
                CreateTeamsAndGame(context, "Las Vegas Bowl", "ABC", "12/17/2016 12:30:00 PM");
                CreateTeamsAndGame(context, "AutoNation Cure Bowl", "CBSSN", "12/17/2016 2:30:00 PM");
                CreateTeamsAndGame(context, "Raycom Media Camellia Bowl", "ESPN", "12/17/2016 2:30:00 PM");
                CreateTeamsAndGame(context, "R+L Carriers New Orleans Bowl", "ESPN", "12/17/2016 6:00:00 PM");

                CreateTeamsAndGame(context, "Miami Beach Bowl", "ESPN", "12/19/2016 11:30:00 AM");

                CreateTeamsAndGame(context, "Boca Raton Bowl", "ESPN", "12/20/2016 4:00:00 PM");

                CreateTeamsAndGame(context, "San Diego County CU Poinsettia Bowl", "ESPN", "12/21/2016 6:00:00 PM");

                CreateTeamsAndGame(context, "Famous Idaho Potato Bowl", "ESPN", "12/22/2016 4:00:00 PM");

                CreateTeamsAndGame(context, "Popeyes Bahamas Bowl", "ESPN", "12/23/2016 10:00:00 AM");
                CreateTeamsAndGame(context, "Lockheed Martin Armed Forces Bowl", "ESPN", "12/23/2016 1:30:00 PM");
                CreateTeamsAndGame(context, "Dollar General Bowl", "ESPN", "12/23/2016 5:00:00 PM");

                CreateTeamsAndGame(context, "Hawai'i Bowl", "ESPN", "12/24/2016 5:00:00 PM");

                CreateTeamsAndGame(context, "St. Petersburg Bowl", "ESPN", "12/26/2016 8:00:00 AM");
                CreateTeamsAndGame(context, "Quick Lane Bowl", "ESPN", "12/26/2016 11:30:00 AM");
                CreateTeamsAndGame(context, "Camping World Independence Bowl", "ESPN2", "12/26/2016 2:00:00 PM");

                CreateTeamsAndGame(context, "Zaxby's Heart of Dallas Bowl", "ESPN", "12/27/2016 9:00:00 AM");
                CreateTeamsAndGame(context, "Military Bowl", "ESPN", "12/27/2016 12:30:00 PM");
                CreateTeamsAndGame(context, "National Funding Holiday Bowl", "ESPN", "12/27/2016 4:00:00 PM");
                CreateTeamsAndGame(context, "Motel 6 Bowl", "ESPN", "12/27/2016 7:15:00 PM");

                CreateTeamsAndGame(context, "New Era Pinstripe Bowl", "ESPN", "12/28/2016 11:00:00 AM");
                CreateTeamsAndGame(context, "Russell Athletic Bowl", "ESPN", "12/28/2016 2:30:00 PM");
                CreateTeamsAndGame(context, "Foster Farms Bowl", "FOX", "12/28/2016 5:30:00 PM");
                CreateTeamsAndGame(context, "AdvoCare V100 Texas Bowl", "ESPN", "12/28/2016 6:00:00 PM");

                CreateTeamsAndGame(context, "Birmingham Bowl", "ESPN", "12/29/2016 11:00:00 AM");
                CreateTeamsAndGame(context, "Belk Bowl", "ESPN", "12/29/2016 2:30:00 PM");
                CreateTeamsAndGame(context, "Valero Alamo Bowl", "ESPN", "12/29/2016 6:00:00 PM");

                CreateTeamsAndGame(context, "AutoZone Liberty Bowl", "ESPN", "12/30/2016 9:00:00 AM");
                CreateTeamsAndGame(context, "Hyundai Sun Bowl", "CBS", "12/30/2016 11:00:00 AM");
                CreateTeamsAndGame(context, "Franklin Amer. Mort. Music City Bowl", "ESPN", "12/30/2016 12:30:00 PM");
                CreateTeamsAndGame(context, "NOVA Home Loans Arizona Bowl", "ASN/CI", "12/30/2016 2:30:00 PM");
                CreateTeamsAndGame(context, "Capital One Orange Bowl", "ESPN", "12/30/2016 5:00:00 PM");

                CreateTeamsAndGame(context, "Buffalo Wild Wings Citrus Bowl", "ABC", "12/31/2016 8:00:00 AM");
                CreateTeamsAndGame(context, "TaxSlayer Bowl", "ESPN", "12/31/2016 8:00:00 AM");

                CreateTeamsAndGame(context, "Outback Bowl", "ABC", "1/2/2017 10:00:00 AM");
                CreateTeamsAndGame(context, "Goodyear Cotton Bowl", "ESPN", "1/2/2017 10:00:00 AM");
                CreateTeamsAndGame(context, "Rose Bowl", "ESPN", "1/2/2017 2:00:00 PM");
                CreateTeamsAndGame(context, "Allstate Sugar Bowl", "ESPN", "1/2/2017 5:30:00 PM");


                //CreateTeamsAndGame(context, "", "ESPN", "12/19/2016 11:30:00 AM");
                context.SaveChanges();
            }


        }

        private void CreateTeamsAndGame(GamePoolContext context, string bowlName, string network, string gameDateTime)
        {
            Team t1 = new Data.Team()
            {
                Id = Guid.NewGuid().ToString(),
                Description = $"{bowlName} Home"
            };
            Team t2 = new Data.Team()
            {
                Id = Guid.NewGuid().ToString(),
                Description = $"{bowlName} Away"
            };
            Game g1 = new Data.Game()
            {
                HomeTeamId = t1.Id,
                AwayTeamId = t2.Id,
                Description = bowlName,
                Network = network,
                GameDateTime = gameDateTime,
                Id = Guid.NewGuid().ToString(),
                AwayScore = 0,
                HomeScore = 0
            };

            context.Teams.Add(t1);
            context.Teams.Add(t2);
            context.Games.Add(g1);
        }
    }
}
