using UnityEngine;

namespace MyUtils
{
    public static class PlayerUtils
    {
        public static bool CheckThatObjectIsPlayer(GameObject obj)
        {
            return obj.GetComponent<ThisPlayer>() != null;
        }
    }
}