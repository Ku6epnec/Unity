using UnityEngine;


namespace EnemyDiscription
{
    public class Enemy : MonoBehaviour
    {
        #region Fields 

        [SerializeField] private GameObject _sounder;

        [SerializeField] private int _health = 3;
        [SerializeField] private int _damage = 2;

        [SerializeField] private float _moveSpeed = 1.0f;
        [SerializeField] private float _speedRotation = 1.0f;
        [SerializeField] private float _hitDelay = 2.0f;

        private GameObject _player;

        public Rigidbody _enemyRigidBody;

        private float _timeHit;
        private Transform _target;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        } 

        void Update()
        {
            _timeHit += Time.deltaTime;
            _target = _player.transform;

            Vector3 targetDir = _target.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, _speedRotation * Time.deltaTime, 0.0F);
             
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.position += _moveSpeed * transform.forward * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player") && (_hitDelay < _timeHit))
            {
                var player = other.GetComponent<Player.FirstScript>();
                player.Hurt(_damage);
            }
        }

        #endregion


        #region Methods
        public void Hurt(int damage)
        {
            print("Ouch: " + damage);

            _health -= damage; ;

            if (_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
            Instantiate(_sounder, transform.position, transform.rotation);
        }
        #endregion
    }
}
