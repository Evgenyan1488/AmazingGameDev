using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    protected static Animator anim;
    public enum States
    {
        idle,
        run_dupi,
        run_body,
        punch,
        pee,
        smoke,
        Pistol_shot
    }

    public bool legsrun;

    public States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }
}



public class Entity : AnimController
{
    protected int lives;

    public void GetDamage(int damage)
    {
        lives--;
        if (lives < 1)
            Die();
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
