using UnityEngine;
using System.Collections;

public class RotateAndCenterHandler : MonoBehaviour
{
    public LayerMask m_onlySelectable;
    public Transform m_targetPoint;
    private RaycastHit m_rayOutput;

    [Header( "Object Movement Settings" )]
    public float m_centerDuration = .5f;
    public AnimationCurve m_smoothCurve = new AnimationCurve( new Keyframe[] { new Keyframe( 0, 0 ), new Keyframe( 1, 1 ) } );
    private WaitForSeconds m_skipFrame = new WaitForSeconds( 0.01f );

    private GameObject m_selectedObject;

    // Data for movement.
    private class MoveData
    {
        public GameObject m_objectToCenter;
        public float m_moveTimerCurrent;
        public Vector3 m_startPos;
        public Vector3 m_endPos;
        public Quaternion m_startRotation;
        public Quaternion m_endRotation;
        public bool m_shouldCheckForInterruption;
    }


    void Update()
    {
        if( Input.GetMouseButtonDown( 0 ) )
        {
            // Define Ray.
            Ray rayToMouse = Camera.main.ScreenPointToRay( Input.mousePosition );

            // Optional
            Debug.DrawRay( rayToMouse.origin, rayToMouse.direction * 1000f, Color.magenta, 3f );

            // Shoot Ray.
            if( Physics.Raycast( rayToMouse, out m_rayOutput, 1000f, m_onlySelectable ) )
            {
                GameObject hitObject = m_rayOutput.collider.gameObject;
                Debug.Log( hitObject.name ); // Optional

                // No need to move if already selected.
                if( hitObject != m_selectedObject )
                {
                    // Center hit object to screen. (without moving camera, as specifically asked for)
                    StartCoroutine( _centerObject( hitObject ) );
                }
            }
        }
    }

    private IEnumerator _centerObject( GameObject objectToCenter )
    {
        m_selectedObject = objectToCenter;

        // Store movedata.
        MoveData md = new MoveData();
        md.m_objectToCenter = objectToCenter;
        md.m_startPos = objectToCenter.transform.position;
        md.m_startRotation = objectToCenter.transform.rotation;
        md.m_endPos = m_targetPoint.position;
        md.m_endRotation = m_targetPoint.rotation;
        md.m_shouldCheckForInterruption = true;

        // Move to center.
        yield return StartCoroutine( _moveObject( md ) );

        _checkInterrupted( md );

        // Wait until no longer selected.
        while( objectToCenter == m_selectedObject )
        {
            yield return m_skipFrame;
        }

        // Invert start and end points.
        md.m_endPos = md.m_startPos;
        md.m_endRotation = md.m_startRotation;
        md.m_startPos = m_targetPoint.position;
        md.m_startRotation = m_targetPoint.rotation;
        md.m_shouldCheckForInterruption = false; // Another object has been selected, if we keep checking this, our object won't move.

        // Move back to original position and rotation.
        yield return StartCoroutine( _moveObject( md ) );
    }

    private IEnumerator _moveObject( MoveData md )
    {
        Transform selected = md.m_objectToCenter.transform;
        float current01 = 0f;
        while( md.m_moveTimerCurrent <= m_centerDuration && !_isInterrupted(md) )
        {
            // Increment
            md.m_moveTimerCurrent += Time.deltaTime;

            // Update position and rotation.
            current01 = m_smoothCurve.Evaluate( md.m_moveTimerCurrent / m_centerDuration );
            selected.position = Vector3.Lerp( md.m_startPos, md.m_endPos, current01 );
            selected.rotation = Quaternion.Lerp( md.m_startRotation, md.m_endRotation, current01 );

            // Wait a frame.
            yield return m_skipFrame;
        }
    }

    // Returns whether the current movement is being interrupted (and only if it should be checking for it)
    private bool _isInterrupted(MoveData md)
    {
        return md.m_objectToCenter != m_selectedObject && md.m_shouldCheckForInterruption;
    }

    private void _checkInterrupted( MoveData md )
    {
        if( md.m_objectToCenter != m_selectedObject )
        {
            // Start moving back starting partway there. (Happens when selecting another object before this one has reached the center)
            md.m_moveTimerCurrent = m_centerDuration - md.m_moveTimerCurrent;
        }
        else
        {
            // Start moving back from center. (Happens when another object is selected only after this one has reached the center)
            md.m_moveTimerCurrent = 0f;
        }
    }
}
