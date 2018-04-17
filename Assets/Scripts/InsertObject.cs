using System.Collections;
using System.Collections.Generic;
using Mapbox.Examples;
using UnityEngine;
using UnityEngine.UI;

public class InsertObject : MonoBehaviour
{

    public Button InsertObjButton;

	private GameObject curObj;
    void Start()
    {
        Button btn = InsertObjButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        if (InsertObjButton.GetComponentInChildren<Text>().text == "Insert Obj")
        {
            GameObject objPrefab = Resources.Load("Turbine") as GameObject; //Get "Turbine" object from Resources folder
            curObj = Instantiate(objPrefab) as GameObject; //Instantiate the object into the scene
            curObj.GetComponent<Transform>().localScale = new Vector3(4, 4, 4); //Scale the object so it is fairly big.
            curObj.GetComponent<Transform>().position = GameObject.Find("LocationSprite").GetComponent<Transform>().position; //Position the object by default on the user's position
            curObj.GetComponent<Transform>().rotation = new Quaternion(0, 90, 90, 0); //Rotate the object so it stands upright
            curObj.AddComponent<HeightToMap>(); //Add the "HeightToMap" script to position the turbine on the 3D terrain vertically.
            Transform[] children = curObj.GetComponentsInChildren<Transform>(); //Get all the sub-component objects of the Turbine group
			InsertObjButton.GetComponentInChildren<Text>().text = "Place";
			GameObject.Find("MapCamera").GetComponent<CameraMovement>().enabled = false;
            foreach (Transform go in children)
            {
                go.gameObject.layer = 12;
            }
        }
        else
        {
			InsertObjButton.GetComponentInChildren<Text>().text = "Insert Obj";
			curObj.transform.parent = GameObject.Find("ArAlignedMap").transform;
			GameObject.Find("MapCamera").GetComponent<CameraMovement>().enabled = true;
        }

    }
}
