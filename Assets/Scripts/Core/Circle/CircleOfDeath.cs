using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters;

public class CircleOfDeath : MonoBehaviour
{
    List<IDamagable> damagables = new List<IDamagable>();
    [SerializeField] FloatReference ticksPerSec = new FloatReference(1);
    [SerializeField] FloatReference dmg = new FloatReference(1);
    [SerializeField] Collider2D circle;
    [SerializeField] GameEvent morphEndedEvent;
    [SerializeField] CircleStageManager stageManager;
    [SerializeField] float morphTicksPerSec = 10;

    float morphStartTime = 0;
    float morphEndTime = 0;
    [SerializeField] bool circleMorphing = false;
    Vector3 originalSize;
    Vector3 newSize;
    float toatalSizeDifference;
    float morphSpeed;



    private void OnTriggerExit2D(Collider2D collision)
    {
        IDamagable c = collision.GetComponent<IDamagable>();
        if(c != null)
            damagables.Add(c);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable c = collision.GetComponent<IDamagable>();
        if (c != null)
            damagables.Remove(c);
    }


    private void Start()
    {
        InvokeRepeating("dealDamage", 0, 1 / ticksPerSec.Value);
    }

    private void Update()
    {
        if (circleMorphing)
            morphCircle();

    }

    public void StartMorphingCircle()
    {
        circleMorphing = true;
        float morphTime = stageManager.CurrentState.MorphTime;
        float newRadius = stageManager.CurrentState.CircleRadius;
        morphStartTime = Time.time;
        morphEndTime = morphStartTime + morphTime;
        originalSize = transform.localScale;
        newSize = new Vector3(newRadius, newRadius, newRadius);
        toatalSizeDifference = originalSize.x - newRadius;
        morphSpeed = toatalSizeDifference/morphTime;
    }
    

    private void morphCircle()
    {

        if (Time.time >= morphEndTime && circleMorphing == true)
        {
            morphEndedEvent.Raise();
            circleMorphing = false;
        }
        else
        {
            // Distance moved = time * speed.
            float sizeChanged = (Time.time - morphStartTime) * morphSpeed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = sizeChanged / toatalSizeDifference;

            // Set our position as a fraction of the distance between the markers.
            transform.localScale = Vector3.Lerp(originalSize, newSize, fracJourney);

        }
    }


   

    private void dealDamage()
    {
        foreach (IDamagable damagable in damagables)
            damagable.getDamage(gameObject, dmg.Value);
    }




}
