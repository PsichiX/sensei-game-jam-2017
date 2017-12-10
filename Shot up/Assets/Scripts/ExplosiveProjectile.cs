using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class ExplosiveProjectile : ThrowableItem
{
    public float Speed = 1.0f;
    public float ExplosionRadius = 2.0f;

    private float timeLeft;
    public AudioClip explode;
    public AudioClip cat;
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0f)
        {
            AudioSource.PlayClipAtPoint(explode, transform.position, 2.0f);

            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Collider[] affected = Physics.OverlapSphere(transform.position, ExplosionRadius);
            foreach (Collider collider in affected)
                if (collider.tag == "Crowd" || collider.tag == "Support")
                {
                    Destroy(collider.gameObject);
                }


            Destroy(gameObject);
        }
    }

    public override void Fire(Vector2 target)
    {
        AudioSource.PlayClipAtPoint(cat, transform.position, 2.0f);
        Vector3 totalTranslation = new Vector3(
            target.x - transform.position.x,
            0.0f,
            target.y - transform.position.z);

        timeLeft = totalTranslation.magnitude / Speed;

        GetComponent<Rigidbody>().velocity = Vector3.Scale(
            Vector3.Normalize(totalTranslation),
            new Vector3(Speed, Speed, Speed));
    }
}
