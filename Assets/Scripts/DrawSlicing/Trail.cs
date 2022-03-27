using UnityEngine;

namespace DrawSlicing
{
    public class Trail: IClickTrail
    {
        private readonly ParticleSystem _trail;
        private readonly Transform _trailTransform;

        public Trail(ParticleSystem particleTrail)
        {
            _trail = particleTrail;
            _trailTransform = _trail.transform;
        }
        
        public void ClickDown(Vector3 newPosition)
        {
            _trail.Play();
            _trailTransform.position = newPosition;
        }

        public void ClickDrag(Vector3 newPosition)
        {
            _trailTransform.position = newPosition;
        }

        public void ClickUp(Vector3 newPosition)
        {
            _trail.Stop();
        }
    }
}