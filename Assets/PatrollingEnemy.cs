namespace Assets
{
    using UnityEngine;

    using UnityStandardAssets._2D;

    [RequireComponent(typeof(PlatformerCharacter2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PatrollingEnemy : MonoBehaviour
    {
        #region Fields

        public Vector3 PatrolLeft = new Vector3(0, 0, 0);

        public Vector3 PatrolRight = new Vector3(0, 0, 0);

        private int direction = 1;

        private PlatformerCharacter2D platformerCharacter2D;

        private new Rigidbody2D rigidbody2D;

        #endregion

        #region Methods

        //INITIALIZE THE RIGIDBODY AND PLATFORMCHARACTER OBJECTS
        private void Awake()
        {
            platformerCharacter2D = GetComponent<PlatformerCharacter2D>();
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        //WHEN A COLLISION HAS OCCURED WITH ANYTHING OTHER THAN THE GROUND TURN AROUND
        //TODO: MODIFY THIS TO NOT TURN AROUND WHEN CONTACT WITH A PLAYER IS MADE
        private void OnCollisionEnter2D(Collision2D other)
        {
            rigidbody2D.velocity = Vector2.zero;
            if (other.gameObject.layer != LayerMask.NameToLayer("Ground"))
            {
                direction *= -1;
                platformerCharacter2D.Move(direction, false, false);
            }
        }

        //PLACE GIZMOS IN THE VIEWING AREA SO WE KNOW WHERE THE ENEMY WILL PATROL
        //TODO: ONLY DISPLAY THE GIZMOS IF THE ENEMY IS SELECTED IN THE EDITOR??
        private void OnDrawGizmos()
        {
            Vector3 gizmoSize = new Vector3(.5f, 1.5f, .5f);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(PatrolLeft, gizmoSize);
            Gizmos.DrawWireCube(PatrolRight, gizmoSize);
        }

        //DETERMINE WHAT DIRECTION THE ENEMY SHOULD WALK BASED ON THEIR CURRENT LOCATION
        private void Update()
        {
            if (rigidbody2D.position.x <= PatrolLeft.x) direction = 1;
            if (rigidbody2D.position.x >= PatrolRight.x) direction = -1;

            platformerCharacter2D.Move(direction, false, false);
        }

        #endregion
    }
}