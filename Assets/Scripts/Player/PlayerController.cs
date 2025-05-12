using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    Rigidbody2D rigid;
    Animator anim;
    float v;
    float h;
    bool isHorizonMove;

    Vector3 dirVec;
    GameObject scanObj;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        // animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
            anim.SetBool("isChange", false);
            
        // direction
        if(vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == 1)
            dirVec = Vector3.right;
        else if (hDown && h == -1)
            dirVec = Vector3.left;

        // Scan Object
        if(Input.GetButtonDown("Jump") && scanObj != null)
        {
            Debug.Log($"This is {scanObj.name}!");
        }
    }

    private void FixedUpdate()
    {
        // Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;

        // Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D ray = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if(ray.collider != null)
        {
            scanObj = ray.collider.gameObject;
        }
        else
            scanObj = null;
    }
}
