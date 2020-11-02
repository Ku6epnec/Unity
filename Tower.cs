using UnityEngine;

public class Tower : MonoBehaviour
{
    #region PrivateData
     
    private Transform _target;
     
    #endregion
     
     
    #region Fields
     
    [SerializeField] private int _health = 5;
    [SerializeField] private float _speedRotation = 1;
     
    #endregion
     

     
    #region ClassLifeCycles
     
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
     
    #endregion
     
     
    #region UnityMethods
     
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _target = player.transform;
        Vector3 targetDir = _target.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir,
        _speedRotation * Time.deltaTime, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
     
    #endregion
}
