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
    private IEnumerator _eRecover;

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

        if (Input.GetKey(KeyCode.LeftArrow))
            MoveHorizontal(false);
        if (Input.GetKey(KeyCode.RightArrow))
            MoveHorizontal(true);


        var left = ScreenRect.leftTop.x;
        var right = ScreenRect.rightBottom.x;

        if (transform.position.x < left)
        {
            var pos = transform.position;
            pos.x = left;
            transform.position = pos;
            rigid.velocity = Vector2.zero;
        }

        if (transform.position.x > right)
        {
            var pos = transform.position;
            pos.x = right;
            transform.position = pos;
            rigid.velocity = Vector2.zero;
        }
    }
    public void MoveHorizontal(bool isRight)
    {

        var axis = 0;
        if (isRight)
            axis = 1;
        else
            axis = -1;


        if (Mathf.Abs(currentVelocity) < MaxVelocity)
            currentVelocity += mSpeed * axis;
        else
            currentVelocity = axis * MaxVelocity;

        rigid.velocity = new Vector2(currentVelocity, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //장애물
            if (FishingManager.instance.invulnerableTimer <= 0)
            {
                var damage = collision.GetComponent<ObjectInfo>().informationGet();
                GameManager.instance.RodDurability -= damage;

                if(damage >= GameManager.instance.MaxRodDurability)
                    SoundManager.instance.PlayAudio("Explode");
                else
                    SoundManager.instance.PlayAudio("gettrash");
            }
            VelLoad = background.Stop();

            if(_eRecover is not null) StopCoroutine(_eRecover);
            _eRecover = ERecover();
            StartCoroutine(_eRecover);

            FishingManager.instance.obstacleGenerator.Despawn(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Fish"))
        {
            //물고기
            var scoreAddition = Mathf.RoundToInt(
                collision.GetComponent<ObjectInfo>().informationGet()
                    * (1 + GameManager.instance.EnhanceLevel * 0.05f)
                );
            if (FishingManager.instance.doubleScoreTimer > 0) scoreAddition *= 2;
            scoreAddition = Mathf.RoundToInt(scoreAddition * (1 + FishingManager.instance.gameTime / 60 * 3));
            GameManager.instance.Score += scoreAddition;
            collision.gameObject.transform.SetParent(null);
            collision.gameObject.AddComponent<ObjectFollow>().target = transform;
            collision.gameObject.tag = "Untagged";
            StartCoroutine(ERemoveFish(collision.gameObject));

            SoundManager.instance.PlayAudio("getfish");
        }
        else if (collision.gameObject.CompareTag("Item"))
        {
            //아아템
            var item = collision.gameObject.GetComponent<Item>();
            if (item is not null) item.OnTrigger();
            FishingManager.instance.itemGenerator.Despawn(collision.gameObject);
        }
    }

    IEnumerator ERemoveFish(GameObject fishObj)
    {
        yield return new WaitForSeconds(3f);
        Destroy(fishObj);
    }

    IEnumerator ERecover()
    {
        yield return new WaitForSeconds(0.1f);
        background.ChangeSpeed(VelLoad * .1f);
        yield return new WaitForSeconds(0.2f);
        background.ChangeSpeed(VelLoad * .3f);
        yield return new WaitForSeconds(0.2f);
        background.ChangeSpeed(VelLoad * .5f);
    }
}
