using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject shovel;
    public GameObject rifle;
    public void shovelSpawner()
    {
        float x = Random.Range(-11f, 26f);
        float y = Random.Range(-13f, 12f);
        Vector3 vector3 = new Vector3(x, y, 0);
        Instantiate(shovel,vector3,Quaternion.identity);
    }
    public void rifleSpawner()
    {
        float x = Random.Range(-11f, 26f);
        float y = Random.Range(-13f, 26f);
        Vector3 vector3 =new Vector3(x,y,0);
        Instantiate(rifle,vector3,Quaternion.identity);
    }
    void Start()
    {
        InvokeRepeating("shovelSpawner", 0f, 15f);
        InvokeRepeating("rifleSpawner",0f,30f);
    }


    void Update()
    {
        
    }
}
