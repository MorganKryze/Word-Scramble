using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;
using static System.IO.File;

namespace Word_Scramble
{
    /// <summary>The ranking class.</summary>
    public class Ranking : IEquatable<Ranking>
    {
        #region Properties
        /// <summary>The players that finished the game.</summary>
        public List<Player> Finished { get; set; }
        /// <summary>The players that didn't finish the game.</summary>
        public List<Player> NotFinished { get; set; }
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="Ranking"/> class.</summary>
        /// <param name="finished">if set to <c>true</c> [finished].</param>
        public Ranking()
        {
            
            Finished = new List<Player>();
            string[] lines = ReadAllLines("dataPlayers/Finished.txt");
            if (lines != null)
            {
                foreach(string l in lines)
                {
                    string[] data = l.Split(';');
                    string Name = data[0];
                    bool InGame = ToBoolean(data[1]);
                    int Score = ToInt32(data[2]);
                    int MaxScore = ToInt32(data[3]);
                    List<string> Words = data[4].Split(',').ToList();
                    Finished.Add(new Player(Name, InGame, Score, MaxScore, Words));
                }
            }
            NotFinished = new List<Player>();
            string[] lines2 = ReadAllLines("dataPlayers/NotFinished.txt");
            if (lines2 != null)
            {
                foreach (string l in lines2)
                {
                    string[] data = l.Split(';');
                    string Name = data[0];
                    bool InGame = ToBoolean(data[1]);
                    int Score = Convert.ToInt32(data[2]);
                    int MaxScore = Convert.ToInt32(data[3]);
                    List<string> Words = data[4].Split(',').ToList();
                    NotFinished.Add(new Player(Name, InGame, Score, MaxScore, Words));
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>this method is used to ad a player to .</summary>
        public void AddPlayer(Player p)
        {
            if (p.InGame)
            {
                Finished.Add(p);
            }
            else
            {
                NotFinished.Add(p);
            }
        }
        /// <summary>this method is used to check the equality between two lists.</summary>
        public bool Equals(Ranking other)
        {
            foreach (Player p in Finished)
            {
                if (!other.Finished.Contains(p))
                    return false;
            }return true;
        }
        public void Print()
        {
            WriteLine("Finished :");
            foreach (Player p in Finished)
            {
                WriteLine(p);
            }
            WriteLine("Not finished :");
            foreach (Player p in NotFinished)
            {
                WriteLine(p);
            }
        }
        #endregion
    }
}