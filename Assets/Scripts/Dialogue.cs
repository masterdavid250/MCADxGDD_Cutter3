using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index; 

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponentInParent<FPSMovement>().enabled = false;
        this.GetComponentInParent<FPSCameraController>().enabled = false;
        textComponent.text = string.Empty;
        StartDialogue(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine(); 
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c; 
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            this.GetComponentInParent<FPSMovement>().enabled = true;
            this.GetComponentInParent<FPSCameraController>().enabled = true;
            Destroy(gameObject); 
            //gameObject.SetActive(false);
        }
    }
}
