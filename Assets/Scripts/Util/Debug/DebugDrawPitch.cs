using UnityEngine;

public class DebugDrawPitch : MonoBehaviour 
{
    #region Data
    private struct PitchPoints
    {
        public Vector3 LeftUP;
        public Vector3 LeftDown;
        public Vector3 RightUP;
        public Vector3 RightDown;
        public Vector3 HorCenterUp;
        public Vector3 HorCenterDown;
        public Vector3 Center;

    }
    #endregion

    private PitchPoints _points;
    private Vector2 _size;
    private bool _isInit;
    

    public void Init(Vector2 size)
    {
        _size = size;
        var height = 0.025f;

        _points = new PitchPoints()
        {
            LeftUP = new Vector3(-size.x / 2f, height, size.y / 2f),
            LeftDown = new Vector3(-size.x / 2f, height, -size.y / 2f),
            RightUP = new Vector3(size.x / 2f, height, size.y / 2f),
            RightDown = new Vector3(size.x / 2f, height, -size.y / 2f),

            HorCenterUp = new Vector3(0f, height, size.y / 2f),
            HorCenterDown = new Vector3(0f, height, -size.y / 2f),

            Center = Vector3.zero + Vector3.up * height
        };

        _isInit = true;
    }


    private void OnDrawGizmos() 
    {
        if (!_isInit) return;

        Gizmos.DrawLine(_points.LeftUP, _points.RightUP);
        Gizmos.DrawLine(_points.RightUP, _points.RightDown);
        Gizmos.DrawLine(_points.RightDown, _points.LeftDown);
        Gizmos.DrawLine(_points.LeftDown, _points.LeftUP);  

        Gizmos.DrawLine(_points.HorCenterUp, _points.HorCenterDown);  

        Gizmos.DrawWireSphere(_points.Center, _size.x * 0.1f);  
    }
}