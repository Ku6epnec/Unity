using UnityEngine;

public class Sounder : MonoBehaviour
{
    #region Fields
     
    [SerializeField] private float _lifeTime = 2.0f;

    #endregion


    #region UnityMethods
     
    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    #endregion
}
