using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GroundComponent : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private PolygonCollider2D GroundCollider;
    [SerializeField] private MeshCollider GeneratedMeshCollider;
    [SerializeField] private Mesh GeneratedMesh;

    #endregion

    private void FixedUpdate()
    {
        MakeHole();
    }

    private async UniTask MakeHole()
    {
        await UniTask.Delay(25);
        List<HoleComponent> Holes = LevelComponent.Instance.GetHoles().ToList();
        List<Vector2[]> PointPositions = new List<Vector2[]>();
        int counter = 0;
        GroundCollider.pathCount = Holes.Count + 1;
        for (int i = 0; i < Holes.Count; i++)
        {
            PointPositions.Add(Holes[i].GetCollider().GetPath(0));
            Vector2[] PointPosition = Holes[i].GetCollider().GetPath(0);
            for (int j = 0; j < PointPosition.Length; j++)
            {
                // PointPosition[j] += (Vector2)Holes[i].transform.position;
                PointPosition[j] += new Vector2(Holes[i].transform.position.x, Holes[i].transform.position.z);
            }

            counter++;
            GroundCollider.SetPath(counter, PointPosition);
        }
    }
}