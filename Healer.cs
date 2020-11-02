using UnityEngine;

public class Healer : MonoBehaviour
{
    #region Fields
     
    [SerializeField] private int _heal = 5;

    #endregion


    #region UnityMethods
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<FirstScript>();
            player.Heal(_heal);
            Destroy(gameObject);
        }
    }

    #endregion
}
