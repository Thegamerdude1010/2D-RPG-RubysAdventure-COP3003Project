using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I do not believe you can specify visibility for inheritance in C#
//Trying to change visibility (Ex: public class SubClass : public BaseClass) causes an error
public class RedBotController :  EnemyController
{
    EnemyClass redEnemy = new EnemyClass(-3, false, 2.0f);

    Rigidbody2D rigidbody2d;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    new

        // Update is called once per frame
        void Update()
    {
        base.Update();
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        if (redEnemy.GetVertical())
        {
            position.y = position.y + Time.deltaTime * redEnemy.GetSpeed() * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * redEnemy.GetSpeed() * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        rigidbody2d.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(redEnemy.GetDamage());
        }
    }
}
