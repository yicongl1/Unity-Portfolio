using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Application.Quit();
    }
}
