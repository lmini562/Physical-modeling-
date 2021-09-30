using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Two : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private float _nu; //частота
    [SerializeField] private float _R; //радиус
    private Vector3 _distance;
    private float _angle, _time = 0f, _path, _rev, _angleSumm;

    // Start is called before the first frame update
    void Start()
    {
        _distance = new Vector3(_R, 0, _R);
        transform.position = _object.transform.position + _distance;
        InvokeRepeating("Output", 0f, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _time += Time.deltaTime;
        _angle = _nu * 360;
        _rev += Time.deltaTime * _nu;
        _path = 2 * Mathf.PI * _R * _rev;
        transform.RotateAround(_object.transform.position, Vector3.up, _angle * Time.deltaTime);
    }

    private void Output()
    {
        _angleSumm += _angle;
        Debug.Log("t = " + (int)_time + ", path = " + _path + ", Rotation angle = " + _angleSumm);
    }
}
