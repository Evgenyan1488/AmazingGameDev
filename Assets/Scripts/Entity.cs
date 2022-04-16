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
<<<<<<< HEAD
<<<<<<< HEAD
        run_dupi,
        run_body,
=======
        run_ruki,
>>>>>>> Ponos
=======
        run,
>>>>>>> parent of cf42738 (sukaebanaya)
=======
        run,
>>>>>>> parent of bbd2e6c (Победа)
        punch,
        pee,
        smoke
    }
<<<<<<< HEAD
<<<<<<< HEAD

<<<<<<< HEAD
    public bool legsrun;

=======
    public bool legsrun;
=======

>>>>>>> parent of bbd2e6c (Победа)
    private void Awake()
    {
    }
>>>>>>> Ponos
=======
    private void Awake()
    {
    }
>>>>>>> parent of cf42738 (sukaebanaya)
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
        lives-=damage;
        if (lives < 1)
            Die();
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
