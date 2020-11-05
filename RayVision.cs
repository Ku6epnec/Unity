﻿using UnityEngine;


namespace RayVision
{
    public class RayVision : MonoBehaviour
    {

        #region Fields
         
        [SerializeField] private LayerMask _mask;
        [SerializeField] private float _speedRotation = 1.0f;
        [SerializeField] private float _distanceVision = 5.0f;

        private Transform _target;
        private float _startOffset = 0.5f;
        private GameObject _player;

        #endregion

         
        #region UnityMethods
         
        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        void FixedUpdate()
        {
            _target = _player.transform;

            var color = Color.red;
            RaycastHit hit;

            var startRaycasstPosition = CalculateOffSet(transform.position);
            var directionToPlayer = CalculateOffSet(_target.position) - startRaycasstPosition;

            var rayCast = Physics.Raycast(startRaycasstPosition, directionToPlayer, out hit, _distanceVision, _mask);

            if (rayCast)
            {
                print(hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    color = Color.green;
                    print(hit.collider.gameObject.tag);
                }
            }

            var _direction = directionToPlayer.normalized * _distanceVision;
            Debug.DrawRay(startRaycasstPosition, _direction, color);
        }
        #endregion


        #region Methods 
         
        private Vector3 CalculateOffSet(Vector3 position)
        {
            position.y += _startOffset;
            return position;
        }
         
        #endregion
    }
}