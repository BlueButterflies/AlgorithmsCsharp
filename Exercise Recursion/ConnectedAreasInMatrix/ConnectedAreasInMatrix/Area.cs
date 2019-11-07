using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectedAreasInMatrix
{
    class Area : IComparable
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int Size { get; set; }

        public int CompareTo(object otherr)
        {
            Area other = (Area)otherr;

            if (this.Size != other.Size)
            {
                return other.Size.CompareTo(this.Size);
            }

            if (this.Row != other.Row)
            {
                return this.Row.CompareTo(other.Row);
            }

            return this.Col.CompareTo(other.Col);
        }
    }
}
