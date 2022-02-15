using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float offset = -90f;

    public GameObject bullet;
    public Transform shotPoint;
    

    void Start()
    {
        
    }



    void Update()
    {
        Vector3 dif = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (Input.GetMouseButton(0))
        {
            Instantiate(bullet, shotPoint.position, transform.rotation);
        }
    }
}
