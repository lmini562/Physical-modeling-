using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private float _nu; //частота
    [SerializeField] private float _R; //радиус
    private float _angle, _time = 0f, _rev, _angularVelocity; //угол, время, обороты, угловая скорость
    private Vector3 _distance;

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
        _angularVelocity = Mathf.PI * 2 * _nu;
        transform.RotateAround(_object.transform.position, Vector3.up, _angle * Time.deltaTime);
        _rev += Time.deltaTime * _nu;
    }

    private void Output() //округляем до сотых
    {
        Debug.Log("t = " + (int)_time + ", nu = " + Mathf.Round(_nu * 100f) / 100f + ", Angular velocity = " + _angularVelocity);
    }
}
