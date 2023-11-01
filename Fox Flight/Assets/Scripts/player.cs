using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer Jeffery;
    [SerializeField] float launchForce;
    [SerializeField] float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Jeffery = GetComponent<SpriteRenderer>();
        rb.AddForce(new Vector3 (1,.3f,0).normalized*launchForce, ForceMode2D.Impulse);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float currentAngle = transform.rotation.eulerAngles.z;
        Debug.Log(currentAngle);
        if (currentAngle == 0)
        {
            rb.AddForce(new Vector3(0, 1, 0).normalized * (3 * rb.mass), ForceMode2D.Force);
        }
        else if (currentAngle <= 90)
        {
            if (currentAngle < 45)
            {
                rb.AddForce(new Vector3(0, 1, 0).normalized * ((currentAngle / 5 + 3) * rb.mass), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector3(0, 1, 0).normalized * (Mathf.Abs(currentAngle/5-18) * rb.mass), ForceMode2D.Force);
            }
        }
        else
        {
            rb.AddForce(new Vector3(0, 1, 0).normalized * (1 * rb.mass), ForceMode2D.Force);
            rb.AddForce(new Vector3(0, -1, 0).normalized * (5 * rb.mass), ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (currentAngle <= 90 || currentAngle >= 270)
            {
                transform.Rotate(-Vector3.forward * rotateSpeed * Time.deltaTime);
            }
            else
            {
                
                if(currentAngle>90 && currentAngle < 95)
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                }
                if (currentAngle < 270 && currentAngle > 265)
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, 270f);
                }
            }
            
            

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (currentAngle <= 90 || currentAngle >= 270)
            {
                transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
            }
            else
            {
                if (currentAngle > 90 && currentAngle < 95)
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                }
                if (currentAngle < 270 && currentAngle > 265)
                {
                    transform.rotation = Quaternion.Euler(0f, 0f, 270f);
                }
            }


        }
    }
}
