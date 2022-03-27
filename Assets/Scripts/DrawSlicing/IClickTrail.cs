using UnityEngine;

namespace DrawSlicing
{
    public interface IClickTrail
    {
        public void ClickDown(Vector3 newPosition);

        public void ClickDrag(Vector3 newPosition);

        public void ClickUp(Vector3 newPosition);
    }
}