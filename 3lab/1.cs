using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One : MonoBehaviour
{
    [SerializeField] private float _t1, _t2, _t3, _A, _B;
    private float _time, _path, _a = 0, _V; //а - ускорение, V - скорость
    private bool _f1 = true, _f2 = true, _f3 = true; //флаги
    private Rigidbody _rigidbody;
    private Vector3 _move;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _time += Time.deltaTime;
        _move = new Vector3(0, 0, _V);
        _V += _a * Time.deltaTime;

        if(!_f1)
        {
            _a = _A + _B * (_time - _t1);
        }

        _rigidbody.position = _rigidbody.position + _move * Time.deltaTime;
        _path += Time.deltaTime * Mathf.Abs(_V);

        if((int)_time == _t1 && _f1)
        {
            _f1 = false;
        }

        if((int)_time == _t2 && _f2)
        {
            Debug.Log("time = " + (int)_time + ", path = " + _path);
            _f2 = false;
        }

        if((int)_time == _t3 && _f3)
        {
            Debug.Log("V = " + _V + ", a = " + _a);
            _f3 = false;
        }
    }
}
