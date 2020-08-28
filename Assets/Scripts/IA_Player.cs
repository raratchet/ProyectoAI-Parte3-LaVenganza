using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Player : AbstactPlayer
{

    public Dijsktra dijsktra;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        PlayTurn();
    }

    protected override void PlayTurn()
    {
        if(TurnManager.instance.currentPlayer == this)
        {
            if (dijsktra.currentNode.data != dijsktra.endData)
            {
                List<BSNode> path = dijsktra.Dijkstra(dijsktra.currentNode, dijsktra.graph.search(dijsktra.endData));
                
                dijsktra.transform.position = new Vector3(dijsktra.currentNode.gameObject.transform.position.x, dijsktra.currentNode.gameObject.transform.position.y, -1);
                dijsktra.currentNode = path[1];
                EndTurn();
            }
            else
            {
                Debug.Log("CPU win");
            }
        }
    }
}
