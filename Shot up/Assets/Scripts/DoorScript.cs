using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]

public class DoorScript : MonoBehaviour
{
    public AudioClip door;
    public static int score;
    public TextMeshProUGUI text;
    

    void Start()
    {
        score = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crowd")
        {
            var agent = other.gameObject;
            score += 1;
            AudioSource.PlayClipAtPoint(door, agent.transform.position);
            Destroy(agent);
            text.SetText("Score: {0}", score);
        }
    }
}
