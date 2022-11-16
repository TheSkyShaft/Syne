using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Tutorial
{
    public class SeaSoundFollower : MonoBehaviour
    {
        [SerializeField]
        private Transform waterTransform;

        private float _waterVerticalPosition;
        private Transform _playerTransform;

        private void Awake()
        {
            _waterVerticalPosition = waterTransform.position.y;
            _playerTransform = FindObjectOfType<ThirdPersonCharacter>().transform;
        }

        private void Update()
        {
            transform.position = new Vector3(_playerTransform.position.x, _waterVerticalPosition,
                _playerTransform.position.z);
        }
    }
}