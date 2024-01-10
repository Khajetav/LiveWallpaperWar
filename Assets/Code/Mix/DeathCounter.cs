using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI deathCounterText;
    void Start()
    {
        deathCounterText.text = PlayerPrefs.GetInt("deathCounter", 0).ToString();
    }

    public void OnKill(int kills)
    {
        int deathCounter = PlayerPrefs.GetInt("deathCounter", 0);
        deathCounter = deathCounter + kills;
        deathCounterText.text = deathCounter.ToString();
        PlayerPrefs.SetInt("deathCounter",deathCounter);
    }
}
