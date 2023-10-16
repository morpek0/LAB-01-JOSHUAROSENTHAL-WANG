using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public List<GameObject> lookPath;
    
    [SerializeField]
    public bool isMenu = false;
    public List<Waypoint> path;
    public MenuState menuState;

    public GameObject prefab;
    public int currentPointIndex = 0;

    public List<GameObject> prefabPoints;

    private void Start()
    {
        prefabPoints = new List<GameObject>();

        if (isMenu)
        {

        }
        else
        {
            foreach (Waypoint p in path)
            {
                GameObject go = Instantiate(prefab);
                go.transform.position = p.pos;
                prefabPoints.Add(go);
            }
        }
    }

    private void Update()
    {
        if (!isMenu)
        {
            for (int i = 0; i < path.Count; i++)
            {
                Waypoint p = path[i];
                GameObject g = prefabPoints[i];
                g.transform.position = p.pos;
            }
        }
        else
        {
            Waypoint p = path[menuState.stateValue];
        }
    }

    public List<Waypoint> GetPath()
    {
        if (path==null)
            path = new List<Waypoint>();
        return path;
    }
    public List<GameObject> GetLookPath()
    {
        if (lookPath == null)
            lookPath = new List<GameObject>();
        return lookPath;
    }

    public void CreateAddPoint()
    {
        Waypoint go = new Waypoint();
        path.Add(go);
    }

    public Waypoint GetNextTarget()
    {
        int nextPointIndex = (currentPointIndex+1)%(path.Count);
        currentPointIndex = nextPointIndex;
        return path[nextPointIndex];
    }

    public Waypoint GetMenuStateTarget()
    {
        int targetIndex = menuState.stateValue;
        currentPointIndex = targetIndex;
        return path[targetIndex];
    }
    public GameObject GetMenuStateLookTarget()
    {
        int targetIndex = menuState.stateValue;
        currentPointIndex = targetIndex;
        return lookPath[targetIndex];
    }
}
