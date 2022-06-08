using System;
using UnityEngine;
using lisandroct.EventSystem;

namespace PaulMasriStone.EventSystem
{
	public class GameEventDetector : MonoBehaviour
	{
		public GameEvent Event;

		private event Action Callback;

		private void OnEnable()
		{
			Callback += OnEventRaised;
			Event?.Register(Callback);
		}

		private void OnDisable() {
			Event?.Unregister(Callback);
			Callback -= OnEventRaised;
		}

		public void OnEventRaised()
		{
			Debug.Log($"Raised {gameObject.name}");
		}
	}
}
