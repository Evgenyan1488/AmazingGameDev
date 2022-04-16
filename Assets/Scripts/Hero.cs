using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Entity
{
    //public float offset = -90f;

    Rigidbody2D body;
    
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public float runSpeed = 5.0f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
    }

    void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD
=======
        Vector3 dif = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
>>>>>>> Ponos
        debug = weapon.isattacking;
=======
>>>>>>> parent of cf42738 (sukaebanaya)
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
<<<<<<< HEAD
        {
            legsrun = true;
            if (!weapon.isattacking)
<<<<<<< HEAD
                State = States.run_body;
=======
                State = States.run_ruki;
>>>>>>> Ponos
        }
        else
        {
            legsrun = false;
            if (!weapon.isattacking)
                State = States.idle;
        }
<<<<<<< HEAD
        
        anim.SetBool("LegsRun", (bool)legsrun);
=======
            State = States.run;
        else
            State = States.idle;

>>>>>>> parent of cf42738 (sukaebanaya)
        Vector3 dif = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

<<<<<<< HEAD
        if (weapon.timebtwshots > 0)
            weapon.timebtwshots -= Time.deltaTime;
        
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Attack();
            StartCoroutine(WaitForAtc(weapon.atackspeed));
            //StartCoroutine(WaitForReload(0.01f));
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            weapon.atackspeed = 0.1f;
=======

        anim.SetBool("LegsRun", (bool)legsrun);
        

        if (weapon.curreloadtime > 0)
            weapon.curreloadtime -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (weapon.curreloadtime <= 0)
            {
                weapon.AttackStart();
                StartCoroutine(WaitForAtc(0.2f));
                //StartCoroutine(WaitForReload(0.01f));
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            weapon.attackspeed = 0.1f;
>>>>>>> Ponos
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            weapon = new Club(4, attackrange, 0.1f, enemy, mytransform);
        }
=======
>>>>>>> parent of cf42738 (sukaebanaya)
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
<<<<<<< HEAD
=======

    public void HeroAttack()
    {
        weapon.AttackEnd();
    }
>>>>>>> Ponos
}
