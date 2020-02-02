using System.Collections;
using Toolbox;
using UnityEngine;

public class StepSon : MonoBehaviour
{
    public Transform path;
    public Transform model;
    public Transform stareTarget;
    public float waitTime = 1.5f;
    public AudioClip breakSound;
    public AudioSource hurtSource;


    Movement3D movement;
    Arrive3D arrive;
    Rigidbody rb;

    int targetIndex = 0;
    Transform target;

    private AudioSource audioSource;

    void Start()
    {
        movement = GetComponent<Movement3D>();
        arrive = GetComponent<Arrive3D>();
        rb = GetComponent<Rigidbody>();

        targetIndex = 0;
        target = path.GetChild(0);

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        for (int i = 0; i < path.childCount - 1; i++)
        {
            Debug.DrawLine(path.GetChild(i).position, path.GetChild(i + 1).position, Color.magenta, 0f, false);
        }
        Debug.DrawLine(path.GetChild(path.childCount - 1).position, path.GetChild(0).position, Color.magenta, 0f, false);
    }

    void FixedUpdate()
    {
        if (CanvasManager.isPaused)
        {
            movement.steering = Steering3D.Stop;
        }
        else if (stareTarget)
        {
            movement.steering = Steering3D.Stop;

            Vector3 direction = (stareTarget.position - transform.position).normalized;
            movement.LookAtDirection(model, direction);
        }
        else
        {
            movement.steering = arrive.GetSteering(target.position);

            if (!movement.steering.isMoving)
            {
                targetIndex++;
                targetIndex %= path.childCount;
                target = path.GetChild(targetIndex);
            }

            movement.LookWhereYoureGoing(model);
        }
    }

    bool isBreaking = false;

    public IEnumerator BreakThings(ParentItem parentItem)
    {
        if (!isBreaking && parentItem.CanBreak())
        {
            stareTarget = parentItem.transform;
            isBreaking = true;

            yield return new WaitForSeconds(waitTime);

            if (breakSound)
            {
                audioSource.clip = breakSound;
                audioSource.Play();
            }

            parentItem.Explode();
            stareTarget = null;
            isBreaking = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        PickUpItem item = other.transform.GetComponent<PickUpItem>();

        if (item && other.transform.parent)
        {
            ParentItem parentItem = other.transform.parent.GetComponent<ParentItem>();
            StartCoroutine(BreakThings(parentItem));
        }

        Rigidbody otherRb = other.transform.GetComponent<Rigidbody>();

        if (hurtSource && otherRb && otherRb.velocity.magnitude > 0)
        {
            hurtSource.Play();
        }
    }
}
