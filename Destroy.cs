using UnityEngine;


namespace Destroy
{
    public class Destroy : MonoBehaviour
    {
        #region Fields
        private Rigidbody _rigidBody;

        [SerializeField] private float _lifeTime = 2.0f;
        //[SerializeField] private float _moveSpeed = 2.0f;
        [SerializeField] private int _damage = 1;

        #endregion


        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                var enemy = other.GetComponent<EnemyDiscription.Enemy>();
                enemy.Hurt(_damage);
                Destroy(gameObject);
            }

            if (other.gameObject.CompareTag("Tower"))
            {
                var enemy = other.GetComponent<TowerDescription.Tower>();
                enemy.Hurt(_damage);
                Destroy(gameObject);
            }
        }

        #endregion


        #region Methods 

        public void Launch(float force)
        {
            Destroy(gameObject, _lifeTime);

            _rigidBody = GetComponent<Rigidbody>();

            Vector3 impulse = transform.up * _rigidBody.mass * force;
            _rigidBody.AddForce(impulse, ForceMode.Impulse);
        }

        #endregion
    }
}