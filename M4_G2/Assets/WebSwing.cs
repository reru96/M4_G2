using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSwing : MonoBehaviour
{

    public LayerMask webAttachablelayer;
    public float maxDistance = 50f;
    public LineRenderer lineRenderer;
    public Transform cameraTransform;

    private SpringJoint joint;
    private Rigidbody rb;
    private Vector3 webAnchor;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if( Input.GetMouseButtonDown(0))
        {
            TryAttachWeb();
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            DetachWeb();
        }

        DrawWebLine();
    }

    void TryAttachWeb()
    {
        RaycastHit hit;
        Vector3 rayOrigin = transform.position + Vector3.up * 1.5f;
        Vector3 rayDirection = transform.forward;

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, maxDistance, webAttachablelayer))
        {
            webAnchor = hit.point;

            joint = gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = webAnchor;

            float distanceFromPoint = Vector3.Distance(transform.position, webAnchor);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 10f;
            joint.damper = 5f;
            joint.massScale = 4.5f;
        }

            // Inizializza LineRenderer
            if (lineRenderer)
            {
                lineRenderer.positionCount = 2;
            }
        
    }

    void DetachWeb()
    {
        if (joint != null)
        {
            Destroy(joint);
            rb.velocity += transform.forward * 10f;
        }

        if (lineRenderer)
        {
            lineRenderer.positionCount = 0;
        }
    }

    void DrawWebLine()
    {
        if (joint != null && lineRenderer != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, webAnchor);
        }
    }

    private void FixedUpdate()
    {
        if (joint != null)
        {
            Vector3 swingDirection = transform.forward + transform.right * Input.GetAxis("Horizontal");
            rb.AddForce(swingDirection * 20f);
        }
    }
}
