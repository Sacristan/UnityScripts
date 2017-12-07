using UnityEngine;

namespace Sacristan.Utils
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;

        #region Properties
        public static T Instance { get { return instance; } }
        public static bool IsInitialized { get { return instance != null; } }
        #endregion

        #region MonoBehaviour
        protected virtual void Awake()
        {
            if (instance != null)
            {
                Debug.LogErrorFormat("Trying to instantiate a second instance of singleton class {0}", GetType().Name);
            }
            else
            {
                instance = (T)this;
            }
        }

        protected virtual void OnDestroy()
        {
            if (instance == this) instance = null;
        }
        #endregion
    }
}
