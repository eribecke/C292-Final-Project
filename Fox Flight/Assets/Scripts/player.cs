using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer Jeffery;
    [SerializeField] float launchForce;
    [SerializeField] float rotateSpeed;
    float timer = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        
       rb = GetComponent<Rigidbody2D>();
       Jeffery = GetComponent<SpriteRenderer>();
       
    }



    // Update is called once per frame
    private void Update()
    {
     
        if(timer>0) {timer -= Time.deltaTime; }
        
        
        if (timer < 0)
        {
            rb.AddForce(new Vector3(1, 0, 0).normalized * launchForce, ForceMode2D.Impulse);
            timer = 0;
        }
    }
    void FixedUpdate()
    {
        Vector3 position = Jeffery.transform.position;
        float currentAngle = transform.rotation.eulerAngles.z;
        Debug.Log("Y Speed " + rb.velocity.y);
        Debug.Log("X Speed " + rb.velocity.x);
        Debug.Log("Speed " + rb.velocity.magnitude);
        Debug.Log("Lift" + Vector2.up.normalized * (1.293f * Mathf.Pow(rb.velocity.magnitude, 2) / 2) * (0.5f));
        Debug.Log("Angle: " + currentAngle);

        float speed = rb.velocity.magnitude;
        float airDensity = 1.293f;
        float dragCo = 0.029f;
        float wingArea = .5f;
        //drag formula
        rb.AddForce(-rb.velocity.normalized * dragCo * airDensity * rb.velocity.sqrMagnitude * wingArea * 0.5f);
        //plane is level
        if (currentAngle == 0 && speed > 3)
        {
            //rb.AddForce(new Vector3(0, 1, 0).normalized * (3 * rb.mass), ForceMode2D.Force);
        }

        //plane is angled upward
        else if (currentAngle <= 90)
        {
            //lift will increase
            if (currentAngle < 45 && speed > Physics.gravity.y + rb.mass && position.y > -7.4  && rb.velocity.y < 25)
            {
                //rb.AddForce(new Vector3(0, -1, 0).normalized * ((currentAngle / 5 + speed / 12) * rb.mass), ForceMode2D.Force);
                //rb.AddForce(new Vector3(0, 1, 0).normalized * ((currentAngle / 5 + speed/2) * rb.mass), ForceMode2D.Force);

                //lift formula
                rb.AddRelativeForce(Vector2.up.normalized * (airDensity * Mathf.Pow(rb.velocity.magnitude, 2) / 2) * .04f);
            }
            //lift will decrease 
            else if (speed > Physics.gravity.y + rb.mass && position.y > -7.4)
            {
                //rb.AddForce(new Vector3(0, 1, 0).normalized * (Mathf.Abs(currentAngle / 5 - 18) * rb.mass), ForceMode2D.Force);
            }
            else
            {
                //rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }

        //plane is angled downward
        //lift will decrease to 0 at 320, force behind will increase and add to speed
        else
        {
            if (speed > 5 && position.y > -7)
            {
                rb.AddForce(new Vector3(1, 0, 0).normalized * (Mathf.Abs(currentAngle / 20 - speed * (2 / 5)) * rb.mass), ForceMode2D.Force);
                //rb.AddForce(new Vector3(0, -1, 0).normalized * (Mathf.Abs(currentAngle / 20 - speed * (1 / 3)) * rb.mass), ForceMode2D.Force);
                if (currentAngle > 320)
                {
                    //rb.AddForce(new Vector3(0, 1, 0).normalized * (Mathf.Abs(currentAngle / 20 - speed * (1 / 9)) * rb.mass), ForceMode2D.Force);
                }
                else
                {
                    //rb.AddForce(new Vector3(0, 1, 0).normalized, ForceMode2D.Force);

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
                //adding lift if player lifts up nose of plane
                if(currentAngle > 315)
                {
                    rb.AddRelativeForce(Vector2.up.normalized * (airDensity * Mathf.Pow(rb.velocity.magnitude, 2) / 2) * .04f);
                }
            }


        }

        if(speed == 0 && position.x > 0 && position.y < -7.4)
        {
            SceneManager.LoadScene(1);
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
