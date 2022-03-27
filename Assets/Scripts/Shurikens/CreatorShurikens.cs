using UnityEngine;

namespace Shurikens
{
    public class CreatorShurikens
    {
        private GameObject _shuriken;
        private Transform _parent;

        public CreatorShurikens(GameObject prefab, Transform parent)
        {
            _shuriken = prefab;
            _parent = parent;
        }
        
    }
}