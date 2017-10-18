using UnityEngine;

public class Prop : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision) {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null) {
            Destroy(gameObject);
        }
    }
}