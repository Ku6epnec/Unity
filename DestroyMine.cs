using UnityEngine;


namespace DestroyMine
{
    public class DestroyMine : MonoBehaviour
    {
        #region Fields 

        private float _startOffset = 0.5f;
        private Rigidbody _mine;

        [SerializeField] private int _damage = 3;
        [SerializeField] private float _explosionForce = 100.0f;
        [SerializeField] private float _explosionRadius = 3.0f;

        #endregion


        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            var startRaycasstPosition = CalculateOffSet(transform.position);

            if (other.gameObject.CompareTag("Enemy"))
            {
                Vector3 explosionPos = transform.position;
                Collider[] colliders = Physics.OverlapSphere(explosionPos, _explosionRadius);

                foreach (Collider hit in colliders)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null)
                        rb.AddExplosionForce(_explosionForce, explosionPos, _explosionRadius, 3.0F);
                }

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

        private Vector3 CalculateOffSet(Vector3 position)
        {
            position.y += _startOffset;
            return position;
        }
    }
}