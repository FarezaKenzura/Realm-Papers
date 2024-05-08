using System;

using PaperRealms.UI.Dialogue;

public static partial class EventManager
{
    public static Action<DialogueSO> OnDialogueStart;
    public static Action OnDialogueEnd;
    public static Action OnSentenceDialogueEnd;
}