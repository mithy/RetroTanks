﻿using UnityEngine;

public class Bullet : MonoBehaviour {

    private void Update() {
        transform.Translate(Vector3.left * Constants.BulletSpeed * Time.deltaTime);
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        gameObject.SetActive(false);

        TankCore tank = collision.gameObject.GetComponent<TankCore>();
        if (tank != null) {
            tank.DestroyThis();
        }
    }
}