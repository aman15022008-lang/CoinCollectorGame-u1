using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            // Increase score
            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore();
            }

            // Play coin sound
            AudioSource audio = other.GetComponent<AudioSource>();

            if (audio != null && audio.clip != null)
            {
                AudioSource.PlayClipAtPoint(audio.clip, Camera.main.transform.position);
            }

            Debug.Log("Coin Collected!");

            // Destroy the coin
            Destroy(other.gameObject);
        }
    }
}