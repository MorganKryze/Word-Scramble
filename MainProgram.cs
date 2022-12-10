using System.Diagnostics;
using Newtonsoft.Json;
using static System.Console;
using static Word_Scramble.Methods;
using static Word_Scramble.Game;

namespace Word_Scramble
{
    class MainProgram
    {

        public static void Main(string[] args)
        {
            #region Config
            ConsoleConfig();
            #endregion

            Main_Menu :

            #region Lobby
            MainMenu();
            #endregion

            #region Setting up the players
            Ranking ranking = new Ranking();
            Player player1 = new Player();
            Player player2 = new Player();
            if(!DefinePlayers(player1, player2, ranking))goto Main_Menu;
            #endregion

            #region Game loop
            LoadingScreen("[  Loading the game ...  ]");
            if (!SelectWords(CsvToMatrix("dataGrills/ComplexGrill.csv"), new List<string>{"TERRE","FERME","ROCHE","ECHEC"}, player1)) goto Main_Menu;
            if (!SelectWords(CsvToMatrix("dataGrills/ComplexGrill.csv"), new List<string>{"TERRE","ROUE","ROCHE","ECHEC"}, player2)) goto Main_Menu;
            Pause();
            #endregion

            goto Main_Menu;
        }
    }
}