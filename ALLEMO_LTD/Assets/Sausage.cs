using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sausage : MonoBehaviour
{
    Rigidbody _rb;
    Vector3 _startPoint;
    Vector3 _endPoint;
    Vector3 _jumpDirection;
    float _jumpPower;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Camera.main.transform.position = new Vector3(transform.position.x-7,1,-30);
        if(_startPoint != Vector3.zero)
        {
            _endPoint = Input.mousePosition;
        }
        if (Input.GetMouseButtonDown(0))
        {
            _startPoint = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _jumpDirection = (_startPoint - _endPoint).normalized;
            _jumpPower = Vector3.Distance(_startPoint,_endPoint);
            Debug.Log(_jumpPower);
            if(_jumpPower > 150)
            {
                _jumpPower = 150;
            }
            Debug.Log(_jumpPower);
            Jump(_jumpDirection*_jumpPower);
            _startPoint = Vector3.zero;
        }
        
    }
    void Jump(Vector3 _jumpVector)
    {
        _rb.AddForce(_jumpVector, ForceMode.Impulse);
    }
}