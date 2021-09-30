using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class onetwo : MonoBehaviour
{
 private Rigidbody _rigidbody;
 private Vector3 _move;
 [SerializeField] private float _S;
 private float _T = 0.0f, _dist = 0.0f;
 // Start is called before the first frame update
 void Start()
 {
 _rigidbody = GetComponent<Rigidbody>();
 InvokeRepeating("Output", 0f, 2f);
 }
 // Update is called once per frame
 void FixedUpdate()
 {
 _move = new Vector3(0, 0, 1);
 _rigidbody.position = _rigidbody.position + _move * _S * Time.deltaTime;
 _dist += Time.deltaTime * Mathf.Abs(_S);
 _T += Time.fixedDeltaTime;
 }
 private void Output()
 {
 Debug.Log("Object S = " + _S + ", T = " + (int)_T + ", Dist = " + Mathf.Round(_dist) 
+ ", coordinates = " + transform.position);
 }
}
