using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    public Image avatarImage;
    public TextMeshProUGUI dialogText;
    public DialogDatabase dialogDatabase;

    void Start()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void ShowDialog(int dialogIndex)
    {
        DialogSO dialog = dialogDatabase.dialogSO[dialogIndex];
        avatarImage.sprite = dialog.avatar;
        dialogText.text = dialog.dialogLines;
    }
}
