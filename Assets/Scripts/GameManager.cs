using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject scanObj;
    [SerializeField] GameObject talkPanel;
    [SerializeField] TextMeshProUGUI talkText;
    public bool IsAction;
    public void Action(GameObject scanObject)
    {
        if (IsAction)
        {
            IsAction = false;
        }
        else
        {
            IsAction = true;
            scanObj = scanObject;
            talkText.text = $"이것의 이름은 {scanObj.name} 이라고 한다.";
        }

        talkPanel.SetActive(IsAction);
    }
}
