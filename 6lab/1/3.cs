using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3 : MonoBehaviour
{
    [SerializeField] private float S1, S2, speed11, speed22, m1, m2;
    public Rigidbody obj1, obj2;
    private bool f = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 10f);
        obj1.mass = m1;
        obj2.mass = m2;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!f)
        {
            obj1.velocity = new Vector3(0, 0, -S1);
            obj2.velocity = new Vector3(0, 0, -S2);
        }
        else
        {
            speed11 = (2 * m2 * S2 + S1 * (m1 - m2)) / (m2 + m1);
            speed22 = (2 * m1 * S1 + S2 * (m1 - m2)) / (m1 + m2);

            obj1.velocity = new Vector3(0, 0, -speed11);
            obj2.velocity = new Vector3(0, 0, -speed22);
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        f = true;
    }
}
