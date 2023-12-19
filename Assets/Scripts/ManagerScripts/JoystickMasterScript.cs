using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public enum SetupItemType
{
    Dialogue,
    Item
}

public class JoystickMasterScript : MonoBehaviour
{
    public static JoystickMasterScript instance;

    PlayerControls controls;

    public float sensitivity = 500f;
    public Transform playerBody;
    public Camera playerCamera;

    public GameObject flashlightGameObject;

    public GameObject dialoguePrefab;

    public GameObject itemToInspectPrefab;
    public bool canInteract = false;
    public bool isInspecting = false;

    Vector2 joystickLookInput;

    private float rotationX = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        controls = new PlayerControls();

        //Circle is pressed
        controls.Gameplay.Enter.performed += ctx => NextButton();

        //Triangle is pressed
        controls.Gameplay.TriangleButton.performed += ctx => TriangleButtonFunction();

        //X is pressed
        controls.Gameplay.ExitJoystickButton.performed += ctx => ExitJoystickButtonFunction();

        controls.Gameplay.Look.performed += ctx => joystickLookInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.Look.canceled += ctx => joystickLookInput = Vector2.zero;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        if (playerCamera != null)
        {
            rotationX = playerCamera.transform.localEulerAngles.x;
        }
    }

    public void NextButton()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 0) 
        {
            int nextSceneIndex = currentScene.buildIndex + 1;
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }

        if (dialoguePrefab != null)
        {
            dialoguePrefab.GetComponent<Dialogue>().CheckNextLine(); 
        }

        if (canInteract && !isInspecting && itemToInspectPrefab != null) 
        {
            itemToInspectPrefab.GetComponent<ItemInspect>().StartInspection(); 
        }
        else if (isInspecting && itemToInspectPrefab != null)
        {
            itemToInspectPrefab.GetComponent<ItemInspect>().AddToInventory();
        }
    }

    public void TriangleButtonFunction()
    {
        if (flashlightGameObject != null)
        {
            this.flashlightGameObject.GetComponent<Flashlight>().OpenAndCloseFlashlight();
        }
    }

    public void ExitJoystickButtonFunction()
    {
        if (isInspecting && itemToInspectPrefab != null)
        {
            itemToInspectPrefab.GetComponent<ItemInspect>().CloseInspectionUI();
        }
    }

    //Player Setup
    public void PlayerSetup(Transform assignPlayer, Camera assignCamera)
    {
        playerBody = assignPlayer;
        playerCamera = assignCamera; 
    }

    //Flashlight Setup
    public void FlashlightSetup(GameObject flashlightObject) 
    {
        flashlightGameObject = flashlightObject;
    }

    //Dialogue Setup
    public void SetupDialogueBox(GameObject dialogueBox)
    {
        dialoguePrefab = dialogueBox;
    }

    //Item Inspect Setup
    public void ItemInspectSetup(GameObject inspectedItem, bool canInteractSource, bool isInspectingSource)
    {
        itemToInspectPrefab = inspectedItem;
        canInteract = canInteractSource;
        isInspecting = isInspectingSource;
    }

    public void RemoveSetupItem(SetupItemType itemType)
    {
        switch (itemType)
        {
            case SetupItemType.Dialogue:
                dialoguePrefab = null;
                break;
            case SetupItemType.Item:
                itemToInspectPrefab = null;
                canInteract = false;
                isInspecting = false;
                break;
            default:
                Debug.LogWarning("Unknown setup item type");
                break;
        }
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void Update()
    {
        if (playerCamera != null && playerBody != null)
        {
            float lookX = joystickLookInput.x * sensitivity * Time.deltaTime;
            float lookY = joystickLookInput.y * sensitivity * Time.deltaTime;

            playerBody.Rotate(Vector3.up * lookX);

            rotationX -= lookY;
            rotationX = Mathf.Clamp(rotationX, -80f, 80f);

            playerCamera.transform.localEulerAngles = new Vector3(rotationX, playerCamera.transform.localEulerAngles.y, 0f);
        }
    }
}
