using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillClimb : Algorithm
{
    Queue<BSNode> qv = new Queue<BSNode>();
    List<BSNode> yellowRoad = new List<BSNode>();

    public override List<BSNode> DoAlgorithm(BSNode start, BSNode end)
    {
        return hillClimb(start, end);
    }

    List<BSNode> hillClimb(BSNode start, BSNode end)
    {
        BSNode tmp2 = start;
        BSNode tmp = start;
        bool onVector = false;
        start.val = 0;
        for (int i = 0; i < yellowRoad.Count; i++)
        {
            if (yellowRoad[i] == start)
            {
                onVector = true;
            }
        }
        if (!onVector)
        {
            yellowRoad.Add(start);
        }
        for (int i = 0; i < tmp.adyacentes.Count; i++)
        {
            int costeConexion = (int)(tmp.costoAdyacentes[i] + tmp.val);
            if (DSuperSearch(tmp.adyacentes[i], end) == true)
            {
                tmp.adyacentes[i].val = costeConexion;

                if (tmp2.val == 0 || tmp2.val > tmp.adyacentes[i].val)
                {
                    tmp2 = tmp.adyacentes[i];
                }
            }
        }
        yellowRoad.Add(tmp2);
        if (tmp2 != end)
        {
            hillClimb(tmp2, end);
        }

        return yellowRoad;
    }
    bool DSuperSearch(BSNode start, BSNode end)
    {
        Stack<BSNode> ss = new Stack<BSNode>();
        BSNode tmp = start;
        ss.Push(tmp);
        while (tmp)
        {
            //cout << tmp.visitado << endl;
            if (tmp.getData() == end.getData())
            {
                resetVisitados();
                return true;
            }
            else if (tmp.visitado != true)
            {
                tmp.visitado = true;
                qv.Enqueue(tmp);
                ss.Pop();
                for (int i = 0; i < tmp.adyacentes.Count; i++)
                {
                    if (tmp.adyacentes[i].visitado != true)
                    {
                        ss.Push(tmp.adyacentes[i]);
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
                return false;
            }
            tmp = ss.Peek();
        }
        resetVisitados();
        return false;
    }

    void resetVisitados()
    {
        while (qv.Count > 0)
        {
            qv.Peek().visitado = false;
            qv.Dequeue();
        }
    }
}
