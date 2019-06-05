using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10
{
    /// <summary>
    /// A vector of numbers. Implement vector addition and multiplication.
    /// </summary>
    /// <typeparam name="_Type"></typeparam>
    public class Vector<_Type> :
        IEnumerable<_Type>, IEquatable<Vector<_Type>>
        where _Type : IEquatable<_Type>
    {
        /// <summary>
        /// Vector data
        /// </summary>
        protected readonly _Type[] Data;

        /// <summary>
        /// Add index. Only used for collection initialization.
        /// </summary>
        protected int AddIndex = 0;

        /// <summary>
        /// Vector Size
        /// </summary>
        public int Size => Data.Length;

        /// <summary>
        /// Add method to allow collection initialization.
        /// </summary>
        /// <param name="v"></param>
        public void Add(_Type v)
        {
            Data[AddIndex++] = v;
        }

        /// <summary>
        /// Create a new Vector
        /// </summary>
        /// <param name="length">Vector length</param>
        public Vector(int length)
        {
            this.Data = new _Type[length];

        }


        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="other"></param>
        public Vector(Vector<_Type> other)
            : this(other.Size)
        {
            foreach (var d in other.Data)
                this.Add(d);
        }

        /// <summary>
        /// Constructor for IEnumerable
        /// </summary>
        /// <param name="list">IEnumerable of _Type</param>
        public Vector(IEnumerable<_Type> list)
            : this(list.Count())
        {


            foreach (var d in list)
            {
                Add(d);
            }

        }

        /// <summary>
        /// Accessor for data elements
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public _Type this[int index]
        {
            get
            {
                return this.Data[index];
            }
            set
            {
               
                this.Data[index] = value;

            }
        }

        /// <summary>
        /// Add two vectors
        /// </summary>
        /// <param name="v1">vector 1</param>
        /// <param name="v2">vector 2</param>
        /// <returns>sum of vector 1 and 2</returns>
        public static Vector<_Type> operator +(Vector<_Type> v1, Vector<_Type> v2)
        {
            Vector<_Type> res = new Vector<_Type>(v1.Data.Length);

            if (v1.Data.Length != v2.Data.Length)
            {
                throw new Exception("The vectors don't have the same size.");
            }
            else
            {
                dynamic sum = 0;
                for (int i = 0; i < v1.Data.Length; i++)
                {
                    dynamic n = v1.Data[i];
                    dynamic m = v2.Data[i];
                    sum = n + m;
                    res.Data[i] = sum;
                }

            }
            return res;
        }

        /// <summary>
        /// Inner product of two vectors
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>Inner product of vector one and two</returns>
        public static _Type operator *(Vector<_Type> v1, Vector<_Type> v2)
        {
            dynamic res = 0;

            dynamic multiply = 0;
            if (v1.Data.Length != v2.Data.Length)
            {
                throw new Exception("The vectors don't have the same size.");
            }
            else
            {
                for (int i = 0; i < v1.Data.Length; i++)
                {
                    dynamic n1 = v1.Data[i];
                    dynamic n2 = v2.Data[i];
                    multiply = n1 * n2;
                    res += multiply;
                }
            }
            return res;

        }

        public override string ToString()
        {
            string res = "[";
            foreach (var d in Data)
            {
                res += d + ",";
            }
            res = res.TrimEnd(',') + "]";
            return res;
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="v1">vector 1</param>
        /// <param name="v2">vector 2</param>
        /// <returns>whether v1 is equal to v2</returns>
        public static bool operator ==(Vector<_Type> v1, Vector<_Type> v2)
        {
            int count = 0;
            if (v1.Data.Length == v2.Data.Length)
            {
                for (int i = 0; i < v1.Data.Length; i++)
                {
                    if (v1.Data[i].ToString() == v2.Data[i].ToString())
                        count++;
                }
            }
            return (count == v1.Data.Length);


        }


        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="v1">vector 1</param>
        /// <param name="v2">vector 2</param>
        /// <returns>v1 not equal to v2</returns>
        public static bool operator !=(Vector<_Type> v1, Vector<_Type> v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        /// Override Object.Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Whether this object is equal to obj</returns>
        public override bool Equals(object obj)
        {
            int count = 0;
            Vector<_Type> v1 = obj as Vector<_Type>;
            if (v1.Data == null)
                return false;


            else
            {
                if (v1.Data.Length == this.Data.Length)
                {
                    for (int i = 0; i < v1.Data.Length; i++)
                    {
                        if (v1.Data[i].ToString() == this.Data[i].ToString())
                            count++;
                    }
                    return count == v1.Data.Length;
                }


            }
            return false;
        }

        /// <summary>
        /// Implementing IEquatable interface
        /// </summary>
        /// <param name="other">another vector</param>
        /// <returns>whether other vector is equal to this vector</returns>
        public bool Equals(Vector<_Type> other)
        {
            return this.Data == other.Data;
        }

        public override int GetHashCode()
        {
            int hashcode = Data.Length;
            for (int i = 0; i < Data.Length; ++i)
            {
                hashcode = unchecked(hashcode * 314159 + Convert.ToInt32(Data[i]));
            }
            return hashcode;

        }

        public IEnumerator<_Type> GetEnumerator()
        {
            foreach (var d in Data)
            {
                yield return d;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
