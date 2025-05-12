using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    Rigidbody2D rigid;

    float v;
    float h;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(h, v) * speed;
    }
}
