using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onefourONE : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _move;
    [SerializeField] private float _S;
    private float _t = 0.0f, _dist;
    private float _distX, _distZ; //разделяем x и z
    private Vector3 _Distanse;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("Outout", 0f, 2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _t += Time.fixedDeltaTime;
        _move = new Vector3(-1f, 0, 1); //2 координаты
        _rigidbody.position = _rigidbody.position + _move * _S * Time.deltaTime;
        _distX += Time.deltaTime * Mathf.Abs(_S) * Mathf.Abs(_move.x);
        _distZ += Time.deltaTime * Mathf.Abs(_S) * Mathf.Abs(_move.z);
        _Distanse = new Vector3(_distX, 0, _distZ);
        _dist = _Distanse.magnitude; //объект движется только по x и z, при этом S равно корню суммы квадратов расстояний по x и z
    }

    private void Output()
    {
        Debug.Log("Object V = " + _S + ", t = " + (int)_t + ", S = " + Mathf.Round(_dist) + ", coordinetes = " + transform.position);
    }

}
