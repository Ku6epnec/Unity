using UnityEngine;


namespace Dangerous
{
    public class DestroyPlayer : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _lifeTime = 5.0f;
        [SerializeField] private float _moveSpeed = 4.0f;
        [SerializeField] private int _damage = 1;

        #endregion


        #region UnityMethods

        void Start()
        {
            Destroy(gameObject, _lifeTime);
        }

        private void Update()
        {
            transform.position += _moveSpeed * transform.up * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var player = other.GetComponent<Player.FirstScript>();
                player.Hurt(_damage);
                Destroy(gameObject);
                print($"Enter {other.name}");
            }
        }

        #endregion
    }
}