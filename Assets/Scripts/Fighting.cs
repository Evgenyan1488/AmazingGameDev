using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Анимконтроллер это тупо бог, его наследует всё оружие (ближнее и не очень)

public class Weapon : AnimController
{

}

public class Fighting : MonoBehaviour
{

    public float offset = -90f;

    public GameObject bullet;
    public Transform shotPoint;

    private float timebtwshots;
    public float atackspeed;

    void Start()
    {
        Gun pistol = new Gun(30f, 10f, 0.5f, 1);
        Weapon weapon = pistol;
    }



    void Update()
    {
        Vector3 dif = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (timebtwshots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                timebtwshots = atackspeed;
            }
        }
        else
        {
            timebtwshots -= Time.deltaTime;
        }
    }
    private void WeaponCheck()
    {

    }

}
