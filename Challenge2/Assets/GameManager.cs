using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event Action EndGame;

    private void Awake()
    {
        Instance = this;
    }

    public void GameFinish(bool isWin)
    {
        UIManager.Instance.EndGameUIOpen(isWin);
        StackController.Instance.endGame = true;
        EndGame?.Invoke();
    }
}