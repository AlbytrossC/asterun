using UnityEngine;
using UnityEngine.Events;

public class NewCardManager : MonoBehaviour
{
    public UnityEvent minorFlagCardEffects;

    public void TriggerCardEffects() => minorFlagCardEffects?.Invoke();
}
