namespace BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64 : IEnumerable<int>
    {
        private static ulong hashGenerator;
        private ulong number;

        public BitArray64()
        {
            hashGenerator++;
        }

        public int this[int pos]
        {
            get
            {
                if (pos < 0 || pos >= 64)
                {
                    throw new IndexOutOfRangeException();
                }
                
                return (int)(this.number >> pos) & 1;
            }

            set
            {
                if (pos < 0 || pos >= 64)
                {
                    throw new IndexOutOfRangeException();
                }

                if (value != 0 && value != 1)
                {
                    throw new ArgumentException("Value cannot be other than '0' and '1'");
                }

                if (value == 1)
                {
                    this.number = this.number | 1ul << pos;
                }
                else
                {
                    this.number = this.number & ~(1ul << pos);
                }
            }
        }

        public static bool operator ==(BitArray64 firstBitArray, BitArray64 secondBitArray)
        {
            return BitArray64.Equals(firstBitArray, secondBitArray);
        }

        public static bool operator !=(BitArray64 firstBitArray, BitArray64 secondBitArray)
        {
            return !BitArray64.Equals(firstBitArray, secondBitArray);
        }

        public override bool Equals(object obj)
        {
            var objAsBitArray = obj as BitArray64;

            for (int i = 0; i < 64; i++)
            {
                if (this[i] != objAsBitArray[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            string bitArrayToString = string.Empty;

            foreach (var bit in this)
            {
                bitArrayToString += bit.ToString();
            }

            return bitArrayToString;
        }

        public override int GetHashCode()
        {
            return hashGenerator.GetHashCode() ^ base.GetHashCode();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}