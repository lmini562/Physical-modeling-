using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Two : MonoBehaviour
{
    [SerializeField] private float _t1, _t2, _t3, _A, _B, _C, _D;
    private float _time, _pX, _pZ, _path, _aX = 0, _aY = 0, _VZ, _VX, _V, _a; //ускорение aX и aY по осям, VZ VX скорость, а ускорение
    private bool _f1 = true, _f2 = true, _f3 = true; //флаги
    private Rigidbody _rigidbody;
    private Vector3 _move;
    private Vector3 _Distanse, _Speed, _Acceleration; //итоговы знаычения скорости, дистанции и ускорения

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        _move = new Vector3(-_VX, 0, _VZ);
        _VX += _aY * Time.deltaTime;
        _VZ += _aX * Time.deltaTime;

        if (!_f1)
        {
            _aX = _A + _B * (_time - _t1);
            _aY = _C + _D * (_time - _t1);
        }

        _rigidbody.position += _move * Time.deltaTime;
        _pX += Time.deltaTime * Mathf.Abs(_VX);
        _pZ += Time.deltaTime * Mathf.Abs(_VZ);
        _Distanse = new Vector3(_pX, 0, _pZ);
        _path = _Distanse.magnitude;

        _Speed = new Vector3(_VX, 0, _VZ);
        _V = _Speed.magnitude;

        _Acceleration = new Vector3(_aY, 0, _aX);
        _a = _Acceleration.magnitude;

        if((int)_time == _t1 && _f1)
        {
            _f1 = false;
        }

        //Вывод на консоль с общим путем
        /*if ((int)_time == _t2 && _f2)
        {
            Debug.Log("time = " + (int)_time + ", path = " + _path);
            _f2 = false;
        }*/

        //Вывод на консоль с пройденным путем по OX и OZ 
        if ((int)_time == _t2 && _f2)
        {
            Debug.Log("time = " + (int)_time + ", pathX = " + _pX + ", pathZ = " + _pZ);
            _f2 = false;
        }

        if ((int)_time == _t3 && _f3)
        {
            Debug.Log("speed = " + _V + "acceleration = " + _a);
            _f3 = false;
        }
    }
}
