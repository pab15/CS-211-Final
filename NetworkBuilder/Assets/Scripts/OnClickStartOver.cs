using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickStartOver : MonoBehaviour
{
    public void ClickedStartOver()
    {
        GameManager.allLocations.Clear();
        GameManager.connectionLines.Clear();
        GameManager.activeLines.Clear();
        GameManager.graph = new NetworkGraph();
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
