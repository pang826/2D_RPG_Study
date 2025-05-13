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
            talkText.text = $"�̰��� �̸��� {scanObj.name} �̶�� �Ѵ�.";
        }

        talkPanel.SetActive(IsAction);
    }
}
