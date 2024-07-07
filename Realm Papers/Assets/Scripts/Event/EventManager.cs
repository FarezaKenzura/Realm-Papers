using System;

using PaperRealms.UI.Dialogue;

public static class EventManager
{
    public static Action<DialogueSO> OnDialogueStart;
    public static Action OnDialogueEnd;
    public static Action OnSentenceDialogueEnd;

    public static Action OnRestartLevel;
    public static Action OnExitLevel;
    public static Action<int> OnNextLevel;

    public static Action<bool> OnGamePause;

    public static Action OnMainMenuActive;
    public static Action<bool> OnMainMenuDeactivated;

    public static Action<bool> SetFade;
    public static Action OnFadeInComplete;
    public static Action OnFadeOutComplete;
}