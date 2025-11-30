using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform; // Ссылка на объект камеры
    [SerializeField] private float smoothSpeed = 0.125f; // Скорость сглаживания движения камеры
    [SerializeField] private Vector3 offset; // Смещение камеры относительно персонажа

    private void LateUpdate()
    {
        if (cameraTransform == null) return; // Проверяем, установлена ли камера

        // Определяем желаемую позицию камеры с учетом смещения
        Vector3 desiredPosition = transform.position + offset;

        // Плавно интерполируем позицию камеры к желаемой позиции
        Vector3 smoothedPosition = Vector3.Lerp(cameraTransform.position, desiredPosition, smoothSpeed);

        // Обновляем позицию камеры
        cameraTransform.position = smoothedPosition;
    }
}