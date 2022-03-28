using UnityEngine;

namespace MovementAlongSpline
{
    public interface IRoute
    {
        public Vector3[] Points { get; }
        public float Spacing { get; set; }

        public void Build();
    }
}