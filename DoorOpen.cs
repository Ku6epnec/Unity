using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    #region Fields
     
    [SerializeField] private GameObject _door;

    #endregion
     

    #region UnityMethods

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            _door.transform.position = transform.position; 
            _door.transform.rotation = transform.rotation;
            Destroy(gameObject);
            print($"Enter {coll.name}");
        }
    }

    #endregion
}
