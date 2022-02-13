using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimController : MonoBehaviour
{
    protected Animator anim;
    public enum States
    {
        idle,
        run,
        punch,
        pee,
        smoke
    }

    public States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }
}



public class Entity : AnimController
{
    protected int lives;

    public virtual void GetDamage()
    {
        lives--;
        if (lives < 1)
            Die();
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
