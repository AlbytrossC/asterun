using UnityEngine;

namespace ASTERUN
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private GlobalBool test;

        private void Start()
        {
            test.Value = true;
        }
    }
}

