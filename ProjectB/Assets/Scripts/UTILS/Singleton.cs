using UnityEngine;

namespace UTILS
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;

        public static T Instance => instance;

        public static bool IsInit() => instance != null;

        protected virtual void Awake()
        {
            if (instance == null)
                instance = (T) this;

        }

        protected virtual void OnDestroy()
        {
            if (instance == this)
                instance = null;
        }
    }
}
