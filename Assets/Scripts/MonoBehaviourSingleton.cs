using UnityEngine;

namespace SnakeGame {
	public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{

		public static T Instance => s_instance;

		public static bool Exists => s_instance != null;

		protected static T s_instance;


		protected virtual void Awake()
		{
			if (s_instance != null)
			{
				Debug.LogWarning("s_instance already exists!");
				Destroy(gameObject);
				return;
			}

			s_instance = this as T;
		}


		protected virtual void OnDestroy()
		{
			if (s_instance == this)
			{
				s_instance = null;
			}
		}
	}
}
