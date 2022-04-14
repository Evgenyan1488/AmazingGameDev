using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    protected static Animator anim;
    public enum States
    {
        idle,
<<<<<<< HEAD
        run_dupi,
        run_body,
=======
        run_ruki,
>>>>>>> Ponos
        punch,
        pistol_shot,
        pee,
        smoke,
        Pistol_shot
    }
<<<<<<< HEAD

    public bool legsrun;

=======
    public bool legsrun;
    private void Awake()
    {
    }
>>>>>>> Ponos
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
