using System.Collections;
using System.Collections.Generic;
using Emir;
using UnityEngine;

public class LevelComponent : Singleton<LevelComponent>
{
    #region Serializable Fields

    [SerializeField] private List<HoleComponent> Holes = new List<HoleComponent>();

    #endregion

    #region Getters

    public List<HoleComponent> GetHoles()
    {
        return Holes;
    }

    #endregion
}