using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astar : MonoBehaviour
{
    public BSNode currentNode;
    public Graph graph;
    public float endData;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.position = new Vector3(currentNode.gameObject.transform.position.x, currentNode.gameObject.transform.position.y, -1);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNode.data != endData)
        {
            List<BSNode> path = A_star(currentNode, graph.search(endData));
            currentNode = path[1];
            transform.position = transform.position = new Vector3(currentNode.gameObject.transform.position.x, currentNode.gameObject.transform.position.y, -1);
        }
        else
        {
            Debug.Log("CPU win ");
        }
    }

    public List<BSNode> A_star(BSNode start, BSNode end)
    {
        List<BSNode> nodesToTest = new List<BSNode>();
        List<BSNode> testedNodes = new List<BSNode>();
        Dictionary<BSNode, BSNode> parentFor = new Dictionary<BSNode, BSNode>(); //Guarda el padre para nodo a que es nodo b

        List<BSNode> path = new List<BSNode>();

        nodesToTest.Add(start);

        Dictionary<BSNode, int> globalScore = new Dictionary<BSNode, int>();
        Dictionary<BSNode, int> localScore = new Dictionary<BSNode, int>();

        globalScore[start] = tempheus(start, end);
        localScore[start] = 0;


        while (nodesToTest.Count > 0)
        {
            BSNode current = null;
            //Encontrar el globalScore mas pequeño en nodesToTest
            for (int i = 0; i < nodesToTest.Count; i++)
            {
                BSNode node = nodesToTest[i];

                if (!globalScore.ContainsKey(node))
                {
                    globalScore[node] = 999999;
                }
                if (!localScore.ContainsKey(node))
                {
                    localScore[node] = 999999;
                }

                if (!current)
                    current = node;

                if (localScore[node] < localScore[current])
                    current = node;

            }

            if (current == end)
                return reconstruct_path(ref parentFor, start, current); //Devolver la ruta;

            nodesToTest.Remove(current);
            testedNodes.Add(current);

            for (int i = 0; i < current.adyacentes.Count; i++)
            {

                BSNode neighbor = current.adyacentes[i];

                if (testedNodes.Contains(neighbor)) continue;

                if (!globalScore.ContainsKey(neighbor))
                {
                    globalScore[neighbor] = 999999;
                }
                if (!localScore.ContainsKey(neighbor))
                {
                    localScore[neighbor] = 999999;
                }

                int tempG = (int)(localScore[current] + current.costoAdyacentes[i]);

                if (tempG < localScore[neighbor])
                {
                    localScore[neighbor] = tempG;
                    globalScore[neighbor] = localScore[neighbor] + tempheus(neighbor, end);
                    parentFor[neighbor] = current;
                    nodesToTest.Add(neighbor);
                }
            }
        }
        
        return path;
    }

    int tempheus(BSNode node, BSNode end)
    {
        int a = (int)((node.val * node.val + end.val * end.val) / 2);
        return a;
    }

    List<BSNode> reconstruct_path(ref Dictionary<BSNode, BSNode> parentOf, BSNode start, BSNode end)
    {
        List<BSNode> path = new List<BSNode>();
        path.Add(end);

        BSNode tmp = parentOf[end];

        while (tmp != start && tmp != null)
        {
            path.Add(tmp);
            tmp = parentOf[tmp];
        }
        path.Add(start);

        path.Reverse();

        return path;
    }
}
