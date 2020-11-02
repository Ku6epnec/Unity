using UnityEngine;

public class Following : MonoBehaviour
{
    #region PrivateData

    private Vector3 _offset;

    #endregion
     
     
    #region Fields

    [SerializeField] private GameObject _player;

    #endregion


    #region UnityMethods

    void Start()
    {
        _offset = transform.position - _player.transform.position;
    }

    void Update()
    {
        transform.position = _player.transform.position + _offset;
    }
     
    #endregion
}
