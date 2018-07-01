using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 3f;
    private float attackCD = 0f;
    public GameObject Bullet;
    public GameObject ExplosionPrefab;
    public Sprite[] TankSprtie; // 上 右 下 左
    public AudioClip AudioFire;


    private SpriteRenderer sr;
    private Vector3 BulletAngle = new Vector3(0,0,0);

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(attackCD > 0.4f)
        {
            Attack();
        }
        else
        {
            attackCD += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * speed * Time.deltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = TankSprtie[3];
            BulletAngle.Set(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = TankSprtie[1];
            BulletAngle.Set(0, 0, -90);
        }

        if ( h != 0)
        {
            return;
        }

        float v = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.up * v * speed * Time.deltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = TankSprtie[2];
            BulletAngle.Set(0, 0, 180);
        }
        else if (v > 0)
        {
            sr.sprite = TankSprtie[0];
            BulletAngle.Set(0, 0, 0);
        }
    }

    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, transform.position, Quaternion.Euler(transform.eulerAngles + BulletAngle));
            attackCD = 0.0f;
            AudioSource.PlayClipAtPoint(AudioFire, transform.position);
        }
    }

    private void Die()
    {
        playerManager.Instance.nLife -= 1;

        // 爆炸特效
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);

        // 销毁自己
        Destroy(gameObject);
    }
}
