using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class BSNode : MonoBehaviour
{
    public float data;
    public float val = 100000;
    public bool visitado = false;
    public BSNode padre;
    public List<BSNode> adyacentes = new List<BSNode>();
    public List<float> costoAdyacentes = new List<float>();
    public float getData()
    {
        return data;
    }

    private void Start()
    {

    }

    public void Update()
    {
        foreach(var nodo in adyacentes)
        {
            Debug.DrawLine(this.transform.position, nodo.transform.position);
        }
    }
}
