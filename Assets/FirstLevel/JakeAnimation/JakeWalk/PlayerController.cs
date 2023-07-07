    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        float newX = transform.position.x + move * speed * Time.deltaTime; // вычисление новой позиции по x

        // Проверка, что новая позиция находится в пределах заданных minX и maxX
        if (newX > maxX && move > 0)
        {
            newX = maxX;
        }
        else if (newX < minX && move < 0)
        {
            newX = minX;
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
