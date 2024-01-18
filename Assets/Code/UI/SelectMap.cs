using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectMap : MonoBehaviour
{
    public GameObject[] mapPrefab;
    public Sprite[] mapDisplayImage;
    public Transform mapFrontendHolderParent;
    public TextMeshProUGUI backgroundNameText;
    public Image backgroundImage;

    private int currentMapIndex=0;

    private void Start()
    {
        mapFrontendHolderParent = GameObject.Find("MapHolder").transform;
        ChangeMap(0);
    }
    // This script is designed to navigate through button selections on a map.
    // It returns -1 or 1 based on the button pressed.
    // This functionality simplifies the process of moving through map options.
    public void ChangeMap(int nextIndex)
    {
        currentMapIndex +=nextIndex;
        if (currentMapIndex == -1)
            currentMapIndex = mapPrefab.Length-1;
        else if(currentMapIndex == mapPrefab.Length)
            currentMapIndex = 0;

        backgroundNameText.text = string.Format("Map {0}", mapPrefab[currentMapIndex].name.Replace("Map",""));
        backgroundImage.sprite = mapDisplayImage[currentMapIndex];

        Destroy(mapFrontendHolderParent.GetChild(0).gameObject);
        Instantiate(mapPrefab[currentMapIndex], mapFrontendHolderParent);
    }
}
