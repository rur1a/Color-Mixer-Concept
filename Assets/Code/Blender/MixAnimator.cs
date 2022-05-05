using Code.Logic;
using UnityEngine;

namespace Code.Blender
{
    public class MixAnimator : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particles;
        [SerializeField] private FillObject _fillObject;
        
        public void Fill(Color produceColor)
        {
            PlayParticles(produceColor);
            _fillObject.Fill(produceColor);
        }

        public void Empty() => 
            _fillObject.gameObject.SetActive(false);

        private void PlayParticles(Color produceColor)
        {
            ParticleSystem.MainModule particlesMain = _particles.main;
            particlesMain.startColor = produceColor;
            _particles.Play();
        }
    }
}