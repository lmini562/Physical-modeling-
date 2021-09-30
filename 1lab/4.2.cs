using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onefourTWO : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _move;
    [SerializeField] private float _V, _a;
    private float _t = 0.0f, _dist;
    private float _distX, _distZ; //разделяем z и x
    private Vector3 _Dist;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("Output", 0f, 2f);
        InvokeRepeating("IncreaseForse", 0f, 2f); //ускорение каждые 2с
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _t += Time.fixedDeltaTime;
        _move = new Vector3(-1f, 0, 1);
        _rigidbody.position = _rigidbody.position + _move * _V * Time.deltaTime;
        _distX += Time.deltaTime * Mathf.Abs(_V) * Mathf.Abs(_move.x);
        _distZ += Time.deltaTime * Mathf.Abs(_V) * Mathf.Abs(_move.z);
        _Dist = new Vector3(_distX, 0, _distZ);
        _dist = _Dist.magnitude; //корень из суммы расстояний по z и x, y всегда 0
    }

    private void Output()
    {
        Debug.Log("Object V = " + _V + ", t = " + (int)_t + ", S = " + Mathf.Round(_dist) + ", coordinates = " + transform.position);
    }

    private void IncreaseForse() //прибавляем к скорости ускорение
    {
        _V += _a;
    }
}
