using UnityEngine;

public class LeftDoorController : MonoBehaviour
{
    public GameObject leftDoorTR;
    public GameObject leftDoorPlanks;

    private TeleportTrigger teleportTrigger;

    private void Start()
    {
        // Получаем компонент TeleportTrigger из объекта LeftDoorTR
        teleportTrigger = leftDoorTR.GetComponent<TeleportTrigger>();
    }

    private void Update()
    {
        // Проверяем, если объект LeftDoorPlanks отключен, активируем компонент TeleportTrigger
        if (!leftDoorPlanks.activeSelf && !teleportTrigger.enabled)
        {
            teleportTrigger.enabled = true;
        }
        // Если объект LeftDoorPlanks включен, отключаем компонент TeleportTrigger
        else if (leftDoorPlanks.activeSelf && teleportTrigger.enabled)
        {
            teleportTrigger.enabled = false;
        }
    }
}
