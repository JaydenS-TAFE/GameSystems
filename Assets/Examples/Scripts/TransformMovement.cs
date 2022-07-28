using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMovement : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
