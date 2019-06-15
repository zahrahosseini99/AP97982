using System;
using System.Collections.Generic;
using System.IO;
namespace E2
{
    public class MyString
    {
        private string _Input;
        public string Input
        {
            get
            {
                return this._Input;
            }
            set
            {
                value = this._Input;
            }
        }

        public MyString(string salam)
        {
            this._Input = salam;

        }
        public static implicit operator MyString(string s)
        {
            MyString s1 = new MyString(s);

            return s1;
        }
        public static explicit operator string(MyString s1)
        {
            return s1.Input;
        }
        public static bool operator ==(MyString s, string s1)
        {
            return s.Input == s1;
        }
        public static bool operator !=(MyString s, string s1)
        {
            return s.Input != s1;
        }
        public static MyString operator ++(MyString s)
        {
            MyString s3 = new MyString(s.Input.ToUpper());
            return s3;
        }
        public static MyString operator --(MyString s)
        {
            MyString s3 = new MyString(s.Input.ToLower());
            return s3;

        }
        public override bool Equals(object obj)
        {
            MyString other = obj as MyString;
            if (other == null)
                return false;
            else
                return other == this.Input ^ other == this.Input.ToLower() ^ other == this.Input.ToUpper();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}