using UnityEditor;

using UnityEngine;

namespace Assets
{
    [CustomEditor(typeof(PatrollingEnemy))]
    [CanEditMultipleObjects]
    public class PatrollingEnemyEditor : Editor
    {
        #region Methods

        protected virtual void OnSceneGUI()
        {
            //HANDLE TO THE TARGET OF THE OBJECT THE HANDLES WILL MODIFY
            PatrollingEnemy patrollingEnemy = (PatrollingEnemy)target;

            EditorGUI.BeginChangeCheck();

            //CREATE A HANDLE FOR EACH THE LEFT AND RIGHT SIDE OF THE ENEMY PATROL
            Vector3 newLeftPosition = Handles.PositionHandle(patrollingEnemy.PatrolLeft, Quaternion.identity);
            Vector3 newRightPosition = Handles.PositionHandle(patrollingEnemy.PatrolRight, Quaternion.identity);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(patrollingEnemy, "Change Enemy Patrol");

                //STORE THE LEFT AND RIGHT PATROL POSITIONS
                patrollingEnemy.PatrolLeft = newLeftPosition;
                patrollingEnemy.PatrolRight = newRightPosition;
            }
        }

        #endregion
    }
}