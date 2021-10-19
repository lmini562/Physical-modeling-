using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Task3Lab4 : MonoBehaviour
{
    [SerializeField] private float _h, _v, _t, _radius, _A, _B;
    private float _time, _dist, _frequency, _quantity, _a, _alpha = 0;
    private float _x, _y, _z;
    private Vector3 _direction;
    private bool _f1;
    public float GetRadius()
    {
        return _radius;
    }
    void Start()
    {
        transform.position = new Vector3(_radius, 0, 0);
        InvokeRepeating("Output", 0f, 1f);
    }
    void FixedUpdate()
    {
        _time += Time.deltaTime;
        if (_f1)
        {
            _frequency = _v / (2 * Mathf.PI * _radius);
            _a = _A + _B * (_time - _t);
            _v += _a * Time.deltaTime;
            _x = _radius * Mathf.Cos(_alpha * Mathf.PI / 180);
            _y = _alpha * _h / 360;
            _z = _radius * Mathf.Sin(_alpha * Mathf.PI / 180);
            _direction = new Vector3(_x, _y, _z);
            transform.position = _direction;
            _quantity += _frequency * Time.deltaTime;
            _alpha = 360 * _quantity;
            _dist += _v * Time.deltaTime;
        }
        if ((int)_time == _t && !_f1)
            _f1 = true;
    }
    private void Output()
    {
        Debug.Log("Time = " + (int)_time + ", distance = " + _dist + ", coordinates = " + _direction + ", a = " + _a);
    }
}
