using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public float bspeed;
    public float bdistance;
    public float lifetime;

    public int dmg;
    public LayerMask whatisSolid;

<<<<<<< Updated upstream
    public GameObject bullet;
    public Transform shotPoint;
    
=======
    public Gun(float bspeed, float bdistance, float lifetime, int dmg)
    {
        this.bspeed = bspeed;
        this.bdistance = bdistance;
        this.lifetime = lifetime;
        this.dmg = dmg;
    }
>>>>>>> Stashed changes

    void Start()
    {
        
    }


    void Update()
    {
<<<<<<< Updated upstream
        Vector3 dif = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (Input.GetMouseButton(0))
        {
            Instantiate(bullet, shotPoint.position, transform.rotation);
        }
=======
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, bdistance, whatisSolid);
        if (hitinfo.collider != null)
        {
            if(hitinfo.collider.CompareTag("Enemy"))
            {
                hitinfo.collider.GetComponent<Enemy>().GetDamage(dmg);
            }
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * bspeed * Time.deltaTime);
        StartCoroutine(LifeTimeDestruction());
    }

    private IEnumerator LifeTimeDestruction()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
>>>>>>> Stashed changes
    }
}
