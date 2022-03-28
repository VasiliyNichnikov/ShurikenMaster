using Parameters.Enemy;
using UnityEngine;

namespace Enemies.Robot
{
    public class Action
    {
        protected Transform TransformObj;
        protected Transform Player;

        protected RobotParameter Parameter;
        
        public Action(Transform transformObj, Transform player, RobotParameter parameter)
        {
            Player = player;
            TransformObj = transformObj;
            Parameter = parameter;
        }
    }
}