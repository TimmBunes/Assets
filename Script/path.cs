using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using system.Collections.Generic;

public class path : MonoBehaviour
{
    // Start is called before the first frame update
    public color lineColor;

    private List<Transform> nodes = new List<Transform>();
    void OnDrawGismos(){
        Gismos.color = lineColor;

        List<Transofrm> pathTransform = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for(int i = 0; i < pathTransform.Count; i++){
            if(pathTransform[i] != transform){
                nodes.Add(pathTransform[i]);
            }
        }

        for (int i = 0; i < nodes.Count; i++){
            Vector3 currentNode = nodes[i].position;
            Vector3 previousNode = Vector3.zero;

            if(i > 0){
                previousNode = nodes[i - 1].position;
            } else if(i == 0 && nodes.Count > 1){
                previousNode = nodes[nodes.Count - 1].position;
            }

            Gizmos.DrawLine(previousNode, currentNode);
            Gizmos.DrawWireSphere(currentNode, 0.3f);
        }
    }
}
