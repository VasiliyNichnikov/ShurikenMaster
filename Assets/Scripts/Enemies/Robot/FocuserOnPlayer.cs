using System.Collections;
using Parameters.Enemy;
using UnityEngine;

namespace Enemies.Robot
{
    public class FocuserOnPlayer: Action
    {
        public FocuserOnPlayer(Transform transformObj, Transform player, RobotParameter parameter) : base(transformObj, player, parameter)
        {
        }

        public IEnumerator Focus(IEnumerator shoot)
        {
            Vector3 direction = Player.position - TransformObj.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            yield return new WaitForSeconds(Parameter.DelayBeforeFocusing);
            
            float angle = Quaternion.Angle(TransformObj.rotation, rotation);
            while (angle > Parameter.MinAngle)
            {
                var step = Parameter.SpeedRotationHead * Time.deltaTime;
                TransformObj.rotation = Quaternion.RotateTowards(TransformObj.rotation, rotation, step);
                angle = Quaternion.Angle(TransformObj.rotation, rotation);
                yield return null;
            }

            yield return shoot;
        }
    }
}