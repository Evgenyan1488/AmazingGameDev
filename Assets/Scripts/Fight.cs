/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fight : AnimController
{
    public GameObject bullet;
    public Transform shotPoint;
    public Transform mytransform;
    public LayerMask enemy;
    public float attackrange;
    Weapon weapon;

    /*public Fight(float bspeed, float bdistance, float lifetime, int dmg)
    {
        this.bspeed = bspeed;
        this.bdistance = bdistance;
        this.lifetime = lifetime;
        this.dmg = dmg;
    }


    void Start()
    {

    }
}




public abstract class Weapon : AnimController
{
    public float atackspeed = 0.4f;
    public float rechargetime = 0.0f;

    public float timebtwshots;
    public float atackspeed = 0.4f;
    protected int dmg = 1;


    public Transform shotPoint;

    private float timebtwshots;

    public virtual void Attack()
    {

}

}


public class Gun : Weapon
{
    protected float bspeed = 5f;
    public float bdistance = 5f;
    protected float lifetime = 0.4f;

    //public LayerMask whatisSolid;
    public Transform mytransform;
    public GameObject bullet;
    public float timebtwshots = 0.1f;


    public Gun(float bspeed, float bdistance, float lifetime, int dmg, GameObject bullet, Transform shotpoint, Transform transform)
    {
        this.bspeed = bspeed;
        this.bdistance = bdistance;
        this.lifetime = lifetime;
        this.dmg = dmg;
        this.bullet = bullet;
        this.shotPoint = shotpoint;
        this.mytransform = transform;
    }


    public override void Attack()
    {
            if (timebtwshots <= 0)
            {
                isattacking = true;
                State = States.Pistol_shot;
                Instantiate(bullet, shotPoint.position, mytransform.rotation);
                timebtwshots = atackspeed;
            } 
        else
        {
            timebtwshots -= Time.deltaTime;
    }

}
}

public class Club : Weapon
{
    private bool isattacking;
    private bool isrecharged = true;

    private float attackrange;
    private float attacktime;
    private LayerMask enemy;
    private Transform mytransform;

    public Club(int dmg, float attackrange, float attacktime, LayerMask enemy, Transform mytransform)
    {
        this.dmg = dmg;
        this.attackrange = attackrange;
        this.attacktime = attacktime;
        this.enemy = enemy;
        this.mytransform = mytransform;
    }

    void Start()
    {

    }


    void Update()
    {

    }

    public override void Attack()
    {
        State = States.punch;
        if (isrecharged)
        {
            State = States.punch;
            isattacking = true;
            isrecharged = false;
            Debug.Log("atakuyu");
            //StartCoroutine(AttackAnimation());
            //StartCoroutine(AttackCooldown());
    }
    public void OnAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(mytransform.position, attackrange, enemy);

        for (int i = 0; i < colliders.Length; i++)
            colliders[i].GetComponent<Entity>().GetDamage(dmg);
    }

    private IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(0.4f);
        isattacking = false;
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        isrecharged = true;
    }

    public void OnAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(mytransform.position, attackrange, enemy);

        for (int i = 0; i < colliders.Length; i++)
            colliders[i].GetComponent<Entity>().GetDamage(dmg);
    }


}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fight : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;
    public Transform mytransform;


    //public LayerMask whatisSolid;
    Weapon weapon;

    /*public Fight(float bspeed, float bdistance, float lifetime, int dmg)
    {
        this.bspeed = bspeed;
        this.bdistance = bdistance;
        this.lifetime = lifetime;
        this.dmg = dmg;
    }*/
    private void Awake()
    {
        weapon = new Gun(5f, 5f, 0.4f, 3, bullet, shotPoint, mytransform);
        
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log(weapon.atackspeed);
            weapon.Attack();
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            weapon.atackspeed = 0.1f;
        }
    }

}




public abstract class Weapon : AnimController
{
    public float atackspeed = 0.4f;
    protected int dmg = 1;


    public Transform shotPoint;

    private float timebtwshots;

    public virtual void Attack()
    {

    }

}


public class Gun : Weapon
{
    protected float bspeed = 5f;
    public float bdistance = 5f;
    protected float lifetime = 0.4f;

    //public LayerMask whatisSolid;
    public Transform mytransform;
    public GameObject bullet;
    public float timebtwshots = 0.1f;

    public Gun(float bspeed, float bdistance, float lifetime, int dmg, GameObject bullet, Transform shotpoint, Transform transform)
    {
        this.bspeed = bspeed;
        this.bdistance = bdistance;
        this.lifetime = lifetime;
        this.dmg = dmg;
        this.bullet = bullet;
        this.shotPoint = shotpoint;
        this.mytransform = transform;
    }


    public override void Attack()
    {
        if (timebtwshots <= 0)
        {
            Instantiate(bullet, shotPoint.position, mytransform.rotation);
            timebtwshots = atackspeed;
        }
        else
        {
            timebtwshots -= Time.deltaTime;
        }
    }
}

public class Club : Weapon
{
    private bool isattacking;
    private bool isrecharged;

    public float attackrange;
    public float attacktime;
    public LayerMask enemy;

    public Club(int dmg, float attackrange, float attacktime)
    {
        this.dmg = dmg;
        this.attackrange = attackrange;
        this.attacktime = attacktime;
    }

    void Start()
    {

    }


    void Update()
    {

    }

    public override void Attack()
    {
        if (isrecharged)
        {
            State = States.punch;
            isattacking = true;
            isrecharged = false;

            StartCoroutine(AttackAnimation());
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(0.4f);
        isattacking = false;
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        isrecharged = true;
    }

    public void OnAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackrange, enemy);

        for (int i = 0; i < colliders.Length; i++)
            colliders[i].GetComponent<Entity>().GetDamage(dmg);
    }


}