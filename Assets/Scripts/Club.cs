using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : Weapon
{
    private bool isattacking;
    private bool isrecharged;

    public int dmg;
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

    private void Attack()
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
