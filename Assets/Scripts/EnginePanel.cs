using UnityEngine;
using UnityEngine.UI;

public class EnginePanel : MonoBehaviour
{
    Toggle t;
    private TrainMovement tm;

    Slider throttle;

    void Start()
    {

        throttle = GetComponentInChildren<Slider>();
        //Add listener for when the state of the Toggle changes, to take action
        throttle.onValueChanged.AddListener(delegate {
            SliderValueChanged();
        });
        //its used because there is only one train movement script in the scene
        tm = FindObjectOfType<TrainMovement>();
    }

    //Output the new state of the Toggle into Text
    //void ToggleValueChanged(Toggle change)
    //{
        //Activate your game object
       // tm.ChangeBrake();
    //}

    void SliderValueChanged()
    {
       tm.ChangeThrottle(throttle.value); 
    }
}
