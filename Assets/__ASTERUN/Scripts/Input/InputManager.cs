using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace ASTERUN
{
    public class InputManager : MonoBehaviour
    {
        public InputActionAsset inputActions;
        public UnityEvent onTouchPress;
        public UnityEvent onTouchRelease;
        public bool touchHeld;

        
        private InputActionMap MenuUI;
        private InputActionMap MidRun;

        private void OnEnable()
        {
            MenuUI = inputActions.actionMaps[0];
            MidRun = inputActions.actionMaps[1];
        }

        public void OnTouch()
        {
            switch (touchHeld)
            {
                case true:
                    touchHeld = false;
                    onTouchRelease.Invoke(); // when the touch is released
                    break;
                case false:
                    touchHeld = true;
                    onTouchPress.Invoke(); // when the touch begins
                    break;
            }
        }








    }
}


