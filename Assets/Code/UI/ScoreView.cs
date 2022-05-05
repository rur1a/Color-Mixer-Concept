using Code.Logic;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        private Score _score;
        
        public void Init(Score score)
        {
            _score = score;
            _score.ScoreChanged += OnScoreChanged;
        }

        private void OnScoreChanged(int score) => 
            _scoreText.text = $"{score}%";

        public void CleanUp() => 
            _score.CleanUp();
    }
    }
