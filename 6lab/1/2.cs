using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2 : MonoBehaviour
{
    public Rigidbody obj1, obj2;

    [SerializeField] private float m1, m2, speed01, speed11, speed12;
    [SerializeField] private float A, B, G;
    private bool f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-0.75f, 0f, 5f);
        obj1.mass = m1;
        obj2.mass = m2;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!f)
        {
            obj1.velocity = new Vector3(0f, 0f, -5f);
        }
        else
        {
            speed11 = speed01 / Mathf.Sqrt(2);
            speed12 = speed11;
            A = Mathf.Asin(Mathf.Sin(90 * Mathf.Deg2Rad) * speed11 /
                               Mathf.Sqrt(speed11 * speed11 + speed12 * speed12)) * Mathf.Rad2Deg;
            B = 90 - A;
            G = A;
            obj1.velocity = new Vector3((-1f) * speed11, 0, speed11 * Mathf.Sin(B * Mathf.Deg2Rad * B) / Mathf.Sin(G * Mathf.Deg2Rad));
            obj2.velocity = new Vector3(speed12, 0, (-1f) * obj1.velocity.magnitude);
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        f = true;
    }
}
