using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityZone : MonoBehaviour {

    public GameObject assignLandContent;
    public GameObject manager;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void CheckOwnership() {

        Component[] factionScripts = assignLandContent.GetComponentsInChildren(typeof(FactionRights));
        GameObject[] factions = manager.GetComponent<GameManager>().factions;
        for (int i = 0; i < factions.Length; i++) {
        }
    }
}
