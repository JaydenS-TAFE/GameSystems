using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowardsMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 _target;

    private void Start()
    {
        _target = transform.position + new Vector3(0f, 0f, 98f);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, speed * Time.deltaTime);
    }
}
