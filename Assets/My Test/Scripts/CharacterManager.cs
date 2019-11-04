using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] characters;
    public List<GameObject> actorsList = new List<GameObject>();
    [SerializeField]
    Vector3 leftActorPosition, rightActorPosition;

    List<Actor> activeActors = new List<Actor>();
    

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < characters.Length; i++)
        {
            GameObject newActor = Instantiate(characters[i]);
            newActor.SetActive(false);
            newActor.name = characters[i].name;
            actorsList.Add(newActor);
        //newActor.GetComponent<Actor>().ID = 
        }
    }
    public void PlaceActors(string leftActorName, string rightActorName)
    {

        foreach (GameObject g0 in actorsList)
        {
            if(g0.name == leftActorName)
            {
                g0.SetActive(true);
                g0.GetComponent<Actor>().ID = 0;
                activeActors.Add(g0.GetComponent<Actor>());
                g0.transform.position = leftActorPosition;
            }else if (g0.name == rightActorName)
            {
                g0.SetActive(true);
                g0.GetComponent<Actor>().ID = 1;
                activeActors.Add(g0.GetComponent<Actor>());
                g0.transform.position = rightActorPosition;
            }

        }
    }

    public void ChangeActorEmotion(string emotion, int ID)
    {
        foreach (Actor actor in activeActors)
        {
            if (actor.gameObject.activeInHierarchy)
            {
                if (actor.ID == ID)
                {
                    actor.ChangeState(emotion);
                }
            }
        }
    }
}
