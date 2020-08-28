using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Player : AbstactPlayer
{

    public Algorithm algorithm;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        InvokeRepeating("PlayTurn", 3,3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void PlayTurn()
    {
        if (algorithm.currentNode.data != algorithm.endData)
        {
            List<BSNode> path = algorithm.DoAlgorithm(algorithm.currentNode, algorithm.graph.search(endData));
            if (path.Count > 0)
                algorithm.currentNode = path[1];
            algorithm.transform.position = new Vector3(algorithm.currentNode.gameObject.transform.position.x, algorithm.currentNode.gameObject.transform.position.y, -1);
            EndTurn();
        }
        else
        {
            Debug.Log("CPU win");
        }
    }
}
