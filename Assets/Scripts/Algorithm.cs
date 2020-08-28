using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Algorithm : MonoBehaviour
{
    public BSNode currentNode;
    public Graph graph;
    public float endData;

    public abstract List<BSNode> DoAlgorithm(BSNode start, BSNode end);
}
