using SotnWiki.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SotnWiki.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SotnWikiDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SotnWiki.Data.SotnWikiDbContext context)
        {
            IList<Character> characters = new List<Character>()
            {
                new Character () { Name = "Site", Id = (int)CharacterIdEnum.Site },
                new Character () { Name = "Alucard", Id = (int)CharacterIdEnum.Alucard },
                new Character () { Name = "Richter", Id = (int)CharacterIdEnum.Richter },
                new Character () { Name = "Maria", Id = (int)CharacterIdEnum.Maria }
            };
            context.Characters.AddOrUpdate(characters.ToArray());

            var siteEntity = context.Characters.Find((int)CharacterIdEnum.Site);
            var alucardEntity = context.Characters.Find((int)CharacterIdEnum.Alucard);
            var richerEntity = context.Characters.Find((int)CharacterIdEnum.Richter);
            var mariaEntity = context.Characters.Find((int)CharacterIdEnum.Maria);

            string defaultPageContent =
@"h1. This page is empty

There is currently no content in this page. Use the edit page button to edit and submit new content. Please adhere to the site templates.


This wiki uses TxStyle markup, for reference visit  ""https://txstyle.org/"":https://txstyle.org/.";

            //Seed default pages
            IList<Page> pages = new List<Page>()
            {
                new Page () { Id = Guid.NewGuid(), IsPublished = true, Title = "Main Page", CreatedOn = DateTime.Now, GeneralCharacter = siteEntity , Content = defaultPageContent},
                new Page () { Id = Guid.NewGuid(), IsPublished = true, Title = "Alucard", CreatedOn = DateTime.Now, GeneralCharacter = alucardEntity , Content = defaultPageContent},
                new Page () { Id = Guid.NewGuid(), IsPublished = true, Title = "Richter", CreatedOn = DateTime.Now, GeneralCharacter = richerEntity , Content = defaultPageContent},
                new Page () { Id = Guid.NewGuid(), IsPublished = true, Title = "Maria", CreatedOn = DateTime.Now, GeneralCharacter = mariaEntity , Content = defaultPageContent}
            };
            context.Pages.AddOrUpdate(pages.ToArray());

            //Seed cvs runs
            IList<Run> runs = new List<Run>()
            {
                new Run () { Runner = "Dr4gonBlitz", Time = "16:54", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.twitch.tv/videos/39231129"},
                new Run () { Runner = "romscout", Time = "16:59", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.youtube.com/watch?v=n1v3AtAAM9s"},
                new Run () { Runner = "BenAuton", Time = "17:10", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.youtube.com/watch?v=6nmnbQhO_vQ"},
                new Run () { Runner = "Metako", Time = "17:26", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.youtube.com/watch?v=D3WFqkgjzWM"},
                new Run () { Runner = "Pksl", Time = "17:37", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.youtube.com/watch?v=8nfGzisMBU8"},
                new Run () { Runner = "3snow_p7im", Time = "17:42", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.youtube.com/watch?v=5BeqDO5T-TY"},
                new Run () { Runner = "TheBlacktastic", Time = "17:43", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.youtube.com/watch?v=aZqzy-EoRDI"},
                new Run () { Runner = "Turbodog702", Time = "17:53", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.youtube.com/watch?v=IVDb1FLCwAE"},
                new Run () { Runner = "EpiclyEpic", Time = "18:00", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.twitch.tv/videos/47791525"},
                new Run () { Runner = "dram55", Time = "18:13", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.twitch.tv/videos/13170431"},
                new Run () { Runner = "Ctrlaltwtf", Time = "18:19", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.youtube.com/watch?v=SbmrWiUP1EA"},
                new Run () { Runner = "ArrenJevleth", Time = "18:23", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.twitch.tv/videos/40962784"},
                new Run () { Runner = "KayinNasaki", Time = "18:33", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.twitch.tv/videos/46641479"},
                new Run () { Runner = "TalicZealot", Time = "18:50", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu, Url = "https://www.youtube.com/watch?v=qNUKP2lU0x0"},
                new Run () { Runner = "MechaRichter", Time = "18:54", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.twitch.tv/videos/45793059"},
                new Run () { Runner = "ozzy88", Time = "19:07", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.twitch.tv/videos/49329362"},
                new Run () { Runner = "Vulvanomics", Time = "19:15", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.twitch.tv/videos/46632492"},
                new Run () { Runner = "Mystakin", Time = "19:17", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.twitch.tv/videos/46889355"},
                new Run () { Runner = "Desquall", Time = "19:17", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu, Url = "https://www.twitch.tv/videos/43152296"},
                new Run () { Runner = "Boz", Time = "19:21", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.twitch.tv/videos/44857538"},
                new Run () { Runner = "Midboss", Time = "19:22", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.twitch.tv/videos/45953235"},
                new Run () { Runner = "ForgoneMoose", Time = "19:25", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu, Url = "https://www.youtube.com/watch?v=fGqkL8UvQl4"},
                new Run () { Runner = "Dacidbro", Time = "19:40", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360, Url = "https://www.twitch.tv/videos/49590872"},
                new Run () { Runner = "Jindeathwalk", Time = "19:43", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Gikkman", Time = "19:51", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "Cosmo", Time = "19:52", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Zemptai", Time = "20:08", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Sauze", Time = "20:35", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "SakuraFreak", Time = "20:41", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "Kanzeon", Time = "20:53", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "zx497", Time = "20:54", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Playstation3},
                new Run () { Runner = "dxtr", Time = "20:54", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Kainblox", Time = "21:08", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "XeiZ", Time = "21:34", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "FlamingHarlekin", Time = "21:49", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "c0mfy", Time = "21:55", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "gtTuna", Time = "22:03", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "AlucardX60", Time = "22:23", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "BugleHawkeM", Time = "22:25", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Zex", Time = "22:58", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Playstation},
                new Run () { Runner = "hagrimm", Time = "23:42", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "xenyztw", Time = "23:52", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "Lazarus_DS", Time = "24:39", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "Furkay", Time = "24:40", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "dr_raichi", Time = "24:51", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "SketchFile", Time = "25:03", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "Benko", Time = "25:43", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "Unholydonuts86", Time = "25:51", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "GarlVinland", Time = "25:56", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "KHeartz", Time = "26:55", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Arctice", Time = "26:57", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "Wilbo", Time = "27:49", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Lenophis", Time = "28:02", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Playstation},
                new Run () { Runner = "VegetaReese", Time = "28:14", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "CountNeko", Time = "28:35", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "kenshiroux", Time = "29:49", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "OreoTheWolf", Time = "30:57", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Satoryu", Time = "31:58", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Playstation},
                new Run () { Runner = "LlorenR", Time = "33:57", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "thedarkraziel", Time = "35:14", Category = Category.CvsAlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "LucidFaia", Time = "43:51", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Playstation},
                new Run () { Runner = "SYLARisGod", Time = "44:42", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "krispearman", Time = "48:21", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Adam Grise", Time = "55:51", Category = Category.CvsAlucardAnyNSC, Platform = Platform.Playstation}
            };
            context.Runs.AddOrUpdate(runs.ToArray());
        }
    }
}
