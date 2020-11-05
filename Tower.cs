using UnityEngine;


namespace TowerDescription
{
    public class Tower : MonoBehaviour
    {
        #region Fields
         
        private float _timeShoot;
        private Transform _target;
        private float _startOffset = 0.5f;
        private bool _prepare = false;
        private GameObject _player;
        private GameObject _startfire;

        [SerializeField] private GameObject _fire;
        [SerializeField] private float _shootDelay = 2;

        [SerializeField] private int _health = 5;
        [SerializeField] private float _speedRotation = 1.0f;

        [SerializeField] private float _distanceVision = 1.0f;
        [SerializeField] private LayerMask _mask;

        #endregion

         
        #region UnityMethods

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _startfire = GameObject.FindGameObjectWithTag("StartFire");
        }

        private void Update()
        {
            _timeShoot += Time.deltaTime;

            _target = _player.transform;

            var color = Color.red;
            RaycastHit hit;

            var startRaycasstPosition = CalculateOffSet(transform.position);
            var directionToPlayer = CalculateOffSet(_target.position) - startRaycasstPosition;

            var rayCast = Physics.Raycast(startRaycasstPosition, directionToPlayer, out hit, _distanceVision, _mask);
            _prepare = false;

            if (rayCast)
            {
                print(hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    color = Color.green;
                    _prepare = true;
                    print(hit.collider.gameObject.tag);
                }
            }

            var _direction = directionToPlayer.normalized * _distanceVision;
            Debug.DrawRay(transform.position, _direction, color);

            if (_shootDelay < _timeShoot)
            {
                _timeShoot = 0;
                if (_prepare)
                {
                    Instantiate(_fire, _startfire.transform.position, _startfire.transform.rotation);
                }
            }

            transform.rotation = Quaternion.LookRotation(_direction);
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
        }

        private Vector3 CalculateOffSet(Vector3 position)
        {
            position.y += _startOffset;
            return position;
        }

        #endregion
    }
}
