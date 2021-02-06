using System.Collections;
using UnityEngine;

namespace lisandroct.EventSystem
{
	public abstract class EventDetector<T> : MonoBehaviour
	{
		public void OnEventRaised(T arg1)
		{
			Debug.Log("Raised " + gameObject.name + " with " + arg1);
		}
	}

	public abstract class EventDetector<T, U> : MonoBehaviour
	{
		public void OnEventRaised(T arg1, U arg2)
		{
			Debug.Log("Raised " + gameObject.name + " with " + arg1 + ", " + arg2);
		}
	}

	public abstract class EventDetector<T, U, V> : MonoBehaviour
	{
		public void OnEventRaised(T arg1, U arg2, V arg3)
		{
			Debug.Log("Raised " + gameObject.name + " with " + arg1 + ", " + arg2 + ", " + arg3);
		}
	}

	public abstract class EventDetector<T, U, V, W> : MonoBehaviour
	{
		public void OnEventRaised(T arg1, U arg2, V arg3, W arg4)
		{
			Debug.Log("Raised " + gameObject.name + " with " + arg1 + ", " + arg2 + ", " + arg3 + ", " + arg4);
		}
	}
}
