using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ASTERUN
{
    public class GlobalVariable<T> : ScriptableObject
    {
        [Tooltip("value at runtime")]
        [SerializeField] protected T defaultValue;
        [SerializeField] protected T runtimeValue;
        [SerializeField] protected bool doReset = true;

        public virtual T Value
        {
            get => runtimeValue;
            set
            {
                runtimeValue = value;
                OnValueChanged?.Invoke(value);
            }
        }
        public delegate void ValueChanged(T newValue);
        public event ValueChanged OnValueChanged;

        //private void OnValidate() => ResetValue();
        private void Awake() => ResetValue();
        private void ResetValue()
        {
            if (doReset) runtimeValue = defaultValue;
        }
    }

    [CreateAssetMenu(menuName = "Global/Bool", fileName = "GlobalBoolVar")]
    public class GlobalBool : GlobalVariable<bool> { }


    [CreateAssetMenu(menuName = "Global/Float", fileName = "GlobalFloatVar")] 
    public class GlobalFloat : GlobalVariable<float> { }


    [CreateAssetMenu(menuName = "Global/GameObject", fileName = "GlobalGameObjectVar")]
    public class GlobalGameObject : GlobalVariable<GameObject> { }



}
