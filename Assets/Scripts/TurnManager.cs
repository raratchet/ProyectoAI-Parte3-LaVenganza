using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<AbstactPlayer> players = new List<AbstactPlayer>();
    public AbstactPlayer currentPlayer;
    public int currentIndex = 0;

    #region Singleton

    public static TurnManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public void NextTurn()
    {
        currentIndex++;
        if (currentIndex >= players.Count)
            currentIndex = 0;
        currentPlayer = players[currentIndex];
    }
}
