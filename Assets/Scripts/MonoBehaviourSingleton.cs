using UnityEngine;


public abstract class MonoBehaviourSingleton< T > : MonoBehaviour where T : MonoBehaviour
{

	public static T Instance => s_instance;

	public static bool Exists => s_instance != null;

	protected static T s_instance;


	protected virtual void Awake()
	{
		if ( s_instance != null )
		{
			Debug.LogError( "s_instance already exists!" );
			return;
		}

		s_instance = this as T;
	}


	protected virtual void OnDestroy()
	{
		s_instance = null;
	}

}
