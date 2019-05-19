using System;
using System.Collections.Generic;

namespace A7
{
    public class EduInstitute<TTeacher> where TTeacher : ITeacher, ICitizen
    {
        private string _Title;
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }
        private Degree _MinimumDegree;
        public Degree MinimumDegree
        {
            get
            {
                return _MinimumDegree;
            }
            set
            {
                _MinimumDegree = value;
            }
        }
        private List<TTeacher> _Teachers = new List<TTeacher>();
        public List<TTeacher> Teachers
        {
            get
            {
                return Teachers;
            }
            set
            {
                _Teachers = value;
            }
        }
        public EduInstitute(string title, Degree minimumDegree)
        {
            this._Title = title;
            this._MinimumDegree = minimumDegree;

        }

        public bool Register(TTeacher teacher)
        {
            if (teacher.TopDegree >= MinimumDegree)
            {
                Teachers.Add(teacher);
                return true;
            }
            return false;
        }

        public bool IsEligible(TTeacher teacher)
        {

            return teacher.TopDegree >= MinimumDegree;
              

        }
    }
}