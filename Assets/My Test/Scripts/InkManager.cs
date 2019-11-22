using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class InkManager : MonoBehaviour
{
    CharacterManager cm;
    GameManager gm;
    string currentStory;
    public Text goldText;
    static int stuff;
    public SkillManager skillz;
    void Start()
    {
        stuff = 0;
        cm = GetComponent<CharacterManager>();
        gm = GetComponent<GameManager>();
        // Remove the default message
        RemoveChildren();
        StartStory();
    }
    // Creates a new Story object with the compiled story which we can then play!
    void StartStory()
    {
        story = new Story(inkJSONAsset.text);
        story.BindExternalFunction("setGold", (int x) =>
         {
             skillz.setGold(x);
             goldText.text = "Gold: " + x;
         });
        story.BindExternalFunction("place_actors", (string leftName, string rightName) =>
         {
             cm.PlaceActors(leftName, rightName);
         });
        story.BindExternalFunction("change_emotion", (string emotion, int ID) =>
        {
            cm.ChangeActorEmotion(emotion, ID);
        });
        RefreshView();
    }

    // This is the main function called every time the story changes. It does a few things:
    // Destroys all the old content and choices.
    // Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
    void RefreshView()
    {
        // Remove all the UI on screen
        RemoveChildren();
        currentStory = "";
        // Read all the content until we can't continue any more
        while (story.canContinue)
        {
            // Continue gets the next line of the story
            string text = story.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            CreateContentView(text);
        }

        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0)
        {
            
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());
                // Tell the button what to do when we press it
                button.onClick.AddListener(delegate {
                    OnClickChoiceButton(choice);
                });
            }
        }
        // If we've read all the content and there's no choices, the story is finished!
        else
        {
            Button choice = CreateChoiceView("End of story.\nRestart?");
            choice.onClick.AddListener(delegate {
                StartStory();
            });
        }
    }

    void ReloadView()
    {
        // Remove all the UI on screen
        RemoveChildren();


        CreateContentView(currentStory);
        

        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0)
        {

            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());
                // Tell the button what to do when we press it
                button.onClick.AddListener(delegate {
                    OnClickChoiceButton(choice);
                });
            }
        }
        // If we've read all the content and there's no choices, the story is finished!
        else
        {
            Button choice = CreateChoiceView("End of story.\nRestart?");
            choice.onClick.AddListener(delegate {
                StartStory();
            });
        }
    }

    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    // Creates a button showing the choice text
    void CreateContentView(string text)
    {
        Text storyText = Instantiate(textPrefab) as Text;
        storyText.text = text;
        currentStory += text;
        storyText.transform.SetParent(canvas.transform, false);
    }

    // Creates a button showing the choice text
    Button CreateChoiceView(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(canvas.transform, false);

        // Gets the text from the button prefab
        Text choiceText = choice.GetComponentInChildren<Text>();
        choiceText.text = text;

        // Make the button expand to fit the text
        HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
        layoutGroup.childForceExpandHeight = false;

        return choice;
    }

    // Destroys all the children of this gameobject (all the UI)
    void RemoveChildren()
    {
        int childCount = canvas.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(canvas.transform.GetChild(i).gameObject);
        }
    }

    public void SaveGame()
    {
        string savedJson = story.state.ToJson();

        PlayerPrefs.SetString("inkSaveState", savedJson);

        PlayerPrefs.SetString("inkSaveStory", currentStory);
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("inkSaveState"))
        {
            var savedState = PlayerPrefs.GetString("inkSaveState");
            story.state.LoadJson(savedState);
            currentStory = PlayerPrefs.GetString("inkSaveStory");
            ReloadView();

        }

    }

   public void ClearGame()
    {
        PlayerPrefs.DeleteKey("inkSaveState");
        story.ResetState();
    }




    [SerializeField]
    private TextAsset inkJSONAsset;
    public Story story;

    [SerializeField]
    private Canvas canvas;

    // UI Prefabs
    [SerializeField]
    private Text textPrefab;
    [SerializeField]
    private Button buttonPrefab;
    
}
