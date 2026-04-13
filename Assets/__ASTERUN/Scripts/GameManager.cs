using UnityEngine;

namespace ASTERUN
{
    public class GameManager : MonoBehaviour
    {
        private PlayerBehaviour _PlayerBehaviour;
        private GameObject _Player;

        private void OnEnable()
        {
            _PlayerBehaviour = FindFirstObjectByType<PlayerBehaviour>();
            _Player = _PlayerBehaviour.gameObject;
        }
        public GameObject GetPlayer() => _Player;
        public PlayerBehaviour GetPlayerScript() => _PlayerBehaviour;
    }
}

