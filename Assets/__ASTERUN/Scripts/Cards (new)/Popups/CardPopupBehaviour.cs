using UnityEngine;
using System.Collections.Generic;
public class CardPopupBehaviour : MonoBehaviour
{
    public GameObject boostPanel;
    public List<GameObject> prefabList = new List<GameObject>();
    public List<GameObject> displayedCards = new List<GameObject>();

    private void OnEnable()
    {
        ChooseRandomCards();
    }

    public void ChooseRandomCards(int num = 3)
    {
        for (int i = 0; i < num; i++)
        {
            int rnd = Random.Range(0, prefabList.Count);
            if (prefabList[rnd] != null && !prefabList[rnd].activeSelf) //Instantiate(prefabList[rnd], boostPanel.transform);
                prefabList[rnd].SetActive(true);
            else
                i--;
        }
    }

    public void DeselectCards()
    {
        foreach (GameObject prefab in prefabList)
            prefab.SetActive(false);
    }
}
