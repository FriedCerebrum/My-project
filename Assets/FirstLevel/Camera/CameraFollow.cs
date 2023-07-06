using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Персонаж, за которым следует камера
    public float smoothing = 5f; // Скорость сглаживания
    public float minX;
    public float maxX;

    Vector3 offset; // Смещение между камерой и персонажем

    void Start()
    {
        // Рассчитываем смещение
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Вычисляем новую позицию камеры
        Vector3 targetCamPos = target.position + offset;
        
        // Ограничиваем новую позицию в пределах minX и maxX
        targetCamPos.x = Mathf.Clamp(targetCamPos.x, minX, maxX);
        
        // Плавно перемещаем камеру в новую позицию
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
