using SappPasRoot.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace SappPasRoot.Graph
{
    public partial class TempoChangePathsJeux : Form
    {
        /// <summary>
        ///  Dossier de l'application - Utile au debugmode qui peut forcer du coup
        /// </summary>
        private string AppPath;

        /// <summary>
        /// Liste originale desjeux
        /// </summary>
        private IGame[] _ListGames;

        private bool DebugMode;

        public TempoChangePathsJeux()
        {
            InitializeComponent();
        }

        internal void Initialization()
        {
            PluginHelper.LaunchBoxMainForm.FormClosing += LaunchBoxMainForm_FormClosing;

            AppPath = AppDomain.CurrentDomain.BaseDirectory;



            _ListGames = PluginHelper.DataManager.GetAllGames()
                                .OrderBy(x => x.Title).ToArray();

            GrabMyShovel();
        }

        public void DebugTest()
        {
            DebugMode = true;
            AppPath = @"I:\Frontend\LaunchBox\";

            IGame[] KingOfSpain = new IGame[5];

            MvGame AlexKdd = new MvGame();
            AlexKdd.Title = "Alex Kidd in the Enchanted Castle";
            AlexKdd.ApplicationPath = @" ..\..\Games\Roms\Sega Mega Drive\Ok\Alex Kidd in the Enchanted Castle(E)(REV02)[!].bin.zip";

            MvGame sonic = new MvGame();
            sonic.Title = "Sonic The Hedgehog";
            sonic.ApplicationPath = @"..\..\Games\Roms\Sega Mega Drive\Hits\Sonic the Hedgehog Rev 0 (1991-06-23)(Sega)(EU-US).zip";

            MvGame Ninjas_Kick_Back = new MvGame();
            Ninjas_Kick_Back.Title = "3 Ninjas Kick Back";
            Ninjas_Kick_Back.ApplicationPath = @"..\..\Games\Roms\Sega Mega Drive\Ok\3 Ninjas Kick Back (1994)(Sony Imagesoft)(US).zip";

            MvGame AAAHH_Real_Monsters = new MvGame();
            AAAHH_Real_Monsters.Title = "AAAHH!!! Real Monsters";
            AAAHH_Real_Monsters.ApplicationPath = @"..\..\Games\Roms\Sega Mega Drive\Ok\Aaahh!!! Real Monsters (1995-11)(Viacom New Media)(EU).zip";

            MvGame Aladdin = new MvGame();
            Aladdin.Title = "Aladdin";
            Aladdin.ApplicationPath = @"..\..\Games\Roms\Sega Mega Drive\Hits\Disney's Aladdin (1993-11-11)(Sega)(EU).zip";

            MvGame Alex_Kidd_in_the_Enchanted_Castle = new MvGame();
            Alex_Kidd_in_the_Enchanted_Castle.Title = "Alex Kidd in the Enchanted Castle";
            Alex_Kidd_in_the_Enchanted_Castle.ApplicationPath = @"..\..\Games\Roms\Sega Mega Drive\Ok\Alex Kidd in the Enchanted Castle (E) (REV02) [!].bin.zip";

            MvGame Altered_Beast = new MvGame();
            Altered_Beast.Title = "Altered Beast";
            Altered_Beast.ApplicationPath = @"..\..\Games\Roms\Sega Mega Drive\Ok\Altered Beast Rev 2 (1989-08-14)(Sega)(EU-US).zip";

            MvGame Sonic_the_Hedgehog = new MvGame();
            Sonic_the_Hedgehog.Title = "Sonic the Hedgehog";
            Sonic_the_Hedgehog.ApplicationPath = @"..\..\Games\Roms\Sega Mega Drive\Hits\Sonic the Hedgehog Rev 0 (1991-06-23)(Sega)(EU-US).zip";

            MvGame Super_Mario_Bros_2 = new MvGame();
            Super_Mario_Bros_2.Title = "Super Mario Bros 2";
            Super_Mario_Bros_2.ApplicationPath = @"..\..\Roms\Nintendo Nes\Hits\Super Mario Bros. 2 (E) [!].zip";

            MvGame Toejam_ = new MvGame();
            Toejam_.Title = "Toejam & Earl";
            Toejam_.ApplicationPath = @"..\..\Games\Roms\Sega Mega Drive\Trainer\Toejam & Earl (UE) (REV00) [T+Fre0.90_sky2048].zip";

            MvGame ToeJam_1 = new MvGame();
            ToeJam_1.Title = "ToeJam & Earl";
            ToeJam_1.ApplicationPath = @"..\..\Games\Roms\Sega Mega Drive\Hits\ToeJam & Earl (1991-10)(Sega)(US).zip";

            MvGame ToeJam_2 = new MvGame();
            ToeJam_2.Title = "ToeJam & Earl";
            ToeJam_2.ApplicationPath = @"..\..\Games\Roms\Sega Mega Drive\Hits\ToeJam & Earl (1991-10)(Sega)(US).zip";

            MvGame ToeJam__Rev_2 = new MvGame();
            ToeJam__Rev_2.Title = "ToeJam & Earl Rev 2";
            ToeJam__Rev_2.ApplicationPath = @"..\..\Games\Roms\Sega Mega Drive\Hits\ToeJam & Earl Rev 2 (1991)(Sega)(JP)(en).zip";

            MvGame Wonder_Boy = new MvGame();
            Wonder_Boy.Title = "Wonder Boy";
            Wonder_Boy.ApplicationPath = @"..\..\Games\Roms\Sega Master System\Wonder Boy (UE) [!].zip";

            MvGame Wonder_Boy_2 = new MvGame();
            Wonder_Boy_2.Title = "Wonder Boy 2: Wonderboy in Monsterland";
            Wonder_Boy_2.ApplicationPath = @"..\..\Games\Roms\Sega Master System\Wonder Boy 2 - Wonderboy in Monsterland (UE) [!].zip";

            MvGame Wonder_Boy_5 = new MvGame();
            Wonder_Boy_5.Title = "Wonder Boy 5: Wonder Boy in Monster World";
            Wonder_Boy_5.ApplicationPath = @"..\..\Games\Roms\Sega Master System\Wonder Boy 5 - Wonder Boy in Monster World (UE) [!].zip";

            MvGame Wonder_Boy_III = new MvGame();
            Wonder_Boy_III.Title = "Wonder Boy III: The Dragon's Trap";
            Wonder_Boy_III.ApplicationPath = @"..\..\Games\Roms\Sega Master System\Wonder Boy III - The Dragon's Trap(USA, Europe).zip";

            MvGame World_of_Illusion_Starring_Mickey_Mouse = new MvGame();
            World_of_Illusion_Starring_Mickey_Mouse.Title = "World of Illusion Starring Mickey Mouse & Donald Duck";
            World_of_Illusion_Starring_Mickey_Mouse.ApplicationPath = @"..\..\Games\Roms\Sega Mega Drive\Ok\World of Illusion Starring Mickey Mouse & Donald Duck (1993-03)(Sega)(US).zip";

            MvGame World_of_Illusion_Starring_Mickey_Mouse_ = new MvGame();
            World_of_Illusion_Starring_Mickey_Mouse_.Title = "World of Illusion Starring Mickey Mouse & Donald Duck";
            World_of_Illusion_Starring_Mickey_Mouse_.ApplicationPath = @"..\..\Games\Roms\Sega Mega Drive\Trainers\World of Illusion Starring Mickey Mouse & Donald Duck (E) [T+Fre0.98beta_Generation IX].zip";

            MvGame World_of_Illusion_Starring_Mickey_Mouse_and_Donald_Duck = new MvGame();
            World_of_Illusion_Starring_Mickey_Mouse_and_Donald_Duck.Title = "World of Illusion Starring Mickey Mouse and Donald Duck";
            World_of_Illusion_Starring_Mickey_Mouse_and_Donald_Duck.ApplicationPath = @"..\..\Games\Roms\Sega Mega Drive\Ok\World of Illusion Starring Mickey Mouse & Donald Duck (1992-12-14)(Sega)(EU).zip";

            MvGame Zombies_Ate_My_Neighbors = new MvGame();
            Zombies_Ate_My_Neighbors.Title = "Zombies Ate My Neighbors";
            Zombies_Ate_My_Neighbors.ApplicationPath = @"..\..\Games\Roms\Sega Mega Drive\Hits\Zombies (1994-01-27)(Konami)(EU).zip";


            /*      
      Altered Beast : ..\..\Games\Roms\Sega Mega Drive\Ok\Altered Beast Rev 2(1989 - 08 - 14)(Sega)(EU - US).zip
      Sonic the Hedgehog: ..\..\Games\Roms\Sega Mega Drive\Hits\Sonic the Hedgehog Rev 0(1991 - 06 - 23)(Sega)(EU - US).zip
      Super Mario Bros 2 : ..\..\Roms\Nintendo Nes\Hits\Super Mario Bros. 2(E)[!].zip
      Toejam & Earl : ..\..\Games\Roms\Sega Mega Drive\Trainer\Toejam & Earl(UE)(REV00)[T + Fre0.90_sky2048].zip
      ToeJam & Earl : ..\..\Games\Roms\Sega Mega Drive\Hits\ToeJam & Earl(1991 - 10)(Sega)(US).zip
      ToeJam & Earl : ..\..\Games\Roms\Sega Mega Drive\Hits\ToeJam & Earl(1991 - 10)(Sega)(US).zip
      ToeJam & Earl Rev 2 : ..\..\Games\Roms\Sega Mega Drive\Hits\ToeJam & Earl Rev 2(1991)(Sega)(JP)(en).zip
      Wonder Boy : ..\..\Games\Roms\Sega Master System\Wonder Boy(UE) [!].zip
      Wonder Boy 2: Wonderboy in Monsterland : ..\..\Games\Roms\Sega Master System\Wonder Boy 2 - Wonderboy in Monsterland(UE) [!].zip
      Wonder Boy 5: Wonder Boy in Monster World : ..\..\Games\Roms\Sega Master System\Wonder Boy 5 - Wonder Boy in Monster World(UE) [!].zip
      Wonder Boy III: The Dragon's Trap : ..\..\Games\Roms\Sega Master System\Wonder Boy III - The Dragon's Trap(USA, Europe).zip
      World of Illusion Starring Mickey Mouse & Donald Duck : ..\..\Games\Roms\Sega Mega Drive\Ok\World of Illusion Starring Mickey Mouse & Donald Duck(1993-03)(Sega) (US).zip
      World of Illusion Starring Mickey Mouse & Donald Duck : ..\..\Games\Roms\Sega Mega Drive\Trainers\World of Illusion Starring Mickey Mouse & Donald Duck(E) [T+Fre0.98beta_Generation IX].zip
      World of Illusion Starring Mickey Mouse and Donald Duck : ..\..\Games\Roms\Sega Mega Drive\Ok\World of Illusion Starring Mickey Mouse & Donald Duck(1992-12-14)(Sega) (EU).zip
      Zombies Ate My Neighbors : ..\..\Games\Roms\Sega Mega Drive\Hits\Zombies(1994-01-27)(Konami) (EU).zip*/



        }

        private void GrabMyShovel()
        {
            foreach (var rameuh in _ListGames)
            {
                var titlemod = rameuh.Title.Replace(' ', '_');
                richTextBox1.Text += $"MvGame {titlemod} = new MvGame();" + Environment.NewLine;
                richTextBox1.Text += $"{titlemod}.Title= \"{rameuh.Title}\";" + Environment.NewLine;
                richTextBox1.Text += $"{ titlemod}.ApplicationPath= @\"{rameuh.ApplicationPath}\";" + Environment.NewLine + Environment.NewLine;

            }
        }

        private void LaunchBoxMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
    }
}
