using UnityEngine;

public class Destroy : MonoBehaviour
{
    #region Fields
     
    [SerializeField] private float _lifeTime = 2.0f;
    [SerializeField] private float _moveSpeed = 2.0f;
    [SerializeField] private int _damage = 1;
     
    #endregion
 
     
    #region UnityMethods
     
    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
     
    private void Update()
    {
        transform.position +=  _moveSpeed*transform.up*Time.deltaTime;
    }
     
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
