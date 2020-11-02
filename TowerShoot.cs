using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    #region PrivateData
     
    private float _timeShoot;
     
    #endregion

     
    #region Fields
    [SerializeField] private GameObject _fire;
    [SerializeField] private float _shootDelay = 2;
     
    #endregion

     
    #region UnityMethods
     
    private void OnTriggerStay(Collider coll)
    {
        _timeShoot += Time.deltaTime;
        if (_shootDelay < _timeShoot)
        {
            _timeShoot = 0;
            if (coll.gameObject.CompareTag("Player"))
            {
                //Destroy(gameObject);
                Instantiate(_fire, transform.position, transform.rotation);
            }
        }
    }
     
    #endregion
}
