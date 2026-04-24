using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldNodeManager : MonoBehaviour
{
    public Color emptyColour;
    public Color fullColour;
    public int filledCharges;

    public List<GameObject> nodes = new List<GameObject>();

    private void OnEnable()
    {
        EmptyAll();
    }

    private void EmptyAll()
    {
        foreach (GameObject node in nodes)
        {
            node.GetComponent<Image>().color = emptyColour;
        }
    }

    private void FillCharges()
    {
        for (int i = 0; i < filledCharges; i++)
        {
            nodes[i].GetComponent<Image>().color = fullColour;
        }
    }

    public void Charge(int val = 1) 
    {
        if ((filledCharges + val) > nodes.Count)
            filledCharges = nodes.Count;
        else filledCharges += val;

        FillCharges(); 
    }
    public void Drain(int val = 1)
    {
        if ((filledCharges - val) <= 0)
            EmptyAll();
        else filledCharges -= val;

        FillCharges();
    }

}
