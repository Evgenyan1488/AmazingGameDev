using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bspeed;
    public float bdistance;
    public float lifetime;

    public int dmg;
    public LayerMask whatisSolid;


    void Start()
    {
        
    }

    // Update is called once per frame
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


    }
}
