using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignLandButton : MonoBehaviour {

    public GameObject panel;
    public Button button;
    public GameObject content;
    public GameObject manager;
    public GameObject factionOptions;

	// Use this for initialization
	void Start () {
        panel = GameObject.Find("AssignLandPanel");
        panel.SetActive(false);
        button.onClick.AddListener(togglePanel);
        content.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-141.5f, 0, 0);

        foreach (GameObject faction in manager.GetComponent<GameManager>().factions) {
            GameObject addedPanel = Instantiate(factionOptions);
            addedPanel.GetComponentInChildren<Text>().text = faction.name;
            addedPanel.transform.SetParent(content.transform);
        }
	}
	
	// Update is called once per frame
	void togglePanel () {
        if (panel.activeInHierarchy)
        {
            panel.SetActive(false);
        }
        else {
            panel.SetActive(true);
        }

	}
}
