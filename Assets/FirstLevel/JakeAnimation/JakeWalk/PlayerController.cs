using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // если персонаж двигается, включаем анимацию
        if(move != 0)
        {
            anim.SetFloat("Speed", Mathf.Abs(move));
        }
        else // иначе выключаем анимацию
        {
            anim.SetFloat("Speed", 0);
        }

        // персонаж поворачивается в направлении движения
        if(move > 0 && !facingRight)
        {
            Flip();
        }
        else if(move < 0 && facingRight)
        {
            Flip();
        }
    }

    // переменная, которая хранит, куда смотрит персонаж
    bool facingRight = true;
    
    // метод для переворота персонажа
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
