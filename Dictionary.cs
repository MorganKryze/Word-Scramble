using System;

using static System.Console;
using static System.IO.File;

using static Word_Scramble.Methods;

namespace Word_Scramble
{
    /// <summary>The dictionnary creation class.</summary>
    public class Dictionary
    {
        #region Fields
        /// <summary>The language of the dictionnary.</summary>
        public static string s_Language;
        /// <summary>The static dictionnary.</summary>
        public static Dictionary<int, string[]> s_Dict = new Dictionary<int, string[]>();
        /// <summary>The dynamic dictionary.</summary>
        public Dictionary<int, List<string>> ListDict = new Dictionary<int, List<string>>();
        #endregion
        
        #region Constructor
        /// <summary>The constructor of the class.</summary>
        public Dictionary()
        {
            ListDict = s_Dict.ToDictionary(x => x.Key, x => x.Value.ToList());
        }
        #endregion

        #region Methods
        /// <summary>This method is used to create a static dictionary.</summary>
        public static void CreateDictionary()
        {
            if (s_Language == null) s_Language = "FR";
            string[] lines = s_Language == "FR" ? ReadAllLines("dataDictionary/MotsPossiblesFR.txt") : ReadAllLines("dataDictionary/MotsPossiblesEN.txt");
            int[] Key = lines.Where((x, i) => i % 2 == 0).Select(x => int.Parse(x)).ToArray();
            string[][] Value = lines.Where((x, i) => i % 2 != 0).Select(x => x.Split(' ')).ToArray();

            s_Dict = Key.Zip(Value, (s, i) => new { s, i }).ToDictionary(item => item.s, item => item.i);
            
        }
        /// <summary>This method is used to display the dimensions of the dictionary.</summary>
        public static void Dimensions()
        {
            foreach (KeyValuePair<int, string[]> entry in s_Dict)
            {
                WriteLine("Length = {0}, Words = {1}", entry.Key, entry.Value.Length);
            }
        }
        /// <summary> Function to redefine the dictionary to the size of the Dictionnary</summary>
        /// <param name="data">The dictionary to resize</param>
        /// <param name="sizeMin">The minimum size of the words</param>
        /// <param name="sizeMax">The maximum size of the words</param>
        /// <returns>Dictionary with the new size</returns>
        public static Dictionary<int, string[]> ResizeDictionary(Dictionary<int,string[]> data,int sizeMin, int sizeMax)
        {
            return data.Where(x => (x.Key<= sizeMax && x.Key >=sizeMin)).ToDictionary(x => x.Key, x => x.Value);
        }
        /// <summary>This method is used to check whether a word is in the dictionary or not.</summary>
        /// <param name="mot">The word to search.</param>
        /// <returns>A boolean indicating if the word is in the dictionary.</returns>
        public static bool Search(string mot)
        {
            int size = mot.Length;
            return IsInDictionary(mot, s_Dict[size], 0, s_Dict[size].Length - 1, (s_Dict[size].Length - 1) / 2);

        }
        /// <summary>This method is used to check whether a word is in the dictionary or not.</summary>
        /// <param name="mot">The word to search.</param>
        /// <param name="taille">The list of words of the same size as the word to search.</param>
        /// <param name="min">The minimum index of the list.</param>
        /// <param name="max">The maximum index of the list.</param>
        /// <param name="milieu">The middle index of the list.</param>
        /// <returns>A boolean indicating if the word is in the dictionary.</returns>
        public static bool IsInDictionary(string mot, string[]taille, int min, int max, int milieu)
        {
            if (mot == taille[milieu]) return true;
            else if (mot != taille[milieu] && min == max) return false;
            else if (mot != taille[milieu] && min != max)
            {
                if (mot.CompareTo(taille[milieu]) < 0) return IsInDictionary(mot, taille, min, milieu - 1, (min + milieu - 1) / 2);
                else return IsInDictionary(mot, taille, milieu + 1, max, (milieu + 1 + max) / 2);
            }
            else return false;
        }
        #endregion

    }
}