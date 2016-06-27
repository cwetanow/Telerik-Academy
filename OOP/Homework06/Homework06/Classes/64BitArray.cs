using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework06.Classes
{
    public class _64BitArray : IEnumerable<int>
    {
        public ulong Value { get; set; }
        public byte[] Bits { get;}
        public _64BitArray(ulong val)
        {
            this.Value = val;
            this.Bits = new byte[64];
            for (int i = 63; i >-1; i--)
            {
                this.Bits[i] = (byte)(val % 2);
                val /= 2;
            }
        }
        public override string ToString()
        {
            return string.Join("", this.Bits);
        }
        public override bool Equals(object obj)
        {
            return this.Value.Equals((obj as _64BitArray).Value);
        }
        public override int GetHashCode()
        {
            return this.Bits.GetHashCode();
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var item in this.Bits)
            {
                yield return item;
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Console.WriteLine(3);
            return GetEnumerator();
        }

        public static bool operator ==(_64BitArray a, _64BitArray b) {
            return a.Value == b.Value;
        }
        public static bool operator !=(_64BitArray a, _64BitArray b)
        {
            return a.Value != b.Value;
        }
        public byte this[int index]
        {
            get
            {
                if (index < 0 || index > 63)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }
                else
                {
                    return this.Bits[index];
                }
            }
        }

    }
}
