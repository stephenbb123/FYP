using UnityEngine;
using System.Collections;

public class CamGryoAR : MonoBehaviour {

	public GameObject webPlane;
	GameObject camParent;
	
	//intial
	void Start() {
		
		camParent = new GameObject("CamParent");
		camParent.transform.position = this.transform.position;
		this.transform.parent = camParent.transform;
		camParent.transform.Rotate(Vector3.right, 90);
		Input.gyro.enabled = true;
		
		WebCamTexture webCamTexture = new WebCamTexture();
		webPlane.GetComponent<MeshRenderer>().material.mainTexture = webCamTexture;
		webCamTexture.Play();
	}
	
	//update once per frame
	void Update() {
		Quaternion rotFix = new Quaternion(Input.gyro.attitude.x,
											Input.gyro.attitude.y,
											-Input.gyro.attitude.z,
											-Input.gyro.attitude.w);
		this.transform.localRotation = rotFix;
	}

}