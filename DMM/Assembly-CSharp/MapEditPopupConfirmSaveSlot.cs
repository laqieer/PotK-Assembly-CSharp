﻿// Decompiled with JetBrains decompiler
// Type: MapEditPopupConfirmSaveSlot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class MapEditPopupConfirmSaveSlot : MonoBehaviour
{
  [SerializeField]
  private UIButton btnOK_;
  [SerializeField]
  private UIButton btnNG_;
  [SerializeField]
  private UIButton btnChangeSlot_;
  [SerializeField]
  private UILabel txtMessage_;

  public static IEnumerator show(
    int slotId,
    int defaultId,
    bool isModified,
    System.Action eventOK,
    System.Action eventNG,
    System.Action eventChangeSlot)
  {
    Future<GameObject> ldprefab = MapEdit.Prefabs.popup_confirm_save_slot.Load<GameObject>();
    IEnumerator e = ldprefab.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if ((UnityEngine.Object) ldprefab.Result == (UnityEngine.Object) null)
    {
      eventNG();
    }
    else
    {
      GameObject go = Singleton<PopupManager>.GetInstance().open(ldprefab.Result);
      MapEditPopupConfirmSaveSlot component = go.GetComponent<MapEditPopupConfirmSaveSlot>();
      bool bWait = true;
      EventDelegate.Set(component.btnOK_.onClick, (EventDelegate.Callback) (() =>
      {
        if (!bWait)
          return;
        bWait = false;
        eventOK();
      }));
      EventDelegate.Set(component.btnNG_.onClick, (EventDelegate.Callback) (() =>
      {
        if (!bWait)
          return;
        bWait = false;
        eventNG();
      }));
      EventDelegate.Set(component.btnChangeSlot_.onClick, (EventDelegate.Callback) (() =>
      {
        if (!bWait)
          return;
        bWait = false;
        eventChangeSlot();
      }));
      Consts instance = Consts.GetInstance();
      Hashtable hashtable = new Hashtable()
      {
        {
          (object) "name",
          (object) instance.SAVE_SLOT_NAME
        },
        {
          (object) "num",
          (object) (slotId + 1)
        }
      };
      string text = Consts.Format(instance.MAPEDIT_031_MESSAGE_CONFIRM_SAVESLOT, (IDictionary) hashtable);
      if (slotId == defaultId)
        text += instance.MAPEDIT_031_NOTE_DEFAULTSLOT;
      if (isModified)
        text += instance.MAPEDIT_031_NOTE_MODIFIED;
      component.txtMessage_.SetTextLocalize(text);
      while (bWait)
        yield return (object) null;
      Singleton<PopupManager>.GetInstance().onDismiss();
      while (go.activeSelf)
        yield return (object) null;
    }
  }
}
