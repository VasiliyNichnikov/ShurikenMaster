using Shurikens;
using UnityEngine;

namespace MyUtils
{
    public static class ShurikenUtils
    {
        public static bool CheckThatObjectIsSuriken(GameObject obj)
        {
            return obj.GetComponent<ThisShuriken>() != null;
        }
    }
}