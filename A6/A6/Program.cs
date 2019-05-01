using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
namespace A6
{
    public class TypeWithMemoryOnHeap
    {

        public TypeOfSize32768 a;
        public TypeOfSize32768[] values;
        public void Allocate()
        {
            values = new TypeOfSize32768[120];

        }
        public void DeAllocate()
        {
            values = null;
        }

    }
    public struct StructOrClass1
    {

        public object X;

    }
    public class StructOrClass2
    {
        public object X;

    }
    public class StructOrClass3
    {
        public StructOrClass2 X;

    }

    public struct TypeOfSize10240
    {
        public TypeOfSize1024 a;
        public TypeOfSize1024 b;
        public TypeOfSize1024 c;
        public TypeOfSize1024 d;
        public TypeOfSize1024 e;
        public TypeOfSize1024 f;
        public TypeOfSize1024 g;
        public TypeOfSize1024 h;
        public TypeOfSize1024 i;
        public TypeOfSize1024 j;
    }
    public struct TypeForMaxStackOfDepth10
    {
        public TypeOfSize10240 a;
        public TypeOfSize10240 b;
        public TypeOfSize10240 a1;
        public TypeOfSize10240 b1;
        public TypeOfSize1024 c;
        public TypeOfSize1024 d;
    }

    public struct TypeForMaxStackOfDepth100
    {
        public TypeOfSize1024 a;
        public TypeOfSize1024 a1;
        public TypeOfSize1024 b;
        public TypeOfSize1024 b1;
        public TypeOfSize1024 c;
    }

    public struct TypeForMaxStackOfDepth1000
    {

        public TypeOfSize125 a;
        public TypeOfSize125 b;
        public TypeOfSize125 z;
        public TypeOfSize125 x;
    }

    public struct TypeForMaxStackOfDepth3000
    {
        public TypeOfSize125 z;
        public TypeOfSize5 s;
        public byte ap;
        public byte ao;

    }



    public struct TypeOfSize5
    {
        public byte a;
        public byte b;
        public byte c;
        public byte d;
        public byte e;
    }
    public struct TypeOfSize22
    {
        public TypeOfSize5 a;
        public TypeOfSize5 b;
        public TypeOfSize5 c;
        public TypeOfSize5 d;
        public byte f;
        public byte e;
    }
    public struct TypeOfSize125
    {
        public TypeOfSize22 a;
        public TypeOfSize22 b;
        public TypeOfSize22 c;
        public TypeOfSize22 d;
        public TypeOfSize22 e;

        public TypeOfSize5 f;
        public TypeOfSize5 g;
        public TypeOfSize5 h;
    }
    public struct TypeOfSize1024
    {

        public TypeOfSize125 a;
        public TypeOfSize125 b;
        public TypeOfSize125 c;
        public TypeOfSize125 d;
        public TypeOfSize125 e;
        public TypeOfSize125 f;
        public TypeOfSize125 g;
        public TypeOfSize125 h;
        public TypeOfSize22 i;
        public byte x;
        public byte z;

    }
    public struct TypeOfSize32768
    {
        private TypeOfSize1024 a;
        private TypeOfSize1024 b;
        private TypeOfSize1024 c;
        private TypeOfSize1024 d;
        private TypeOfSize1024 e;
        private TypeOfSize1024 f;
        private TypeOfSize1024 g;
        private TypeOfSize1024 h;
        private TypeOfSize1024 m;
        private TypeOfSize1024 hn;
        private TypeOfSize1024 a1;
        private TypeOfSize1024 b1;
        private TypeOfSize1024 c1;
        private TypeOfSize1024 d1;
        private TypeOfSize1024 e1;
        private TypeOfSize1024 f1;
        private TypeOfSize1024 g1;
        private TypeOfSize1024 h1;
        private TypeOfSize1024 m1;
        private TypeOfSize1024 hn1;
        private TypeOfSize1024 a2;
        private TypeOfSize1024 b2;
        private TypeOfSize1024 c2;
        private TypeOfSize1024 d2;
        private TypeOfSize1024 e2;
        private TypeOfSize1024 f2;
        private TypeOfSize1024 g2;
        private TypeOfSize1024 h2;
        private TypeOfSize1024 m2;
        private TypeOfSize1024 hn2;
        private TypeOfSize1024 m3;
        private TypeOfSize1024 hn3;
    }


    public enum FutureHusbandType : int
    {
        None = 1,
        HasBigNose = 2,
        IsBald = 4,
        IsShort = 8
    }

    public class Program
    {


        public static bool IdealHusband(FutureHusbandType fht)

        {

            if (fht == (FutureHusbandType.IsShort | FutureHusbandType.HasBigNose | FutureHusbandType.IsBald))
                return false;
            if (fht == (FutureHusbandType.IsShort | FutureHusbandType.HasBigNose))
                return true;
            if (fht == (FutureHusbandType.IsBald | FutureHusbandType.HasBigNose))
                return true;
            if (fht == (FutureHusbandType.IsBald | FutureHusbandType.IsShort))
                return true;
            if (fht == FutureHusbandType.IsShort)
                return false;
            if (fht == FutureHusbandType.IsBald)
                return false;
            if (fht == FutureHusbandType.HasBigNose)
                return false;
            return false;
        }

        public static int GetObjectType(object x)
        {
            if (x is string)
                return 0;
            else if (x is Array)
                return 1;
            else if (x is int)
                return 2;
            else
                return 6;

        }
        static void Main(string[] args)
        {

        }
    }
}
