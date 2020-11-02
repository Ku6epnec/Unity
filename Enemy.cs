using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Fields 
     
    [SerializeField] private int _health = 3;
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _speedRotation = 1;
    [SerializeField] private int _damage = 2;
    [SerializeField] private float _hitDelay = 2;
    [SerializeField] private GameObject _sounder;

    #endregion


    #region Fields
     
    private float _timeHit;
    private Transform _target;

    #endregion


    #region ClassLifeCycles
     
    public void Hurt(int damage)
    {
        print("Ouch: " +damage) ;

        _health -= damage; ;

        if (_health <= 0)
        {
            Die();
        }
    }
     
    private void Die()
    {
        Destroy(gameObject);
        Instantiate(_sounder, transform.position, transform.rotation);
    }

    #endregion


    #region UnityMethods
     
    void Update()
    {
        _timeHit += Time.deltaTime;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _target = player.transform;
        Vector3 targetDir = _target.position - transform.position;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir,
        _speedRotation * Time.deltaTime, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);

        transform.rotation = Quaternion.LookRotation(newDir);

        transform.position += _moveSpeed * transform.forward * Time.deltaTime;
    }
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && (_hitDelay < _timeHit))
        {
            var player = other.GetComponent<FirstScript>();
            player.Hurt(_damage);
        }
    }
     
    #endregion
}
