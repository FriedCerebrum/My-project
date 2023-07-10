using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float minX = -10f;
    public float maxX = 10f;
    private Rigidbody2D rb;
    private Animator anim;
    public bool canMove = true;


    // переменная, которая хранит, куда смотрит персонаж
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        

    }

    void Update()
    {
        if (!canMove)
        {
            return;
        }
        float move = Input.GetAxis("Horizontal");
        float newX = transform.position.x + move * speed * Time.deltaTime; // вычисление новой позиции по x

        // Проверка, что новая позиция находится в пределах заданных minX и maxX
        if (newX > maxX && move > 0)
        {
            newX = maxX;
            move = 0; // остановка персонажа и анимации, если достигнута правая граница
        }
        else if (newX < minX && move < 0)
        {
            newX = minX;
            move = 0; // остановка персонажа и анимации, если достигнута левая граница
        }

        // обновление позиции персонажа
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

    // метод для переворота персонажа
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public bool IsFacingRight()
    {
        return facingRight;
    }

    public void ForceFlip()
    {
        Flip();
    }
}
