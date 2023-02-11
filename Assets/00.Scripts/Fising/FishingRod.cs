using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class FishingRod : MonoBehaviour
{
    [SerializeField] float mSpeed, currentVelocity, MaxVelocity; [Space]
    [SerializeField] float LimitLength; [Space]
    [SerializeField] float VelLoad;
    Rigidbody2D rigid;
    FishingBackground background;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        background = FindFirstObjectByType<FishingBackground>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = rigid.velocity * 0.997f;

        currentVelocity = rigid.velocity.x;

        CheckLimit();

        if (Input.GetKey(KeyCode.LeftArrow))
            MoveHorizontal(false);
        if (Input.GetKey(KeyCode.RightArrow))
            MoveHorizontal(true);
    }
    public void MoveHorizontal(bool isRight)
    {
        //'print("move horizontal");

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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //장애물
            GameManager.Instance.RodDurability -= collision.GetComponent<ObjectInfo>().informationGet();
            VelLoad = background.Stop();
            StartCoroutine(recover());

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Fish"))
        {
            //물고기
            GameManager.Instance.Score += collision.GetComponent<ObjectInfo>().informationGet();

            Destroy(collision.gameObject);
        }
    }
    IEnumerator recover()
    {
        yield return new WaitForSeconds(0.1f);
        background.ChangeSpeed(VelLoad * .1f);
        yield return new WaitForSeconds(0.2f);
        background.ChangeSpeed(VelLoad * .3f);
        yield return new WaitForSeconds(0.2f);
        background.ChangeSpeed(VelLoad * .5f);
    }
}
