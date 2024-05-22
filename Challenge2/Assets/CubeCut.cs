using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCut : MonoBehaviour
{

    public static bool Cut(Transform victim, Transform oldStack)
    {
        float oldStackScaleX = oldStack.localScale.x;
        float leftPointOldStackX = oldStack.position.x - (oldStackScaleX / 2);
        float rightPointOldStackX = oldStack.position.x + (oldStackScaleX / 2);

        bool leftOrRight = victim.position.x > oldStack.position.x;
        float cuttingPoint = leftOrRight ? rightPointOldStackX : leftPointOldStackX;
        Vector3 pos = new Vector3(cuttingPoint, victim.position.y, victim.position.z);
        float distance = Vector3.Distance(victim.position, pos);

        if (distance >= victim.localScale.x / 2) return false;

        if (Vector3.Distance(victim.position, oldStack.position) < 3.01f)
        {
            CreateCenterSide(oldStack, victim);
            return true;
        }
        else
        {
            CreateCutSides(victim, pos, leftOrRight);
            return true;
        }
    }

    private static void CreateCenterSide(Transform oldStack, Transform victim)
    {
        Material matCenter = victim.GetComponent<MeshRenderer>().material;
        GameObject centerSideObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        centerSideObj.transform.position = new Vector3(oldStack.position.x, victim.position.y, victim.position.z);
        centerSideObj.transform.localScale = oldStack.transform.localScale;
        centerSideObj.GetComponent<MeshRenderer>().material = matCenter;
        StackController.Instance.SpawnStack(oldStack.transform.localScale.x);
    }

    private static void CreateCutSides(Transform victim, Vector3 pos, bool leftOrRight)
    {
        Vector3 victimScale = victim.localScale;
        Vector3 leftPoint = victim.position - Vector3.right * victimScale.x / 2;
        Vector3 rightPoint = victim.position + Vector3.right * victimScale.x / 2;
        Material mat = victim.GetComponent<MeshRenderer>().material;

        GameObject rightSideObj = CreateSide(rightPoint, pos, victimScale, mat);
        GameObject leftSideObj = CreateSide(leftPoint, pos, victimScale, mat);

        if (leftOrRight)
        {
            rightSideObj.AddComponent<Rigidbody>().mass = 100f;
            StackController.Instance.lastSpawnedStack = leftSideObj.transform;
            StackController.Instance.SpawnStack(leftSideObj.transform.localScale.x);
        }
        else
        {
            leftSideObj.AddComponent<Rigidbody>().mass = 100f;
            StackController.Instance.lastSpawnedStack = rightSideObj.transform;
            StackController.Instance.SpawnStack(rightSideObj.transform.localScale.x);
        }
    }

    private static GameObject CreateSide(Vector3 point, Vector3 pos, Vector3 scale, Material mat)
    {
        GameObject sideObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        sideObj.transform.position = (point + pos) / 2;
        float width = Vector3.Distance(pos, point);
        sideObj.transform.localScale = new Vector3(width, scale.y, scale.z);
        sideObj.GetComponent<MeshRenderer>().material = mat;
        return sideObj;
    }
}
