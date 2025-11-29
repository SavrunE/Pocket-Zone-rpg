using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCellButtons : MonoBehaviour
{
    private Coroutine cor;
    [SerializeField] private Button mainButton;
    [SerializeField] private Button deleteButton;
    [SerializeField] private InventoryCell inventoryCell;

    private void OnEnable()
    {
        mainButton.onClick.AddListener(OnMainButtonClick);
        deleteButton.onClick.AddListener(DeleteCellButton);
    }

    private void DeleteCellButton()
    {
        StopCoroutine(cor);
        inventoryCell.DeleteThis();
    }

    private void OnMainButtonClick()
    {
        cor = StartCoroutine(ShowDeleteButton());
    }

    private IEnumerator ShowDeleteButton()
    {
        deleteButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        deleteButton.gameObject.SetActive(false);
    }
}
