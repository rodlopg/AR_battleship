using UnityEngine;
using UnityEngine.UI;

public class CanvasToggleButton : MonoBehaviour
{
    public Button button;
    public Canvas targetCanvas;

    public enum ActionType
    {
        Activate,
        Deactivate
    }

    public ActionType action;

    void Start()
    {
        if (button == null || targetCanvas == null)
        {
            Debug.LogError("Button or Canvas not assigned in Inspector");
            return;
        }

        button.onClick.AddListener(HandleClick);
    }

    void HandleClick()
    {
        if (action == ActionType.Activate)
        {
            targetCanvas.gameObject.SetActive(true);
        }
        else if (action == ActionType.Deactivate)
        {
            targetCanvas.gameObject.SetActive(false);
        }
    }
}