using CvSpeedruns.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace CvSpeedruns.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CvSpeedrunsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CvSpeedrunsDbContext context)
        {
            IList<Run> runs = new List<Run>()
            {
                new Run () { Runner = "Dr4gonBlitz", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "romscout", Time = "16:59", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "BenAuton", Time = "17:10", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Metako", Time = "17:26", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Pksl", Time = "17:37", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "3snow_p7im", Time = "17:42", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "TheBlacktastic", Time = "17:43", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Turbodog702", Time = "17:53", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "EpiclyEpic", Time = "18:00", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "dram55", Time = "18:13", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Ctrlaltwtf", Time = "18:19", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "ArrenJevleth", Time = "18:23", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "KayinNasaki", Time = "18:33", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "TalicZealot", Time = "18:50", Category = Category.AlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "MechaRichter", Time = "18:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "ozzy88", Time = "19:07", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Vulvanomics", Time = "19:15", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Mystakin", Time = "19:17", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Desquall", Time = "19:17", Category = Category.AlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "Boz", Time = "19:21", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Midboss", Time = "19:22", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "ForgoneMoose", Time = "19:25", Category = Category.AlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "Dacidbro", Time = "19:40", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Jindeathwalk", Time = "19:43", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Gikkman", Time = "19:51", Category = Category.AlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "Cosmo", Time = "19:52", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Zemptai", Time = "20:08", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                new Run () { Runner = "Sauze", Time = "20:35", Category = Category.AlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "SakuraFreak", Time = "20:41", Category = Category.AlucardAnyNSC, Platform = Platform.PlaystationEmu},
                new Run () { Runner = "Kanzeon", Time = "20:53", Category = Category.AlucardAnyNSC, Platform = Platform.PlaystationEmu}
                //new Run () { Runner = "zx497", Time = "20:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "dxtr", Time = "20:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "Kainblox", Time = "20:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "XeiZ", Time = "20:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "FlamingHarlekin", Time = "20:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "c0mfy", Time = "20:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "gtTuna", Time = "20:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "AlucardX60", Time = "20:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "BugleHawkeM", Time = "20:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "Zexxxxxxx", Time = "20:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "hagrimm", Time = "20:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "xenyztw", Time = "20:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "Lazarus_DS", Time = "20:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "Furkay", Time = "20:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "dr_raichi", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "SketchFile", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "Benko", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "Unholydonuts86", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "GarlVinland", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "KHeartz", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "Arctice", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "Wilbo", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "Lenophis", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "VegetaReese", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "CountNeko", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "kenshiroux", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "OreoTheWolf", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "Satoryu", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Playstation},
                //new Run () { Runner = "LlorenR", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "thedarkraziel", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "LucidFaia", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "SYLARisGod", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "krispearman", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Xbox360},
                //new Run () { Runner = "Adam Grise", Time = "16:54", Category = Category.AlucardAnyNSC, Platform = Platform.Playstation
            };

            context.Runs.AddOrUpdate(runs.ToArray());
        }
    }
}
