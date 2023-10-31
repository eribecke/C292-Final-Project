using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float launchForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3 (1,.6f,0).normalized*launchForce, ForceMode2D.Impulse);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody2D>();
        float currentAngle = transform.rotation.eulerAngles.z;
        if (currentAngle == 0)
        {
            rb.AddForce(new Vector3(0, 1, 0).normalized * (3 * rb.mass), ForceMode2D.Force);
        } 
    }
}
