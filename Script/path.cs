using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour
{
    // Start is called before the first frame update
    public Color lineColor;

    private List<Transform> nodes = new List<Transform>();

    void OnDrawGizmos()
    {
        Gizmos.color = lineColor;

        List<Transform> pathTransforms = new List<Transform>(GetComponentsInChildren<Transform>());
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Count; i++)
        {
            if (pathTransforms[i] != transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }

        for (int i = 0; i < nodes.Count; i++)
        {
            Vector3 currentNode = nodes[i].position;
            Vector3 previousNode = Vector3.zero;

            if (i > 0)
            {
                previousNode = nodes[i - 1].position;
            }
            else if (i == 0 && nodes.Count > 1)
            {
                previousNode = nodes[nodes.Count - 1].position;
            }

            Gizmos.DrawLine(previousNode, currentNode);
            Gizmos.DrawWireSphere(currentNode, 0.3f);
        }
    }
}