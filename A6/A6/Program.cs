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

        TypeOfSize32768 a;
        TypeOfSize32768[] values;
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
        public StructOrClass1(Object x)
        {
            X = x;
        }


    }
    public class StructOrClass2
    {
        public object X;
        object x;
        public StructOrClass2()
        {
            X = x;
        }
    }
    public class StructOrClass3
    {
        public StructOrClass2 X;
        StructOrClass2 x;
        public StructOrClass3()
        {
            X = x;
        }
    }
   
    public struct TypeOfSize10240
    {
        TypeOfSize1024 a;
        TypeOfSize1024 b;
        TypeOfSize1024 c;
        TypeOfSize1024 d;
        TypeOfSize1024 e;
        TypeOfSize1024 f;
        TypeOfSize1024 g;
        TypeOfSize1024 h;
        TypeOfSize1024 i;
        TypeOfSize1024 j;
    }
    public struct TypeForMaxStackOfDepth10
    {
        TypeOfSize10240 a;
        TypeOfSize10240 b;
        TypeOfSize10240 a1;
        TypeOfSize10240 b1;
        TypeOfSize1024 c;
        TypeOfSize1024 d;
    }

    public struct TypeForMaxStackOfDepth100
    {
        TypeOfSize1024 a;
        TypeOfSize1024 a1;
        TypeOfSize1024 b;
        TypeOfSize1024 b1;
        TypeOfSize125 c;
        TypeOfSize125 c1;
        TypeOfSize125 d;
        TypeOfSize125 e;
        TypeOfSize22 f;
        TypeOfSize22 g;
        TypeOfSize22 h;
        TypeOfSize22 i;
        TypeOfSize22 m;
    }

    public struct TypeForMaxStackOfDepth1000
    {

        TypeOfSize125 a;
        TypeOfSize125 b;
        TypeOfSize125 z;
        TypeOfSize22 c;
        TypeOfSize22 d;
        TypeOfSize22 e;
        TypeOfSize22 f;
        //TypeOfSize22 TypeOfSize22_5;
        TypeOfSize5 g;
        TypeOfSize5 h;
        TypeOfSize5 o;
        //TypeOfSize5 TypeOfSize5_4;
        TypeOfSize5 i;
        //byte char_1;
        //byte char_2;
        //byte char_3;
        //byte char_4;
        //byte char_5;
    }

    public struct TypeForMaxStackOfDepth3000
    {


        TypeOfSize22 a;
        TypeOfSize22 b;
        TypeOfSize22 m;
        TypeOfSize22 n;
        TypeOfSize5 c;
        TypeOfSize5 d;
        TypeOfSize5 e;

        TypeOfSize5 a1;
        TypeOfSize5 a2;

    }

   

    public struct TypeOfSize5
    {
        byte a;
        byte b;
        byte c;
        byte d;
        byte e;
    }
    public struct TypeOfSize22
    {
        TypeOfSize5 a;
        TypeOfSize5 b;
        TypeOfSize5 c;
        TypeOfSize5 d;
        byte f;
        byte e;
    }
    public struct TypeOfSize125
    {
        TypeOfSize22 a;
        TypeOfSize22 b;
        TypeOfSize22 c;
        TypeOfSize22 d;
        TypeOfSize22 e;

        TypeOfSize5 f;
        TypeOfSize5 g;
        TypeOfSize5 h;
    }
    public struct TypeOfSize1024
    {

        TypeOfSize125 a;
        TypeOfSize125 b;
        TypeOfSize125 c;
        TypeOfSize125 d;
        TypeOfSize125 e;
        TypeOfSize125 f;
        TypeOfSize125 g;
        TypeOfSize125 h;
        TypeOfSize22 i;
        byte x;
        byte z;

    }
    public struct TypeOfSize32768
    {
        TypeOfSize1024 a;
        TypeOfSize1024 b;
        TypeOfSize1024 c;
        TypeOfSize1024 d;
        TypeOfSize1024 e;
        TypeOfSize1024 f;
        TypeOfSize1024 g;
        TypeOfSize1024 h;
        TypeOfSize1024 m;
        TypeOfSize1024 hn;
        TypeOfSize1024 a1;
        TypeOfSize1024 b1;
        TypeOfSize1024 c1;
        TypeOfSize1024 d1;
        TypeOfSize1024 e1;
        TypeOfSize1024 f1;
        TypeOfSize1024 g1;
        TypeOfSize1024 h1;
        TypeOfSize1024 m1;
        TypeOfSize1024 hn1;
        TypeOfSize1024 a2;
        TypeOfSize1024 b2;
        TypeOfSize1024 c2;
        TypeOfSize1024 d2;
        TypeOfSize1024 e2;
        TypeOfSize1024 f2;
        TypeOfSize1024 g2;
        TypeOfSize1024 h2;
        TypeOfSize1024 m2;
        TypeOfSize1024 hn2;
        TypeOfSize1024 m3;
        TypeOfSize1024 hn3;
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
            if(fht== FutureHusbandType.IsShort)
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
