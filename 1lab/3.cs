using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onethree : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _move;
    [SerializeField] private float _S, _a;
    private float _T = 0.0f, _dist = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("Output", 0f, 2f);
        InvokeRepeating("IncreaseForse", 2f, 2f); //ускорение каждые 2с
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _move = new Vector3(0, 0, 1);
        _rigidbody.position = _rigidbody.position + _move * _S * Time.deltaTime;
        _T += Time.fixedDeltaTime;
        _dist += Time.deltaTime * Mathf.Abs(_S);
    }

    private void Output()
    {
        Debug.Log("Object S = " + _S + ", t = " + (int)_T + ", dist = " + Mathf.Round(_dist) + ", Coordinates = " + transform.position);
    }

    private void IncreaseFofce() //прибавляем ускорение
    {
        _S += _a;
    }
}
