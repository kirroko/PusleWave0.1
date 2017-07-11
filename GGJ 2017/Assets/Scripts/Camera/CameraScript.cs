using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class CameraScript : MonoBehaviour {
	public GameObject target;
	public float distance;
	public float height;
	public float characterDistanceOffset;
	public float cameraShakePower;
    public MotionBlur blur;
    public BloomAndFlares bF;
	public float cameraShakeDuration;
	private float cameraShakeElapsedTime;
	private bool cameraShakeFlag;

	// Use this for initialization
	void Start () {
		cameraShakeFlag = false;
        blur = Camera.main.GetComponent<MotionBlur>();
        bF = Camera.main.GetComponent<BloomAndFlares>();
    }
	
	// Update is called once per frame
	void Update () {
		if (cameraShakeFlag) {
			cameraShakeElapsedTime += Time.deltaTime;

			Vector3 randomPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z)  + new Vector3(Random.Range(-cameraShakePower, cameraShakePower),
			                                                                 Random.Range(-cameraShakePower, cameraShakePower),
			                                                                 0f);

			transform.position = randomPosition + new Vector3(0, height, -distance);


			if (cameraShakeElapsedTime > cameraShakeDuration) {
				cameraShakeFlag = false;
				cameraShakeElapsedTime = 0;
                blur.blurAmount = 0.3f;
                bF.bloomIntensity = 3.5f;
                bF.bloomThreshold = 0.5f;
                bF.bloomBlurIterations = 2;
                bF.sepBlurSpread = 7.5f;
                transform.position = new Vector3( GetComponent<CameraFollows>().theplayerRig.transform.position.x, GetComponent<CameraFollows>().theplayerRig.transform.position.y, -10);
			}
		} 
	}

	public void ShakeCamera(float cameraShakePower, float cameraShakeDuration){
		this.cameraShakePower = cameraShakePower;
		this.cameraShakeDuration = cameraShakeDuration;
		cameraShakeFlag = true;
        blur.blurAmount = 0.5f;
        bF.bloomIntensity = 9.59f;
        bF.bloomThreshold = 0.36f;
        bF.bloomBlurIterations = 3;
        bF.sepBlurSpread = 7.5f;
		cameraShakeElapsedTime = 0;
	}
}
