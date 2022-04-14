using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fight : AnimController
{
    public GameObject bullet;
    public Transform shotPoint;
    public Transform mytransform;
    public LayerMask enemy;
    public float attackrange;

}




public abstract class Weapon : AnimController
{

    protected int dmg = 1;

    public bool isrecharged;
    public bool isattacking;


    public float attackspeed = 0.4f;
    public float curreloadtime;
    public float animationTime;


    public Transform shotPoint;



    public virtual void AttackStart()
    {

    }
    public virtual void AttackEnd()
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


    public override void AttackStart()
    {
        Debug.Log("as");
        isattacking = true;
        State = States.pistol_shot;
        curreloadtime = attackspeed;
    }
    public override void AttackEnd()
    {
        Instantiate(bullet, shotPoint.position, mytransform.rotation);
    }
}






public class Club : Weapon
{
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

    public override void AttackStart()
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
    }
    public override void AttackEnd()
    {
        
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