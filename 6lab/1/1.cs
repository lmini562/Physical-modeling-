using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    public Rigidbody obj1, obj2;
    private bool f = false;
    [SerializeField] private float S1, S2; //скорости
    [SerializeField] private float m1, m2; //массы

    // Start is called before the first frame update
    void Start()
    {
        obj1.mass = m1;
        obj2.mass = m2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!f)
        {
            obj1.velocity = new Vector3(0, 0, S1);
        }
        else
        {
            obj1.velocity = new Vector3(0, 0, S1 * (m1 - m2) / (m1 + m2));
            obj2.velocity = new Vector3(0, 0, 2 * m1 * S1 / (m1 + m2));
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        f = true;
    }
}
