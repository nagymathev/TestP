using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    private LineRenderer lr;

    private PlayerMovement pmComponent;
    private GameObject playerobject;

    public Transform player;
    public Transform target;

    Color c1 = Color.yellow;
    Color c2 = Color.red;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        pmComponent = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        playerobject = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        lr.startColor = c1;
        lr.endColor = c2;
        lr.material.color = c2;
    }

    private void Update()
    {

        player = playerobject.transform;
        target = pmComponent.target;

        lr.SetPosition(0, player.position);
        lr.SetPosition(1, target.position);
    }
}
