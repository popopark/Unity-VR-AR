using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csTank : MonoBehaviour {

    public GameObject turret;
    int moveSpeed = 10;
    int rotSpeed = 120;

    public Transform bullet;
    int power = 1500;
    Transform spPoint;

	// Use this for initialization
	void Start () {
        spPoint = transform.Find("/본체/포탑/포신/firePos");
	}
	
	// Update is called once per frame
	void Update () {
        float amtMove = moveSpeed * Time.smoothDeltaTime;
        float amtRot = rotSpeed * Time.smoothDeltaTime;

        float keyMove = Input.GetAxis("Vertical");
        float keyRot = Input.GetAxis("Horizontal");
        float keyTurret = Input.GetAxis("Turning");

        transform.Translate(Vector3.forward * amtMove * keyMove);
        transform.Rotate(Vector3.up * amtRot * keyRot);
        turret.transform.Rotate(Vector3.up * amtRot * keyTurret);

        if (Input.GetButtonDown("Fire1"))
        {
            Transform obj = Instantiate(bullet, spPoint.position, spPoint.rotation) as Transform;
            obj.GetComponent<Rigidbody>().AddForce(spPoint.forward * power);
        }
	}
}
