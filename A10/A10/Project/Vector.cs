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
            _Type[] D = new _Type[list.Count()];
            int i = 0;
            foreach (var d in list)
            {
                D[i] = d;
                i++;
            }
            this.Data = D;
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
                _Type[] v = this.Data;
                v[index] = value;

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
            try
            {
                if (v1.Data.Length != v2.Data.Length) { }

                dynamic sum = 0;
                for (int i = 0; i < v1.Data.Length; i++)
                {

                    sum = Convert.ToInt32(v1.Data[i].ToString()) + Convert.ToInt32(v2.Data[i].ToString());
                    res.Data[i] = sum;
                }


            }
            catch
            {
                throw new Exception();

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
            try
            {
                dynamic multiply = 0;
                if (v1.Data.Length != v2.Data.Length) { }


                for (int i = 0; i < v1.Data.Length; i++)
                {

                    multiply = Convert.ToInt32(v1.Data[i].ToString()) * Convert.ToInt32(v2.Data[i].ToString());
                    res += multiply;
                }


            }
            catch
            {
                throw new Exception();

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
            int count = 0;
            try
            {
                for (int i = 0; i < v1.Data.Length; i++)
                    if (v1.Data[i].ToString() != v2.Data[i].ToString())
                        count++;
            }
            catch {; }
            return count >=1;
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
                if(v1.Data.Length == this.Data.Length)
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
            if (other == null)
                return false;

            if (this.Data == other.Data)
                return true;
            else
                return false;
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
