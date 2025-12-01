using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Синглтон экземпляр
    public static MenuManager Instance { get; private set; }

    // Ссылка на ваше меню паузы (например, UI Canvas)
    [SerializeField] private GameObject inventoryMenu;

    private void Awake()
    {
        // Проверка на существование другого экземпляра
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        inventoryMenu.SetActive(false);
    }

    public void OpenInventoryMenu()
	{
        Pause();
        inventoryMenu.SetActive(true);
    }

    public void CloseInventoryMeny()
	{
        Resume();
        inventoryMenu.SetActive(false); 
    }

    // Метод для паузы игры
    public void Pause()
    {
        Time.timeScale = 0f; // Останавливаем время
    }

    // Метод для отмены паузы
    public void Resume()
    {
        Time.timeScale = 1f; // Возвращаем время в норму
        inventoryMenu.SetActive(false); // Скрываем меню паузы
    }

    // Метод для выхода из игры (например, на главную меню)
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Для остановки игры в редакторе
#endif
    }
}