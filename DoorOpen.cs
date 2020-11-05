using UnityEngine;


namespace Door
{
    public class DoorOpen : MonoBehaviour
    {
        #region Fields
         
        private float _timeOpen;

        [SerializeField] private GameObject _door;
        [SerializeField] private GameObject _sounder;

        [SerializeField] private float _openDelay = 1.0f;
         
        #endregion


        #region UnityMethods

        private void OnTriggerStay(Collider coll)
        {
            if (coll.gameObject.CompareTag("Player"))
            {
                _timeOpen += Time.deltaTime;
                Instantiate(_sounder, transform.position, transform.rotation);

                if (_timeOpen >= _openDelay)
                {
                    _door.transform.position = transform.position;
                    _door.transform.rotation = transform.rotation;

                    Destroy(gameObject);
                }
            }
        }

        #endregion
    }
}