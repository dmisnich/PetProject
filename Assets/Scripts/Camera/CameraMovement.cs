using UnityEngine;

namespace Camera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Transform cameraTransform;
        
        private const float SmoothSpeed = 0.125f;
        private Vector3 _offset;

        private void Start()
        {
            _offset = cameraTransform.position - targetTransform.position;
        }

        private void LateUpdate()
        {
            CameraMoving();
        }

        private void CameraMoving()
        {
            Vector3 targetPosition = targetTransform.position + _offset;
            Vector3 position = cameraTransform.position;
            Vector3 smoothedPosition = Vector3.Lerp(position, targetPosition, SmoothSpeed);
            
            cameraTransform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, position.z);;
        }
    }
}