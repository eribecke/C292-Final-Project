using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followJeffery : MonoBehaviour
{
    [SerializeField] GameObject Jeffery;
    void LateUpdate()
    {
        transform.position = Jeffery.transform.position + new Vector3(7f, 0f, 0f);
    }
}
