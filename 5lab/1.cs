using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1: MonoBehaviour
{
    [SerializeField] private float _v; //скорость
    [SerializeField] private float _h; //высота

    private float _x;
    private float _y;
    private float _t;
    private float _path; //путь
    private bool _f = true; //флаг

    void Start()
    {
        transform.position = new Vector3(0, _h, 0);
    }

    void FixedUpdate()
    {
        _t += Time.deltaTime;
        if (_f)
        {
            _path += _v * Time.deltaTime;
            _x = _v * _t;
            _y = _h - (9.8f * _t * _t / 2);
            transform.position = new Vector3(_x, _y, 0);
            //Debug.Log("Time = " + _t + "  Path = " + _path);
            Debug.Log($"Time = {_t} Path = {_path}", this);
        }
        if (transform.position.y <= 0)
            _f = false;
    }
}
