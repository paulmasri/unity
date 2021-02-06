using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PaulMasriStone.Developer
{
    public class TimeScalar : MonoBehaviour
    {
    	public float timeScaleIncrementFactor;
    	public float minTimeScale;
    	public float maxTimeScale;

        public void OnNormalSpeed(InputAction.CallbackContext context)
        {
            if (context.performed)
                Time.timeScale = 1f;
        }

        public void OnSpeedChange(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
            	var factor = (context.ReadValue<float>() > 0)? timeScaleIncrementFactor: 1f / timeScaleIncrementFactor;
            	Time.timeScale = Mathf.Clamp(Time.timeScale * factor, minTimeScale, maxTimeScale);
            }
        }

        public void OnStop(InputAction.CallbackContext context)
        {
            if (context.performed)
                Time.timeScale = 0f;
        }
    }
}