using System;

namespace Code.Logic
{
    public class Score
    {
        private int _score;
        public Action<int> ScoreChanged;

        public void SetResult(int result)
        {
            _score = result;
            ScoreChanged?.Invoke(_score);
        }

        public void CleanUp()
        {
            SetResult(0);
        }
    }
}