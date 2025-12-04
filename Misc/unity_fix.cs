//LATE UPDATE FIX

Vector3 currentPos = GetMousePosition;

// How much the camera needs to move
Vector3 move = _origin - currentPos;

// Apply movement
transform.position += move;

// Update origin so dragging stays continuous
_origin = currentPos;

//GetMousePosition Fix
   private Vector3 GetMousePosition
    {
        get
        {
            // 1. Get raw screen position
            Vector3 mousePos = Mouse.current.position.ReadValue();

            // 2. FIX: Determine how far the camera is from the Z=0 plane.
            // If your camera is at Z = -10, this makes the distance 10.
            float distanceToGround = Mathf.Abs(transform.position.z); 
            
            // 3. Set that as the Z depth for the conversion
            mousePos.z = distanceToGround;

            // 4. Convert
            return _mainCamera.ScreenToWorldPoint(mousePos);
        }
    }