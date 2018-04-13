using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour {

    private float maxYRotation = 120, minYRotation = 0;
    private float maxXRotation = 60, minXRotation = 0;

    private float shootTime = 1;
    private float shootTimer = 0;

    public GameObject bulletGO;
    public Transform firePostion;

    public AudioSource gunAudio;

	// Use this for initialization
	void Start () {
        gunAudio = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //print("Game : " + GameManager._instance.isPaused);
        if (GameManager._instance.isPaused == false)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootTime)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject currentBullet = GameObject.Instantiate(bulletGO, firePostion.position, Quaternion.identity);
                    currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 2500);
                    gameObject.GetComponent<Animation>().Play();
                    shootTimer = 0;

                    UIManager._instance.AddShootNum();

                    gunAudio.Play();

                }
            }
            float xPosPrecent = Input.mousePosition.x / Screen.width;
            float yPosPrecent = Input.mousePosition.y / Screen.height;

            float xAngle = -Mathf.Clamp(yPosPrecent * maxXRotation, minXRotation, maxXRotation) + 15;
            float yAngle = Mathf.Clamp(xPosPrecent * maxYRotation, minYRotation, maxYRotation) - 60;

            transform.eulerAngles = new Vector3(xAngle, yAngle, 0);
        }
    }
}
