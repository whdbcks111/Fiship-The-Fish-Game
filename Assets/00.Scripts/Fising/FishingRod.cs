using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    [SerializeField] float mSpeed;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MoveHorizontal(bool isRight)
    {
        if (isRight)
            rigid.AddForce(new Vector2(mSpeed, 0));
        else
            rigid.AddForce(new Vector2(-mSpeed, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //郴备档 包访 贸府
    }
}
