using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMine : MonoBehaviour
{
    #region Fields 

    [SerializeField] private int _damage = 3;

    #endregion


    #region UnityMethods
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<Enemy>();
            enemy.Hurt(_damage);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Tower"))
        {
            var enemy = other.GetComponent<Tower>();
            enemy.Hurt(_damage);
            Destroy(gameObject);
        }
    }

    #endregion
}
