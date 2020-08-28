using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    public Queue<BSNode> qv = new Queue<BSNode>();
    public GameObject nodoChad;
    public BSNode padre = null;
    public List<Vector3> valList = new List<Vector3>();
    public List<Vector2> posList = new List<Vector2>();

    public void addEdge(float dataParent, float data, float cost, float x, float y)
    {
        BSNode tmp = DSearch(dataParent);
        if (tmp != null && !dataParent.Equals(data))
        {
            if (DSearch(data) == null)
            {

                BSNode nodo = Instantiate(nodoChad).GetComponent<BSNode>();
                nodo.gameObject.transform.position = new Vector2(x, y);
                //Comentario para que no se nos olvide
                //Asignarle dato y val
                nodo.padre = tmp;
                nodo.data = data;
                tmp.adyacentes.Add(nodo);

                tmp.costoAdyacentes.Add(cost);
            }
            else if (searchPadre(tmp, data) == null)
            {
                BSNode dataNode = DSearch(data);
                tmp.adyacentes.Add(dataNode);
                tmp.costoAdyacentes.Add(cost);
            }
        }
    }

    public BSNode searchPadre(BSNode head, float data)
    {
        BSNode tmp = head;
        while (!tmp.Equals(null))
        {
            qv.Enqueue(tmp);
            if (tmp.visitado.Equals(false))
            {
                tmp.visitado = true;
                foreach (BSNode adyacente in tmp.adyacentes)
                {
                    adyacente.visitado = true;
                    qv.Enqueue(adyacente);
                    if (adyacente.getData().Equals(data))
                    {
                        resetVisitados();
                        tmp = adyacente;
                        return tmp;
                    }
                }
                resetVisitados();
                return null;
            }
        }
        return null;
    }

    public BSNode search(float data)
    {
        Queue<BSNode> qs = new Queue<BSNode>();
        BSNode tmp = padre;
        while (!tmp.Equals(null))
        {
            qv.Enqueue(tmp);
            if (tmp.getData().Equals(data))
            {
                resetVisitados();
                return tmp;
            }
            else if (tmp.visitado != true)
            {
                tmp.visitado = true;
                foreach (BSNode adyacente in tmp.adyacentes)
                {
                    qs.Enqueue(adyacente);
                    qv.Enqueue(adyacente);
                }
            }
            if (qs.Peek().Equals(null))
            {
                resetVisitados();
                return null;
            }
            tmp = qs.Peek();
            qs.Dequeue();
        }
        return null;
    }

    public BSNode DSearch(float data)
    {
        Stack<BSNode> ss = new Stack<BSNode>();
        BSNode tmp = padre;
        ss.Push(tmp);
        if (ss.Count > 0)
        {
            while (tmp != null)
            {
                //cout << tmp->visitado << endl;
                tmp.getData();
                if (tmp.getData().Equals(data))
                {
                    resetVisitados();
                    return tmp;
                }
                else if (tmp.visitado != true)
                {
                    tmp.visitado = true;
                    qv.Enqueue(tmp);
                    ss.Pop();
                    foreach (BSNode adyacente in tmp.adyacentes)
                    {
                        if (!adyacente.visitado)
                        {
                            ss.Push(adyacente);
                        }
                    }
                }
                else
                {
                    ss.Pop();
                }
                if (ss.Count <= 0)
                {
                    resetVisitados();
                    //cout << "nop" << endl;
                    return null;
                }
                tmp = ss.Peek();
            }
            resetVisitados();
            return null;
        }
        return null;
    }

    public void resetVisitados()
    {
        if (qv.Count > 0)
        {
            while (qv.Count > 0)
            {
                qv.Peek().visitado = false;
                qv.Dequeue();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        addEdge(valList[0].x, valList[0].y, valList[0].z, posList[0].x, posList[0].y);
        addEdge(valList[1].x, valList[1].y, valList[1].z, posList[1].x, posList[1].y);
        addEdge(valList[2].x, valList[2].y, valList[2].z, posList[2].x, posList[2].y);
        addEdge(valList[3].x, valList[3].y, valList[3].z, posList[3].x, posList[3].y);
        addEdge(valList[4].x, valList[4].y, valList[4].z, posList[4].x, posList[4].y);
        addEdge(valList[5].x, valList[5].y, valList[5].z, posList[5].x, posList[5].y);
        addEdge(valList[6].x, valList[6].y, valList[6].z, posList[5].x, posList[5].y);
        addEdge(valList[7].x, valList[7].y, valList[7].z, posList[5].x, posList[5].y);
        addEdge(valList[8].x, valList[8].y, valList[8].z, posList[0].x, posList[0].y);
        addEdge(valList[9].x, valList[9].y, valList[9].z, posList[6].x, posList[6].y);
        addEdge(valList[10].x, valList[10].y, valList[10].z, posList[6].x, posList[6].y);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach(var nodo in gameObject.GetComponent<Astar>().A_star(padre,DSearch(6)))
            {
                nodo.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
