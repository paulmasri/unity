using System;
using System.Collections;
using UnityEngine;
using lisandroct.EventSystem;

namespace PaulMasriStone.EventSystem
{
	public abstract class GameEventDetector<T> : MonoBehaviour
	{
		public GameEvent<T> Event;
		private event Action<T> Callback;

		private void OnEnable()
		{
			Callback += OnEventRaised;
			Event?.Register(Callback);
		}

		private void OnDisable() {
			Event?.Unregister(Callback);
			Callback -= OnEventRaised;
		}

		public void OnEventRaised(T arg1)
		{
			Debug.Log($"Raised {gameObject.name} with {arg1}");
		}
	}

	public abstract class GameEventDetector<T, U> : MonoBehaviour
	{
		public GameEvent<T, U> Event;
		private event Action<T, U> Callback;

		private void OnEnable()
		{
			Callback += OnEventRaised;
			Event?.Register(Callback);
		}

		private void OnDisable() {
			Event?.Unregister(Callback);
			Callback -= OnEventRaised;
		}

		public void OnEventRaised(T arg1, U arg2)
		{
			Debug.Log($"Raised {gameObject.name} with {arg1},{arg2}");
		}
	}

	public abstract class GameEventDetector<T, U, V> : MonoBehaviour
	{
		public GameEvent<T, U, V> Event;
		private event Action<T, U, V> Callback;

		private void OnEnable()
		{
			Callback += OnEventRaised;
			Event?.Register(Callback);
		}

		private void OnDisable() {
			Event?.Unregister(Callback);
			Callback -= OnEventRaised;
		}

		public void OnEventRaised(T arg1, U arg2, V arg3)
		{
			Debug.Log($"Raised {gameObject.name} with {arg1},{arg2},{arg3}");
		}
	}

	public abstract class GameEventDetector<T, U, V, W> : MonoBehaviour
	{
		public GameEvent<T, U, V, W> Event;
		private event Action<T, U, V, W> Callback;

		private void OnEnable()
		{
			Callback += OnEventRaised;
			Event?.Register(Callback);
		}

		private void OnDisable() {
			Event?.Unregister(Callback);
			Callback -= OnEventRaised;
		}

		public void OnEventRaised(T arg1, U arg2, V arg3, W arg4)
		{
			Debug.Log($"Raised {gameObject.name} with {arg1},{arg2},{arg3},{arg4}");
		}
	}
}
