using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public AlignBodyWithOVR alignBodyWithOVR;
    public void IsLocalPlayer() {
        alignBodyWithOVR.enabled = true;
        foreach (GameObject go in gameObjects) {
            go.SetActive(true);
        }
    }
}
