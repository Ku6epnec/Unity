using UnityEngine;


namespace Spawn
{
    public class Spawner : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _ghostWalker;

        #endregion


        #region UnityMethods

        private void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.CompareTag("Player"))
            {
                Instantiate(_ghostWalker, transform.position, transform.rotation);
                print($"Enter {coll.name}");
                Destroy(gameObject);
            }
        }

        #endregion
    }
}
