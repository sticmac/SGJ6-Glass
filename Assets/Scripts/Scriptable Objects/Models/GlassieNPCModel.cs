using System;
using UnityEngine;
using Sticmac.ObservableModels;

[Serializable]
public class GlassieNPC
{
    private Character _character;
    private Dialog _dialog;
    private Accusation _accusation;

    public GlassieNPC(Character character, Dialog dialog, Accusation accusation)
    {
        _character = character;
        _dialog = dialog;
        _accusation = accusation;
    }

    public Character Character => _character;
    public Dialog Dialog => _dialog;
    public Accusation Accusation => _accusation;
}

[CreateAssetMenu(fileName = "Glassie NPC Model", menuName = "Observable Models/Customs/Glassie NPC", order = 0)]
public class GlassieNPCModel : ObservableModel<GlassieNPC> {}
