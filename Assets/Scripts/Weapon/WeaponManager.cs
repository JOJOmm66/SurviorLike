using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager weaponManager;
    [Header("冲锋枪参数")]
    public GameObject currentGun=null;
    public GameObject rifleBullet;
    public Rifle rifle;
    public Text BulletCountText;
    [Header("铲子旋转参数")]
    public int radius;
    public int rotateShovelSpeed;
    //铲子列表
    private List<GameObject> shovels = new List<GameObject>();
    //铲子不断旋转的点位设置
    public Vector2 SetShovelRotate(int radius, int rotateShovelSpeed, int index, int totalCount)
    {
        float angle;
        Vector2 shovelRotatePoint;
        angle = Time.time * rotateShovelSpeed * Mathf.Deg2Rad + index * 2 * Mathf.PI / totalCount;
        float x = this.transform.position.x + Mathf.Cos(angle) * radius;
        float y = this.transform.position.y + Mathf.Sin(angle) * radius;
        return shovelRotatePoint = new Vector2(x, y);
    }
    //增加铲子
    public void addShovel(GameObject newAddShovel)
    {
        shovels.Add(newAddShovel);
    }
    //铲子围绕玩家旋转
    public void rotateShovel()
    {
        //铲子列表旋转
        for (int i = 0; i < shovels.Count; i++)
        {
            //通过不断的改变位置实现铲子旋转
            shovels[i].transform.position = SetShovelRotate(radius, rotateShovelSpeed, i, shovels.Count);
            // 让铲子指向玩家
            Vector3 dirToPlayer = shovels[i].transform.position - transform.position;
            float lookAngle = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg;
            shovels[i].transform.rotation = Quaternion.Euler(0, 0, lookAngle);
        }
    }
    //枪跟随玩家
    public void playerPickRifle()
    {
        if (currentGun != null)
        {
            currentGun.transform.position = transform.position + new Vector3(0.0743f, -0.148f, 0f);
            //枪跟随鼠标朝向
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            Vector3 dir = (mousePos - transform.position).normalized;
            SpriteRenderer spriteRenderer = currentGun.GetComponent<SpriteRenderer>();
            if (dir.x >= 0)
            {
                spriteRenderer.flipY = false;
            }
            if (dir.x < 0)
            {
                spriteRenderer.flipY = true;
            }
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            currentGun.transform.rotation = Quaternion.Euler(0, 0, angle);
            rifleFire(angle);    
        }
    }
    public void rifleFire(float angle)
    {
        if (Input.GetMouseButtonDown(0)&&rifle.currentBulletCount>0)
        {
            Instantiate(rifleBullet,currentGun.transform.Find("FirePoint").position, Quaternion.Euler(0,0,angle-90));
            rifle.currentBulletCount-=1;
            BulletCountText.text = string.Format("/{0}", rifle.currentBulletCount);
        }
    }
    private void Awake()
    {
        weaponManager = this;
    }
    void Start()
    {

    }
    void Update()
    {
        rotateShovel();
        playerPickRifle();
    }
}
