using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoudSoundTrigger : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject dialogueBox;
    public Transform spawnWaypoint;
    public float delayTime = 2.0f;
    public float lerpDuration = 1.0f; 

    private bool didPlayerEnter = false;

    [SerializeField] private UnityEvent onPlayerEnter;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTERED");
        if (other.gameObject.GetComponent<FPSMovement>() != null)
        {
            if (!didPlayerEnter)
            {
                StartCoroutine(SpawnAndFaceObject(other.gameObject));
                onPlayerEnter?.Invoke();
            }
        }
    }

    private IEnumerator SpawnAndFaceObject(GameObject player)
    {
        didPlayerEnter = true;

        GameObject spawnedObject = Instantiate(objectToSpawn, spawnWaypoint.position, spawnWaypoint.rotation);
        yield return new WaitForSeconds(delayTime);
        yield return StartCoroutine(LerpCameraTowardsObject(player.transform, spawnedObject.transform.position));
        SpawnDialogueBox(player);
        Destroy(gameObject);
    }

    private void SpawnDialogueBox(GameObject player)
    {
        // Attach dialogueBox to Player
        GameObject instantiatedDialogueBox = Instantiate(dialogueBox, player.transform);
        instantiatedDialogueBox.transform.localPosition = Vector3.zero;
    }

    private IEnumerator LerpCameraTowardsObject(Transform playerTransform, Vector3 targetPosition)
    {
        Quaternion startRotation = playerTransform.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - playerTransform.position);
        float elapsedTime = 0;
        while (elapsedTime < lerpDuration)
        {
            playerTransform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / lerpDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        playerTransform.rotation = targetRotation; 
    }
}
