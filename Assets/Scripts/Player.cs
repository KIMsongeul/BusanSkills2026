using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 2f;
    private float rotSpeed = 1.5f;

    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //감속
        float currentSpeed = moveSpeed;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = moveSpeed/2;
        }
        
        //전진
        if (Input.GetKey(KeyCode.W))
        {
            rigid.linearVelocity = transform.up * currentSpeed;
        }
        else
        {
            rigid.linearVelocity = Vector2.zero;
        }
        
        //회전
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0,0,rotSpeed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0,0,-rotSpeed));
        }
        
    }
}
