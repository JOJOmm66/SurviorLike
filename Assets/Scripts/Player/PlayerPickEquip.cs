using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickEquip : MonoBehaviour
{
    public void pickEquip(GameObject equip)
    {
        if (equip.CompareTag("Weapon"))
        {
            //拾取物品为铲子
            Shovel shovel = equip.GetComponent<Shovel>();
            if (shovel != null)
            {
                shovel.isShovelRotate = true;
                WeaponManager.weaponManager.addShovel(equip);
            }
            //拾取物品为冲锋枪
            Rifle rifle = equip.GetComponent<Rifle>();
            if (rifle != null)
            {
                WeaponManager.weaponManager.currentGun = equip;
                WeaponManager.weaponManager.rifle = equip.GetComponent<Rifle>();
            }
        }
    }
    void Update()
    {
        
    }
}
