using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 3f;
    private float attackCD = 0f;
    public GameObject Bullet;
    public GameObject ExplosionPrefab;
    public Sprite[] TankSprtie; // 上 右 下 左


    private SpriteRenderer sr;
    private Vector3 BulletAngle;

    private float ChangeDirVal;
    private float v = 0f;
    private float h = 0f;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(ChangeDirVal > 1)
        {
            int num = Random.Range(0, 8);
            if(num >= 5)
            {
                v = -1;
                h = 0;
            }
            else if( num == 0)
            {
                v = 1;
                h = 0;
            }
            else if(num > 0 && num <= 2)
            {
                h = -1;
                v = 0;
            }
            else if(num > 2 && num <= 4)
            {
                h = 1;
                v = 0;
            }
            ChangeDirVal = 0;
        }
        else
        {
            ChangeDirVal += Time.deltaTime;
        }

        transform.Translate(Vector3.right * h * speed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = TankSprtie[3];
            BulletAngle = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = TankSprtie[1];
            BulletAngle = new Vector3(0, 0, -90);
        }

        if (h != 0)
        {
            return;
        }

        transform.Translate(Vector3.up * v * speed * Time.fixedDeltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = TankSprtie[2];
            BulletAngle = new Vector3(0, 0, 180);
        }
        else if (v > 0)
        {
            sr.sprite = TankSprtie[0];
            BulletAngle = new Vector3(0, 0, 0);
        }
    }


    private void Attack()
    {
        if (attackCD < 1f)
        {
            attackCD += Time.deltaTime;
            return;
        }

        Instantiate(Bullet, transform.position, Quaternion.Euler(transform.eulerAngles + BulletAngle));
        attackCD = 0.0f;
    }

    private void Die()
    {
        playerManager.Instance.nScore += 1;
        // 爆炸特效
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);

        // 销毁自己
        Destroy(gameObject);
    }
}
