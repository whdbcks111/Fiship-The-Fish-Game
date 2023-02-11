using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    [SerializeField] float mSpeed, currentVelocity, MaxVelocity; [Space]
    [SerializeField] float LimitLength;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = rigid.velocity * 0.99f;

        currentVelocity = rigid.velocity.x;

        CheckLimit();

        if (Input.GetKey(KeyCode.LeftArrow))
            MoveHorizontal(false);
        if (Input.GetKey(KeyCode.RightArrow))
            MoveHorizontal(true);
    }
    public void MoveHorizontal(bool isRight)
    {
        print("move horizontal");

        int I = 0;
        if (isRight)
            I = 1;
        else
            I = -1;


        if (Mathf.Abs(currentVelocity) < MaxVelocity)
        {
            if (I == 1)
                currentVelocity += mSpeed;
            else
                currentVelocity -= mSpeed;
        }
        else
            currentVelocity = I * MaxVelocity;

        rigid.velocity = new Vector2(currentVelocity, 0);

    }
    public void CheckLimit()
    {
        if (transform.position.x >= LimitLength)
        {
            rigid.velocity = Vector2.zero;
            transform.position = new Vector2(LimitLength, transform.position.y);
        }
        else if (transform.position.x <= -LimitLength)
        {
            rigid.velocity = Vector2.zero;
            transform.position = new Vector2(-LimitLength, transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //郴备档 包访 贸府
    }
}
