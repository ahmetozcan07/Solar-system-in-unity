using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    float G = 100f;
    GameObject[] spheres;

    
    void Start()
    {
        spheres = GameObject.FindGameObjectsWithTag("Sphere");

        //Velocity();
    }
    private void FixedUpdate()
    {
        SpaceGravity();
    }

    void SpaceGravity()
    {
        foreach(GameObject a in spheres)
        {
            foreach(GameObject b in spheres)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (G * (m1 * m2) / (r * r)));
                }
            }
        }
    }

    /*void Velocity()
    {
        foreach(GameObject a in spheres)
        {
            foreach (GameObject b in spheres)
            {
                if (!a.Equals(b))
                {
                    float m2 = b.GetComponent <Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.transform.LookAt(b.transform);

                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt(G * m2 / r) * 10;
                }
            }
        }
    }*/
}
