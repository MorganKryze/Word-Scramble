using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Word_Scramble
{
    public struct Position
    {
        #region Attributes
        /// <summary>The x coordinate of the position.</summary>
        public int X {get; set;}
        /// <summary>The y coordinate of the position.</summary>
        public int Y {get; set;}
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="T:Labyrinth.Position"/> class.</summary>
        public Position (int a, int b)
        {
            X = a;
            Y = b;
        }
        #endregion

        #region Methods
        /// <summary>This method is used to convert the position to a string.</summary>
        /// <returns>The position as a string.</returns>
        public override string ToString() => $"Line : {X} ; Column {Y}";
        /// <summary>This method is used to chck if the position is equal to another position.</summary>
        /// <param name="b">The position to compare to.</param>
        /// <returns>True if the positions are equal, false otherwise.</returns>
        public bool Equals(Position b) => X == b.X && Y == b.Y;
        #endregion

    }
}