using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class EndLevelMessage : MonoBehaviour
    {
        public event Action Pressed; 
        [SerializeField] private Button _continueButton;

        private void Awake() => 
            _continueButton.onClick.AddListener(OnPressed);

        private void OnPressed() => 
            Pressed?.Invoke();
    }
}