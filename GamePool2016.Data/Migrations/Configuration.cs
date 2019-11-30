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
                CreateTeamsAndGame(context, "Makers Wanted Bahamas Bowl", "North Carolina AT&T", "Alcorn State", "ESPN", "12/20/2019 2:00:00 PM");
                CreateTeamsAndGame(context, "Frisco Bowl", "North Carolina AT&T", "Alcorn State", "ABC", "12/20/2019 7:30:00 PM");
                
                CreateTeamsAndGame(context, "Celebration Bowl", "North Carolina AT&T", "Alcorn State", "ABC", "12/21/2019 12:00:00 PM");
                CreateTeamsAndGame(context, "New Mexico Bowl", "North Texas", "Utah State", "ESPN", "12/21/2019 2:00:00 PM");
                CreateTeamsAndGame(context, "Cheribundi Boca Raton Bowl", "Tulane", "Louisiana", "ABC", "12/21/2019 3:30:00 PM");
                CreateTeamsAndGame(context, "Camellia Bowl", "Fresno State", "Arizona State", "ESPN", "12/21/2019 5:30:00 PM");
                CreateTeamsAndGame(context, "Mitsubishi Motors Las Vegas Bowl", "Georgia Southern", "Eastern Michigan", "ABC", "12/21/2019 7:30:00 PM");
                CreateTeamsAndGame(context, "R+L Carriers New Orleans Bowl", "Middle Tennessee", "Appalachian", "ESPN", "12/21/2019 9:00:00 PM");

                CreateTeamsAndGame(context, "Bad Boy Mowers Gasparilla Bowl", "UAB", "Northern Illinois", "ESPN", "12/23/2019 2:30:00 PM");

                CreateTeamsAndGame(context, "SoFi Hawai'i Bowl", "San Diego State", "Ohio", "ESPN", "12/24/2019 8:00:00 PM");

                CreateTeamsAndGame(context, "Walk-On's Independence Bowl", "Marshall", "South Florida", "ESPN", "12/26/2019 4:00:00 PM");
                CreateTeamsAndGame(context, "Quick Lane Bowl", "Marshall", "South Florida", "ESPN", "12/26/2019 8:00:00 PM");

                CreateTeamsAndGame(context, "Military Bowl Presented by Northrop Grumman", "FIU", "Toledo", "ESPN", "12/27/2019 12:00:00 PM");
                CreateTeamsAndGame(context, "New Era Pinstripe Bowl", "Western Michigan", "BYU", "ESPN", "12/27/2019 3:20:00 PM");
                CreateTeamsAndGame(context, "Academy Sports + Outdoors Texas Bowl", "Western Michigan", "BYU", "ESPN", "12/27/2019 6:45:00 PM");
                CreateTeamsAndGame(context, "San Diego County Credit Union Holiday Bowl", "Western Michigan", "BYU", "Fox Sports 1", "12/27/2019 8:00:00 PM");
                CreateTeamsAndGame(context, "Cheez-It Bowl", "Western Michigan", "BYU", "ESPN", "12/27/2019 10:15:00 PM");

                CreateTeamsAndGame(context, "Camping World Bowl", "Memphis", "Wake Forest", "ABC", "12/28/2019 12:00:00 PM");
                CreateTeamsAndGame(context, "Goodyear Cotton Bowl Classic", "Houston", "Army", "ESPN", "12/28/2019 12:00:00 PM");
                CreateTeamsAndGame(context, "PlayStation Fiesta Bowl", "Buffalo", "Troy", "ESPN", "12/28/2019 4:00:00 PM");
                CreateTeamsAndGame(context, "Chick-fil-A Peach Bowl", "Buffalo", "Troy", "ESPN", "12/28/2019 4:00:00 PM");

                CreateTeamsAndGame(context, "SERVPRO First Responder Bowl", "Louisiana Tech", "Hawai'i", "ESPN", "12/30/2019 12:30:00 PM");
                CreateTeamsAndGame(context, "Franklin American Mortgage Music City Bowl", "Louisiana Tech", "Hawai'i", "ESPN", "12/30/2019 4:00:00 PM");
                CreateTeamsAndGame(context, "Redbox Bowl", "Louisiana Tech", "Hawai'i", "FOX", "12/30/2019 4:00:00 PM");
                CreateTeamsAndGame(context, "Capital One Orange Bowl", "Louisiana Tech", "Hawai'i", "ESPN", "12/30/2019 8:00:00 PM");

                CreateTeamsAndGame(context, "Belk Bowl", "Boston College", "Boise State", "ESPN", "12/31/2019 12:00:00 PM");
                CreateTeamsAndGame(context, "Tony the Tiger Sun Bowl", "Boston College", "Boise State", "CBS", "12/31/2019 2:00:00 PM");
                CreateTeamsAndGame(context, "AutoZone Liberty Bowl", "Boston College", "Boise State", "ESPN", "12/31/2019 3:45:00 PM");
                CreateTeamsAndGame(context, "Valero Alamo Bowl", "Boston College", "Boise State", "ESPN", "12/31/2019 7:30:00 PM");

                CreateTeamsAndGame(context, "Vrbo Citrus Bowl", "Temple", "Duke", "ABC", "1/1/2020 1:00:00 PM");
                CreateTeamsAndGame(context, "Outback Bowl", "Temple", "Duke", "ESPN", "1/1/2020 1:00:00 PM");
                CreateTeamsAndGame(context, "Rose Bowl", "Temple", "Duke", "ESPN", "1/1/2020 5:00:00 PM");
                CreateTeamsAndGame(context, "Allstate Sugar Bowl", "Temple", "Duke", "ESPN", "1/1/2020 8:45:00 PM");

                CreateTeamsAndGame(context, "TicketSmarter Birmingham Bowl", "Purdue", "Auburn", "ESPN", "1/2/2020 3:00:00 PM");
                CreateTeamsAndGame(context, "TaxSlayer Gator Bowl", "Purdue", "Auburn", "ESPN", "1/2/2020 7:00:00 PM");

                CreateTeamsAndGame(context, "Famous Idaho Potato Bowl", "Purdue", "Auburn", "ESPN", "1/3/2020 3:30:00 PM");

                CreateTeamsAndGame(context, "Lockheed Martin Armed Forces Bowl", "Florida (10)", "Michigan (7)", "ESPN", "1/4/2020 11:30:00 AM");

                CreateTeamsAndGame(context, "Mobile Alabama Bowl", "South Carolina", "Virginia", "ESPN", "1/6/2020 7:30:00 PM");

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
