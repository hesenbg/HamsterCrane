using System.Collections.Generic;
using UnityEngine;

public class StraightTower : MonoBehaviour
{
    [SerializeField] Transform BoxParent;

    [SerializeField] float MaxTolerance;

    [SerializeField] List<Transform> transforms;

    public bool IsFinished = false;
    private void Start()
    {
        foreach(Transform t in BoxParent)
        {
            if(t!=transform)
                transforms.Add(t);
        }
    }

    private void FixedUpdate()
    {
        IsFinished = Find();
        if (IsFinished)
        {
            Debug.Log("ish");
        }
    }

    private bool Find()
    {
        float totalX = 0;

        for (int i = 0; i < transforms.Count; i++)
        {
            totalX += transforms[i].position.x;
        }

        totalX /= transforms.Count;

        for (int i = 0; i < transforms.Count; i++)
        {
            if (Mathf.Abs(transforms[i].position.x - totalX) > MaxTolerance)
                return false;
        }

        return true;
    }
}