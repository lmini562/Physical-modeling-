using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1Lab4 : MonoBehaviour
{
    [SerializeField] private float _h, _v, _t, _radius;
    private float _time, _dist, _nu, _n, _alpha = 0;
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
        _nu = _v / (2 * Mathf.PI * _radius);
        if (_f1)
        {
            _x = _radius * Mathf.Cos(_alpha * Mathf.PI / 180);
            _y = _alpha * _h / 360;
            _z = _radius * Mathf.Sin(_alpha * Mathf.PI / 180);
            _direction = new Vector3(_x, _y, _z);
            transform.position = _direction;
            _n += _nu * Time.deltaTime;
            _alpha = 360 * _n;
            _dist += _v * Time.deltaTime;
        }
        if ((int)_time == _t && !_f1)
            _f1 = true;
    }
    private void Output()
    {
        Debug.Log("Time = " + (int)_time + ", path = " + _dist);
    }
}
