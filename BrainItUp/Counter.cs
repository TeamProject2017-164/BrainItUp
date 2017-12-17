using DatabaseModels.Models;

namespace BrainItUp
{
    public class Counter
    {
        public Counter()
        {
            _user = new User();
            _value = 0;
        }

        private int _value;
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private int _rightAnswers;
        public int RightAnswers
        {
            get { return _rightAnswers; }
            set { _rightAnswers =value; }
        }

        private User _user;
        public User User
        {
            get { return _user; }
        }


    }
}
