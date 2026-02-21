using UnityEngine;
using UnityEngine.UI;

public class ButtonCycleColor : MonoBehaviour
{
    public Button targetButton;

    private int clickCount = 0;
    private Image buttonImage;

    void Start()
    {
        if (targetButton == null)
        {
            Debug.LogError("Button not assigned in Inspector");
            return;
        }

        buttonImage = targetButton.GetComponent<Image>();
        targetButton.onClick.AddListener(OnButtonClick);

        SetDarkGrey();
    }

    void OnButtonClick()
    {
        clickCount++;

        if (clickCount == 1)
        {
            buttonImage.color = Color.white;
        }
        else if (clickCount == 2)
        {
            buttonImage.color = Color.red;
        }
        else if (clickCount == 3)
        {
            clickCount = 0;
            SetDarkGrey();
        }
    }

    void SetDarkGrey()
    {
        buttonImage.color = new Color(0.2f, 0.4f, 0.8f);
    }
}