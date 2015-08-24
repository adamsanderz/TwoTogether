﻿using UnityEngine;
using System.Collections;

public class Objective : MonoBehaviour {

	public GameObject handler;
	public GameObject lookingFor;

	private ObjectiveHandler objectiveHandler;
	private Color originalColor;
	private string lookingForTag;
	private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		objectiveHandler = handler.GetComponent<ObjectiveHandler>();
		renderer = GetComponent<SpriteRenderer>();
        if (lookingFor.tag == "SmallCube") {
            originalColor = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0.61960784313725490196078431372549f);
        } else if (lookingFor.tag == "BigCube") {
            originalColor = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0.70196078431372549019607843137255f);
        }
		lookingForTag = lookingFor.tag;
        /*
        Debug.Log(renderer.color);
        Debug.Log(renderer.color.r * 255f + ", " + renderer.color.g * 255f + ", " + renderer.color.b * 255f + ", " + renderer.color.a * 255f);
        Debug.Log(originalColor);
        Debug.Log(originalColor.r * 255f + ", " + originalColor.g * 255f + ", " + originalColor.b * 255f + ", " + originalColor.a * 255f);
        Debug.Log("===============================");
        */
    }

	void OnTriggerEnter2D(Collider2D otherObject) {
		if (otherObject.transform.tag == lookingForTag) {
			renderer.color = Color.black;
            //otherObject.transform.position = transform.position;
			objectiveHandler.SetObjectiveActivated(lookingForTag, true);
		}
	}

	void OnTriggerExit2D(Collider2D otherObject) {
		if (otherObject.tag == lookingForTag) {
			renderer.color = originalColor;
			objectiveHandler.SetObjectiveActivated(lookingForTag, false);
		}
	}
	

}
