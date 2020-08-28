using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BSNode currentNode;
    public Graph graph;
    public float endData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine (Timer());

        if(currentNode.getData() == endData)
        {
            Debug.Log("Fin");
        }

        if (Input.GetKeyDown("1") && currentNode.adyacentes.Count > 0)
        {
            currentNode = currentNode.adyacentes[0];
            transform.position = new Vector3(currentNode.gameObject.transform.position.x, currentNode.gameObject.transform.position.y, -1);
        }
        if (Input.GetKeyDown("2") && currentNode.adyacentes.Count > 1)
        {
            currentNode = currentNode.adyacentes[1];
            transform.position = new Vector3(currentNode.gameObject.transform.position.x, currentNode.gameObject.transform.position.y, -1);
        }
        if (Input.GetKeyDown("3") && currentNode.adyacentes.Count > 2)
        {
            currentNode = currentNode.adyacentes[2];
            transform.position = new Vector3(currentNode.gameObject.transform.position.x, currentNode.gameObject.transform.position.y, -1);
        }
        if (Input.GetKeyDown("4") && currentNode.adyacentes.Count > 3)
        {
            currentNode = currentNode.adyacentes[3];
            transform.position = new Vector3(currentNode.gameObject.transform.position.x, currentNode.gameObject.transform.position.y, -1);
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3); 
    }
}
