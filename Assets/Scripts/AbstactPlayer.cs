using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstactPlayer : MonoBehaviour
{
    public BSNode nodoActual;
    public Graph graph;
    public float endData;

    public virtual void Start()
    {
        TurnManager.instance.players.Add(this);
    }

    protected abstract void PlayTurn();

    public virtual void EndTurn()
    {
        TurnManager.instance.NextTurn();
    }
}
