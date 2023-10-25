using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] private DialogueContent[] dialogue;
    [SerializeField] private Response[] responses;
    public DialogueContent[] Dialogue => dialogue;

    public bool HasResponses => Responses != null && Responses.Length > 0;
    

    public Response[] Responses => responses;

}
