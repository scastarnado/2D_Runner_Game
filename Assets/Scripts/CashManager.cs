using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashManager : MonoBehaviour
{
    public PlayerInformation PlayerInformation;

    private void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = PlayerInformation.coinsToBuyNewStuff.ToString();
    }
}
