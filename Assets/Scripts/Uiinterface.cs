using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Uiinterface : MonoBehaviour
{
    int wood = 0;
    PlayerMovement playerMovementComponent;

    public TextMeshProUGUI woodText;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        wood = playerMovementComponent.wood;

        woodText.text = "Wood: " + wood.ToString();
    }
}
