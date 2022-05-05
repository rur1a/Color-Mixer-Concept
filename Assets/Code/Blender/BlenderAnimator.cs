using Code.UI;
using UnityEngine;

namespace Code.Blender
{
    public class BlenderAnimator : MonoBehaviour, ICleanUp
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private MixAnimator _mixAnimator;
        private static readonly int Open = Animator.StringToHash("Open");
        
        public void Fill(Color produceColor) => 
            _mixAnimator.Fill(produceColor);
        public void PlayAddItem() => 
            _animator.SetTrigger(Open);
        public void CleanUp() => 
            _mixAnimator.Empty();
    }
}