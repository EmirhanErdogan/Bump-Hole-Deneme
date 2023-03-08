using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleComponent : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private PolygonCollider2D HoleCollider2D;

    #endregion


    private void FixedUpdate()
    {
        Reset2DColliderPos();
    }

    private void Reset2DColliderPos()
    {
        if (transform.hasChanged is true)
        {
            transform.hasChanged = false;
            HoleCollider2D.transform.position = new Vector2(transform.position.x, transform.position.z);
        }
    }

    #region Getters

    public PolygonCollider2D GetCollider()
    {
        return HoleCollider2D;
    }

    #endregion
}