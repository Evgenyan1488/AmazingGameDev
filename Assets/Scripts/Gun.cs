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

    public GameObject bullet;
    public Transform shotPoint;

    private float timebtwshots;
    public float atackspeed;
   
    public Gun(float bspeed, float bdistance, float lifetime, int dmg)
    {
        this.bspeed = bspeed;
        this.bdistance = bdistance;
        this.lifetime = lifetime;
        this.dmg = dmg;
    }


    void Start()
    {
        
    }


    void Update()
    {
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

    }
}
