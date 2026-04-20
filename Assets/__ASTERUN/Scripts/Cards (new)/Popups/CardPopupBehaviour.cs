using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class CardPopupBehaviour : MonoBehaviour
{
    public GameObject boostPanel;
    public List<GameObject> prefabList = new List<GameObject>();
    public List<GameObject> dupes = new List<GameObject>();
    public List<GameObject> activeTiles = new List<GameObject>();

    private void OnEnable()
    {
        DeselectCards();
        ChooseRandomCards();
    }

    public void ChooseRandomCards(int num = 3)
    {
        

        for (int i = 0; i < num; i++)
        {
            int rnd = Random.Range(0, prefabList.Count);
            if (prefabList[rnd] != null && !prefabList[rnd].activeSelf)
            {
                prefabList[rnd].SetActive(true);
                activeTiles.Add(prefabList[rnd]);
            }
            else
            {
                var dupe = Instantiate(prefabList[rnd], boostPanel.transform);
                dupes.Add(dupe);
            }
                
        }
    }

    public void DeselectCards()
    {
        foreach (GameObject prefab in prefabList)
            prefab.SetActive(false);
        foreach (GameObject dupe in dupes)
            Destroy(dupe);
    }

    public void ChangeButtonText()
    {
        foreach (GameObject tile in prefabList)
        {
            if (tile.activeSelf)
                activeTiles.Add(tile);
        }
        foreach (GameObject tile in dupes)
        {
            if (tile.activeSelf)
                activeTiles.Add(tile);
        }

        foreach (GameObject tile in activeTiles)
            tile.GetComponentInChildren<Button>().gameObject.GetComponentInChildren<TMP_Text>().text = tile.GetComponent<PopupTile>().ReturnButtonText();

    }
}
