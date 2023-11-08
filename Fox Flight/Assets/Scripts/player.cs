using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

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
        rb.AddForce(new Vector3(1, 1, 0).normalized * launchForce, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = Jeffery.transform.position;
        float currentAngle = transform.rotation.eulerAngles.z;
        Debug.Log("Y Speed " + rb.velocity.y);
        Debug.Log("X Speed " + rb.velocity.x);
        Debug.Log("Speed " + rb.velocity.magnitude);

        float speed = rb.velocity.magnitude;

        //plane is level
        if (currentAngle == 0 && speed > 3)
        {
            rb.AddForce(new Vector3(0, 1, 0).normalized * (3 * rb.mass), ForceMode2D.Force);
        }

        //plane is angled upward
        else if (currentAngle <= 90)
        {
            //lift will increase
            if (currentAngle < 45 && speed > Physics.gravity.y + rb.mass && position.y > -7.4)
            {
                rb.AddForce(new Vector3(0, -1, 0).normalized * ((currentAngle / 5 + speed / 12) * rb.mass), ForceMode2D.Force);
                rb.AddForce(new Vector3(0, 1, 0).normalized * ((currentAngle / 5 + speed / 2) * rb.mass), ForceMode2D.Force);
            }
            //lift will decrease 
            else if (speed > Physics.gravity.y + rb.mass && position.y > -7.4)
            {
                rb.AddForce(new Vector3(0, 1, 0).normalized * (Mathf.Abs(currentAngle / 5 - 18) * rb.mass), ForceMode2D.Force);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }

        //plane is angled downward
        //lift will decrease to 0 at 320, force behind will increase and add to speed
        else
        {
            if (speed > 5 && position.y > -7)
            {
                rb.AddForce(new Vector3(1, 0, 0).normalized * (Mathf.Abs(currentAngle / 20 - speed * (3 / 5)) * rb.mass), ForceMode2D.Force);
                rb.AddForce(new Vector3(0, -1, 0).normalized * (Mathf.Abs(currentAngle / 20 - speed * (4 / 9)) * rb.mass), ForceMode2D.Force);
                if (currentAngle > 320)
                {
                    rb.AddForce(new Vector3(0, 1, 0).normalized * (Mathf.Abs(currentAngle / 20 - speed * (1 / 9)) * rb.mass), ForceMode2D.Force);
                }
                else
                {
                    rb.AddForce(new Vector3(0, 1, 0).normalized, ForceMode2D.Force);

                }
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (currentAngle <= 90 || currentAngle >= 270)
            {
                transform.Rotate(-Vector3.forward * rotateSpeed * Time.deltaTime);
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //bounds for rotation
            if (currentAngle <= 90 || currentAngle >= 270)
            {
                transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
            }
            else
            {
                //if plane over-rotates reset angle so rotation can ensue 
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("powerup"))
        {

            
            Destroy(collision.gameObject);
            rb.AddForce(new Vector3(1, 0, 0).normalized * 10, ForceMode2D.Impulse);

        }
    }
}
