using MyUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelTransition
{
    public class WorkingWithLevel : MonoBehaviour
    {
        [SerializeField] private int _maxLevel;

        public static void Reload()
        {
            SceneManager.LoadScene(GetIndexActiveScene());
        }

        private static int GetIndexActiveScene()
        {
            return SceneManager.GetActiveScene().buildIndex;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (PlayerUtils.CheckThatObjectIsPlayer(other.gameObject))
            {
                Next();
            }
        }

        private void Next()
        {
            int nextScene = GetIndexActiveScene() + 1;
            SceneManager.LoadScene(nextScene < _maxLevel ? nextScene : 0);
        }
    }
}
