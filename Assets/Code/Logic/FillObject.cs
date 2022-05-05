using UnityEngine;

namespace Code.Logic
{
    public class FillObject : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Material _material;
        
        private const string _fillAnimationFill = "Fill";
        
        public void Fill(Color color)
        {
            gameObject.SetActive(true);
            _material.color = color;
            _animator.Play(_fillAnimationFill);
        }
    }
}
