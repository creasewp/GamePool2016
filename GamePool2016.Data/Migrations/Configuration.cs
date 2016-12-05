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
                CreateTeamsAndGame(context, "AFR Celebration Bowl", "North Carolina Central", "Grambling", "ABC", "12/17/2016 9:00:00 AM");
                CreateTeamsAndGame(context, "Gildan New Mexico Bowl", "UTSA", "New Mexico", "ESPN", "12/17/2016 11:00:00 AM");
                CreateTeamsAndGame(context, "Las Vegas Bowl", "ABC", "Houston", "San Diego State", "12 /17/2016 12:30:00 PM");
                CreateTeamsAndGame(context, "AutoNation Cure Bowl", "Arkansas State", "UCF", "CBSSN", "12/17/2016 2:30:00 PM");
                CreateTeamsAndGame(context, "Raycom Media Camellia Bowl", "Toledo", "Appalachian State", "ESPN", "12/17/2016 2:30:00 PM");
                CreateTeamsAndGame(context, "R+L Carriers New Orleans Bowl", "Southern Miss", "UL Lafayette", "ESPN", "12/17/2016 6:00:00 PM");

                CreateTeamsAndGame(context, "Miami Beach Bowl", "Tulsa", "Central Michigan", "ESPN", "12/19/2016 11:30:00 AM");

                CreateTeamsAndGame(context, "Boca Raton Bowl", "Memphis", "Western Kentucky", "ESPN", "12/20/2016 4:00:00 PM");

                CreateTeamsAndGame(context, "San Diego County CU Poinsettia Bowl", "BYU", "Wyoming", "ESPN", "12/21/2016 6:00:00 PM");

                CreateTeamsAndGame(context, "Famous Idaho Potato Bowl", "Colorado State", "Idaho", "ESPN", "12/22/2016 4:00:00 PM");

                CreateTeamsAndGame(context, "Popeyes Bahamas Bowl", "Old Dominion", "Eastern Michigan", "ESPN", "12/23/2016 10:00:00 AM");
                CreateTeamsAndGame(context, "Lockheed Martin Armed Forces Bowl", "Louisiana Tech", "Navy", "ESPN", "12/23/2016 1:30:00 PM");
                CreateTeamsAndGame(context, "Dollar General Bowl", "Ohio", "Troy", "ESPN", "12/23/2016 5:00:00 PM");

                CreateTeamsAndGame(context, "Hawai'i Bowl", "Middle Tennessee", "Hawaii", "ESPN", "12/24/2016 5:00:00 PM");

                CreateTeamsAndGame(context, "St. Petersburg Bowl", "Miami (Ohio)", "Mississippi State", "ESPN", "12/26/2016 8:00:00 AM");
                CreateTeamsAndGame(context, "Quick Lane Bowl", "Boston College", "Maryland", "ESPN", "12/26/2016 11:30:00 AM");
                CreateTeamsAndGame(context, "Camping World Independence Bowl", "NC State", "Vanderbilt", "ESPN2", "12/26/2016 2:00:00 PM");

                CreateTeamsAndGame(context, "Zaxby's Heart of Dallas Bowl", "Army", "North Texas", "ESPN", "12/27/2016 9:00:00 AM");
                CreateTeamsAndGame(context, "Military Bowl", "Temple", "Wake Forest", "ESPN", "12/27/2016 12:30:00 PM");
                CreateTeamsAndGame(context, "National Funding Holiday Bowl", "Washington State", "Minnesota", "ESPN", "12/27/2016 4:00:00 PM");
                CreateTeamsAndGame(context, "Motel 6 Bowl", "Baylor ", "Boise State", "ESPN", "12/27/2016 7:15:00 PM");

                CreateTeamsAndGame(context, "New Era Pinstripe Bowl", "Northwestern", "Pittsburgh", "ESPN", "12/28/2016 11:00:00 AM");
                CreateTeamsAndGame(context, "Russell Athletic Bowl", "Miami (Fla.)", "West Virginia", "ESPN", "12/28/2016 2:30:00 PM");
                CreateTeamsAndGame(context, "Foster Farms Bowl", "Indiana", "Utah", "FOX", "12/28/2016 5:30:00 PM");
                CreateTeamsAndGame(context, "AdvoCare V100 Texas Bowl", "Kansas State", "Texas A&M", "ESPN", "12/28/2016 6:00:00 PM");

                CreateTeamsAndGame(context, "Birmingham Bowl", "USF", "South Carolina", "ESPN", "12/29/2016 11:00:00 AM");
                CreateTeamsAndGame(context, "Belk Bowl", "Virginia Tech", "Arkansas", "ESPN", "12/29/2016 2:30:00 PM");
                CreateTeamsAndGame(context, "Valero Alamo Bowl", "Oklahoma State", "Colorado", "ESPN", "12/29/2016 6:00:00 PM");

                CreateTeamsAndGame(context, "AutoZone Liberty Bowl", "TCU", "Georgia", "ESPN", "12/30/2016 9:00:00 AM");
                CreateTeamsAndGame(context, "Hyundai Sun Bowl", "North Carolina", "Stanford", "CBS", "12/30/2016 11:00:00 AM");
                CreateTeamsAndGame(context, "Franklin Amer. Mort. Music City Bowl", "Nebraska", "Tennessee", "ESPN", "12/30/2016 12:30:00 PM");
                CreateTeamsAndGame(context, "NOVA Home Loans Arizona Bowl", "Air Force", "South Alabama", "ASN/CI", "12/30/2016 2:30:00 PM");
                CreateTeamsAndGame(context, "Capital One Orange Bowl", "Florida State", "Michigan", "ESPN", "12/30/2016 5:00:00 PM");

                CreateTeamsAndGame(context, "Buffalo Wild Wings Citrus Bowl", "LSU", "Louisville", "ABC", "12/31/2016 8:00:00 AM");
                CreateTeamsAndGame(context, "TaxSlayer Bowl", "Georgia Tech", "Kentucky", "ESPN", "12/31/2016 8:00:00 AM");
                CreateTeamsAndGame(context, "Peach Bowl", "(1) Alabama", "(4) Washington", "ABC", "12/31/2016 12:00:00 PM");
                CreateTeamsAndGame(context, "Fiesta Bowl", "(2) Clemson", "(3) Ohio State", "ESPN", "12/31/2016 5:30:00 PM");

                CreateTeamsAndGame(context, "Outback Bowl", "Florida", "Iowa", "ABC", "1/2/2017 10:00:00 AM");
                CreateTeamsAndGame(context, "Goodyear Cotton Bowl", "Western Michigan", "Wisconsin", "ESPN", "1/2/2017 10:00:00 AM");
                CreateTeamsAndGame(context, "Rose Bowl", "Penn State", "USC", "ESPN", "1/2/2017 2:00:00 PM");
                CreateTeamsAndGame(context, "Allstate Sugar Bowl", "Oklahoma", "Auburn", "ESPN", "1/2/2017 5:30:00 PM");


                //CreateTeamsAndGame(context, "", "ESPN", "12/19/2016 11:30:00 AM");
                context.SaveChanges();
            }


        }

        private void CreateTeamsAndGame(GamePoolContext context, string bowlName, string teamA, string teamB, string network, string gameDateTime)
        {
            Team t1 = new Data.Team()
            {
                Id = Guid.NewGuid().ToString(),
                Description = (string.IsNullOrEmpty(teamA)) ? $"{bowlName} Home" : teamA
            };
            Team t2 = new Data.Team()
            {
                Id = Guid.NewGuid().ToString(),
                Description = (string.IsNullOrEmpty(teamB)) ? $"{bowlName} Home" : teamB
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
