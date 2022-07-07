using Fengj.Interfaces;

namespace Fengj.Sessions.Entities
{
    public class Date : IDate
    {
        public int year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value;
            }
        }

        public int month
        {
            get
            {
                return _month;
            }
            set
            {
                _month = value;
                if (_month > 12)
                {
                    year += 1;
                    _month = 1;
                }
            }
        }

        public int day
        {
            get
            {
                return _day;
            }
            set
            {
                _day = value;
                if (_day > 30)
                {
                    month += 1;
                    _day = 1;
                }
            }
        }

        private int _year;
        private int _month;
        private int _day;

        public Date()
        {
            year = 1;
            month = 1;
            day = 1;
        }
    }
}
