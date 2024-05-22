using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject WinUI, LoseUI, ReloadButton;
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void EndGameUIOpen(bool isWin)
    {
        WinUI.SetActive(isWin);
        LoseUI.SetActive(!isWin);
        ReloadButton.SetActive(true);
    }
}