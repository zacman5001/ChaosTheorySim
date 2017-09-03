using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityZone : MonoBehaviour {

    public GameObject assignLandContent;
    public GameObject manager;

    private bool touchingHuntingArea;
    private bool touchingFarm;
    private bool touchingWood;
    public bool touchingLoot;

    private Component[] factionScripts;
    private GameObject[] factions;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Lootable"))
        {
            touchingLoot = true;
        }
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < factions.Length; i++)
        {
            GameObject isLootable = factionScripts[i].gameObject.GetComponent<FactionRights>().lootingToggle;
            if (!factions[i].GetComponent<NobleFamilyBehavior>().scavengeableTiles.Contains(gameObject) &&
                isLootable.GetComponent<Toggle>().isOn && touchingLoot)
            {
                factions[i].GetComponent<NobleFamilyBehavior>().scavengeableTiles.Add(this.gameObject);
            }
        }
    }

    public void CheckOwnership() {

        factionScripts = assignLandContent.GetComponentsInChildren(typeof(FactionRights));
        factions = manager.GetComponent<GameManager>().factions;

    }
}
