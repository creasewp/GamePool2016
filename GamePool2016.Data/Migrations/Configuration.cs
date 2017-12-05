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
                CreateTeamsAndGame(context, "AFR Celebration Bowl", "North Carolina A&T", "Grambling", "ABC", "12/16/2017 9:00:00 AM");
                CreateTeamsAndGame(context, "R+L Carriers New Orleans Bowl", "Troy", "North Texas", "ESPN", "12/16/2017 10:00:00 AM");
                CreateTeamsAndGame(context, "AutoNation Cure Bowl", "Western Kentucky", "Georgia State", "CBSSN", "12/16/2017 11:30:00 AM");
                CreateTeamsAndGame(context, "Las Vegas Bowl", "Boise State (25)", "Oregon", "ABC", "12 /16/2017 12:30:00 PM");
                CreateTeamsAndGame(context, "Gildan New Mexico Bowl", "Marshall", "Colorado State", "ESPN", "12/16/2017 1:30:00 PM");
                CreateTeamsAndGame(context, "Raycom Media Camellia Bowl", "Middle Tennessee", "Arkansas State", "ESPN", "12/16/2017 5:00:00 PM");

                CreateTeamsAndGame(context, "Boca Raton Bowl", "Akron", "Florida Atlantic", "ESPN", "12/19/2017 4:00:00 PM");

                CreateTeamsAndGame(context, "DXL Frisco Bowl", "Louisiana Tech", "SMU", "ESPN", "12/20/2017 5:00:00 PM");

                CreateTeamsAndGame(context, "Gasparilla Bowl", "Temple", "Florida International", "ESPN", "12/21/2017 5:00:00 PM");

                CreateTeamsAndGame(context, "Bahamas Bowl", "UAB", "Ohio", "ESPN", "12/22/2017 9:30:00 AM");
                CreateTeamsAndGame(context, "Famous Idaho Potato Bowl", "Central Michigan", "Wyoming", "ESPN", "12/22/2017 1:00:00 PM");                

                CreateTeamsAndGame(context, "Birmingham Bowl", "Texas Tech", "South Florida", "ESPN", "12/23/2017 9:00:00 AM");
                CreateTeamsAndGame(context, "Armed Forces Bowl", "San Diego State", "Army", "ESPN", "12/23/2017 12:30:00 PM");
                CreateTeamsAndGame(context, "Dollar General Bowl", "Appalachian State", "Toledo", "ESPN", "12/23/2017 4:00:00 PM");

                CreateTeamsAndGame(context, "Hawai'i Bowl", "Fresno State", "Houston", "ESPN", "12/24/2017 5:30:00 PM");

                CreateTeamsAndGame(context, "Zaxby's Heart of Dallas Bowl", "Utah", "West Virginia", "ESPN", "12/26/2017 10:30:00 AM");
                CreateTeamsAndGame(context, "Quick Lane Bowl", "Duke", "Northern Illinois", "ESPN", "12/26/2017 2:15:00 PM");
                CreateTeamsAndGame(context, "Cactus Bowl", "Kansas State", "UCLA", "ESPN", "12/26/2017 6:00:00 PM");

                CreateTeamsAndGame(context, "Independence Bowl", "Southern Miss", "Florida State", "ESPN", "12/27/2017 10:30:00 AM");
                CreateTeamsAndGame(context, "New Era Pinstripe Bowl", "Iowa", "Boston College", "ESPN", "12/27/2017 2:15:00 PM");
                CreateTeamsAndGame(context, "Foster Farms Bowl", "Arizona", "Purdue", "FOX", "12/27/2017 5:30:00 PM");
                CreateTeamsAndGame(context, "Academy Sports + Outdoors Texas Bowl", "Texas", "Missouri", "ESPN", "12/27/2017 6:00:00 PM");

                CreateTeamsAndGame(context, "Miltary Bowl", "Virginia", "Navy", "ESPN", "12/28/2017 10:30:00 AM");
                CreateTeamsAndGame(context, "Camping World Bowl", "Virginia Tech (22)", "Oklahoma State (19)", "ESPN", "12/28/2017 2:15:00 PM");
                CreateTeamsAndGame(context, "Valero Alamo Bowl", "Stanford (13)", "TCU (15)", "ESPN", "12/28/2017 6:00:00 PM");
                CreateTeamsAndGame(context, "San Diego County CU Holiday Bowl", "Washington State (18)", "Michigan State (16)", "FOX", "12/28/2017 6:00:00 PM");

                CreateTeamsAndGame(context, "Belk Bowl", "Wake Forest", "Texas A&M", "ESPN", "12/29/2017 10:00:00 AM");
                CreateTeamsAndGame(context, "Hyundai Sun Bowl", "NC State (24)", "Arizona State", "CBS", "12/29/2017 12:00:00 PM");
                CreateTeamsAndGame(context, "Franklin Amer. Mort. Music City Bowl", "Kentucky", "Northwestern (21)", "ESPN", "12/29/2017 1:30:00 PM");
                CreateTeamsAndGame(context, "NOVA Home Loans Arizona Bowl", "Utah State", "New Mexico State", "CBSSN", "12/29/2017 2:30:00 PM");
                CreateTeamsAndGame(context, "Goodyear Cotton Bowl Classic", "USC (8)", "Ohio State (5)", "ESPN", "12/29/2017 5:30:00 PM");

                CreateTeamsAndGame(context, "TaxSlayer Bowl", "Lousville", "Mississippi State (23)", "ESPN", "12/30/2017 9:00:00 AM");
                CreateTeamsAndGame(context, "AutoZone Liberty Bowl", "Iowa State", "Memphis (20)", "ABC", "12/30/2017 9:30:00 AM");
                CreateTeamsAndGame(context, "PlayStation Fiesta Bowl", "Washington (11)", "Penn State (9)", "ESPN", "12/30/2017 1:00:00 PM");
                CreateTeamsAndGame(context, "Capital One Orange Bowl", "Miami (10)", "Wisonsin (6)", "ESPN", "12/30/2017 5:00:00 PM");

                CreateTeamsAndGame(context, "Outback Bowl", "Michigan", "South Carolina", "ESPN2", "1/1/2018 9:00:00 AM");
                CreateTeamsAndGame(context, "Chick-fil-A Peach Bowl", "UCF (12)", "Auburn (7)", "ESPN", "1/1/2018 9:30:00 AM");
                CreateTeamsAndGame(context, "Citrus Bowl", "Notre Dame (14)", "LSU (17)", "ABC", "1/1/2018 10:00:00 AM");

                CreateTeamsAndGame(context, "Rose Bowl", "Georgia (3)", "Oklahoma (2)", "ESPN", "1/1/2017 2:00:00 PM");
                CreateTeamsAndGame(context, "Allstate Sugar Bowl", "Alabama (4)", "Clemson (1)", "ESPN", "1/1/2017 5:45:00 PM");


                //CreateTeamsAndGame(context, "", "ESPN", "12/19/2017 11:30:00 AM");
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
