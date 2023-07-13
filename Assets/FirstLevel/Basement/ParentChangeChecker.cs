using System;
using UnityEngine;

public class DetectParentChange : MonoBehaviour
{
    // Событие, которое будет вызвано, когда родительский объект изменится
    public event Action OnParentChange;

    private Transform lastParent;

    public NPC npc;    

    // Сохраняем первоначального родителя при инициализации
    private void Start()
    {
        lastParent = transform.parent;
        // Подписываемся на событие
        OnParentChange += HandleParentChange;
    }

    private void HandleParentChange()
    {
        // Вызываем метод SetDialogue при изменении родительского объекта
        npc.SetDialogue(1);
    }

    // Проверяем изменение родительского объекта каждый кадр
    private void Update()
    {
        if (transform.parent != lastParent)
        {
            lastParent = transform.parent;

            // Если родительский объект изменился, вызываем событие
            OnParentChange?.Invoke();

            // Отключаем этот скрипт
            this.enabled = false;
        }
    }

    private void OnDestroy()
    {
        // Отписываемся от события
        OnParentChange -= HandleParentChange;
    }
}
