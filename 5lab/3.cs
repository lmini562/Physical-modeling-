using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3 : MonoBehaviour
{
    [SerializeField] private float _h; //высота
    [SerializeField] private float _a; //ускорение
    [SerializeField] private float _an; //угол
    [SerializeField] private float _t; //время

    private float _time;
    private float _x, _y;
    private float _path; //путь
    private float _s, _s0; //скорость, начальная скорость
    private bool _f1 = true, _f2 = true;

    void Start()
    {
        transform.position = new Vector3(0, _h, 0);
        _s0 = _a;
    }

    void FixedUpdate()
    {
        _time += Time.deltaTime;
        if (!_f1)
        {
            _path += _s * Time.deltaTime;
            _s += _a * Time.deltaTime;
            _x = _s0 * Mathf.Cos(_an * Mathf.PI / 180) * (_time - _t) + _a * (_time - _t) * (_time - _t) / 2;
            _y = _h + _s0 * Mathf.Sin(_an * Mathf.PI / 180) * (_time - _t) - 9.8f * (_time - _t) * (_time - _t) / 2;
            transform.position = new Vector3(_x, _y, 0);
            if (transform.position.y <= 0)
            {
                _f2 = false;
                transform.position = new Vector3(_x, 0, 0);
            }
        }
        if ((int)_time == _t)
            _f1 = false;
        if (!_f1 && _f2)
            Debug.Log($"Time = {(_time - _t)}  Speed = {_path / (_time - _t)}  Speed = {_s}  Lenght = {_x}  Path = {_path}");
    }
}
