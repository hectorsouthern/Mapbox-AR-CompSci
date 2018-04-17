using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Mapbox.Examples;

public class UIController : MonoBehaviour
{
    public Button modeToggleButton;
    public GameObject InsertObjButton;

    void Start()
    {
        Button btn = modeToggleButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if(modeToggleButton.GetComponentInChildren<Text>().text == "View"){
			//Switch to VIEW
			modeToggleButton.GetComponentInChildren<Text>().text = "Plan"; //Change toggle button
			GameObject.Find("MapCamera").GetComponent<Camera>().rect = new Rect(0, (float)-0.66, 1, 1); //Set viewport rect to cover buttom half of screen
            GameObject.Find("MapCamera").GetComponent<ManualTouchCamera>().enabled = true; //Enable manual adjustment of the AR Map.
            GameObject.Find("MapCamera").GetComponent<CameraMovement>().enabled = false; //Disable pan/zoom of the Planning map
            GameObject.Find("MapCamera").GetComponent<FollowTargetTransform>().enabled = true; //Bring the camera back to focusing on the correct location.
            InsertObjButton.SetActive(false);
		} else {
			//Switch to PLAN
			modeToggleButton.GetComponentInChildren<Text>().text = "View";
			GameObject.Find("MapCamera").GetComponent<Camera>().rect = new Rect(0, 0, 1, 1); //Expand viewport rect to cover entire screen.
            GameObject.Find("MapCamera").GetComponent<ManualTouchCamera>().enabled = false; //Disable manually moving the AR Map.
            GameObject.Find("MapCamera").GetComponent<CameraMovement>().enabled = true; //Enable pan/zoom of the planning map.
            GameObject.Find("MapCamera").GetComponent<FollowTargetTransform>().enabled = false; //Disable thge camera locked to centre AR root position.
            InsertObjButton.SetActive(true);
		}
    }
}