using UnityEngine;
using UnityEngine.UI;

public class ActionPanelToggle : MonoBehaviour
{
    Toggle t;
    private TrainMovement tm;

    Slider s;

    void Start()
    {
        //Fetch the Toggle GameObject
        t = GetComponentInChildren<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        t.onValueChanged.AddListener(delegate {
            ToggleValueChanged(t);
        });

        s = GetComponentInChildren<Slider>();
        //Add listener for when the state of the Toggle changes, to take action
        s.onValueChanged.AddListener(delegate {
            SliderValueChanged();
        });
        //its used because there is only one train movement script in the scene
        tm = FindObjectOfType<TrainMovement>();
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged(Toggle change)
    {
        //Activate your game object
        tm.ChangeBrake();
    }

    void SliderValueChanged()
    {
        //Activate your game object
        tm.ChangeMaxSpeed(s.value);
    }
}
