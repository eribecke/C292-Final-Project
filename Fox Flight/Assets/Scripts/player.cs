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
        rb.AddForce(new Vector3 (1,1,0).normalized*launchForce, ForceMode2D.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
