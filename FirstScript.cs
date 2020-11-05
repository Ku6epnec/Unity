using UnityEngine;


namespace Player
{
    public class FirstScript : MonoBehaviour
    {

        #region Fields

        private bool _isFloor = false;
        private float _timeShoot;

        private Rigidbody _player;
        private Vector3 _moveDirection;

        [SerializeField] private Transform _startBullet;
        [SerializeField] private Destroy.Destroy _bullet;
        [SerializeField] private Transform _startMine;
        [SerializeField] private GameObject _mine;

        [SerializeField] private int _health = 5;
        [SerializeField] private int _maxHealth = 7;

        [SerializeField] private float _moveSpeed = 1.0f;
        [SerializeField] private float _running = 3.0f;
        [SerializeField] private float _shootDelay = 1.0f;
        [SerializeField] private float _forceJump = 6.0f;
        [SerializeField] private float _bulletForce = 5.0f;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _player = GetComponent<Rigidbody>();
            transform.position += transform.up;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Move(_running);
            }
            else
            {
                Move(_moveSpeed);
            }

            _timeShoot += Time.deltaTime;
            Fire();
            DropMine();

            if (Input.GetKeyDown(KeyCode.Space) && _isFloor)
            {
                _player.AddForce(Vector3.up * _forceJump, ForceMode.Impulse);
            }

        }

        void OnTriggerStay(Collider col)
        {
            if (col.tag == "Floor") _isFloor = true;
        }

        void OnTriggerExit(Collider col)
        {
            if (col.tag == "Floor") _isFloor = false;
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

        public void Heal(int heal)
        {
            print("Eeeee: " + heal);

            _health += heal; ;

            if (_health >= _maxHealth)
            {
                _health = _maxHealth;
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        private void Move(float _speed)
        {
            _moveDirection.x = Input.GetAxis("Horizontal");
            _moveDirection.z = Input.GetAxis("Vertical");
            transform.position += _moveDirection * _speed * Time.deltaTime;
            if (_moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(_moveDirection);
            }
        }

        private void Fire()
        {
            if (Input.GetButtonDown("Fire1") && (_shootDelay < _timeShoot))
            {
                _timeShoot = 0;
                Destroy.Destroy bullet = Instantiate(_bullet, _startBullet.position, _startBullet.rotation);
                bullet.Launch(_bulletForce);
            }
        }

        private void DropMine()
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Instantiate(_mine, _startMine.position, _startMine.rotation);
            }
        }

        #endregion
    }
}
