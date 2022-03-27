using Enemies.Stickman;
using UnityEditor;
using UnityEngine;

namespace Enemies.Editor
{
    [CustomEditor(typeof(StickmanContol))]
    public class StickmanControlEditor : UnityEditor.Editor
    {
        private StickmanContol _control;
        private Transform _handleTransform;
        private Quaternion _handleRotation;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            ResetPoint();
        }

        private void OnEnable()
        {
            _control = (StickmanContol) target;
        }

        private void OnSceneGUI()
        {
            _handleTransform = _control.transform;
            _handleRotation = Tools.pivotRotation == PivotRotation.Local ? _handleTransform.rotation : Quaternion.identity;
            
            DrawEndPoint();
        }

        private void ResetPoint()
        {
            if (GUILayout.Button("Сбросить EndPoint"))
            {
                Undo.RecordObject(_control, "Remove end point");
                Vector3 reset = new Vector3(_handleTransform.position.x, 
                    _handleTransform.position.y,
                    _handleTransform.position.z + 2f);
                _control.EndPoint = reset;
                EditorUtility.SetDirty(_control);
            }
        }
        
        private void DrawEndPoint()
        {
            Handles.color = Color.magenta;
            
            EditorGUI.BeginChangeCheck();
            _control.EndPoint = Handles.DoPositionHandle(_control.EndPoint, _handleRotation);
            _control.EndPoint.y = _handleTransform.position.y;
            Handles.DrawLine(_control.EndPoint, _handleTransform.position);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(_control, "Move point");
                EditorUtility.SetDirty(_control);
            }
        }
    }
}