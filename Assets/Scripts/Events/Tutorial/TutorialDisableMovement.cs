using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDisableMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject frontWall;
    public GameObject backWall;
    public GameObject nextText; 
    private bool lookedAtFrontWall = false;
    private bool lookedAtBackWall = false;
    private bool canMove = false;

    void Update()
    {
        if (!canMove)
        {
            player.GetComponent<FPSMovement>().enabled = false;
            if (!lookedAtFrontWall && IsLookingAtWall(frontWall))
            {
                lookedAtFrontWall = true;
            }
            else if (lookedAtFrontWall && !lookedAtBackWall && IsLookingAtWall(backWall))
            {
                lookedAtBackWall = true;
            }
            else if (lookedAtFrontWall && lookedAtBackWall && IsLookingAtWall(frontWall))
            {
                canMove = true;
                EnablePlayerMovement();
                Destroy(gameObject);
            }
        }
    }

    bool IsLookingAtWall(GameObject wall)
    {
        Vector3 directionToWall = wall.transform.position - player.transform.position;
        float angle = Vector3.Angle(player.transform.forward, directionToWall);
        return angle < 30f; 
    }

    void EnablePlayerMovement()
    {
        player.GetComponent<FPSMovement>().enabled = true;
        nextText.SetActive(true);
        nextText.GetComponent<TutorialMovementTextLifetime>().DestroyAfterAMinute(); 
    }
}
