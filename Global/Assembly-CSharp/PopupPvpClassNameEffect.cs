// Decompiled with JetBrains decompiler
// Type: PopupPvpClassNameEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using UnityEngine;

#nullable disable
public class PopupPvpClassNameEffect : MonoBehaviour
{
  [SerializeField]
  private UILabel txtDescription;
  [SerializeField]
  private UILabel txtDescription2;

  public void Init(PvpClassKind classData, PvpClassKind.Condition condition)
  {
    this.SetDescription(classData, condition);
  }

  private void SetDescription(PvpClassKind classData, PvpClassKind.Condition condition)
  {
    string text = string.Empty;
    string name = classData.name;
    switch (condition)
    {
      case PvpClassKind.Condition.DOWN:
        if (classData.PreviousClass != null)
          name = classData.PreviousClass.name;
        text = Consts.Lookup("VERSUS_002689POPUP_DESCRIPTION_DOWN");
        break;
      case PvpClassKind.Condition.STAY:
        text = Consts.Lookup("VERSUS_002689POPUP_DESCRIPTION_STAY");
        break;
      case PvpClassKind.Condition.STAY_TOPCLASS:
      case PvpClassKind.Condition.TITLE_TOPCLASS:
        text = Consts.Lookup("VERSUS_002689POPUP_DESCRIPTION_TOP");
        break;
      case PvpClassKind.Condition.UP:
      case PvpClassKind.Condition.TITLE:
        if (classData.NextClass != null)
          name = classData.NextClass.name;
        text = Consts.Lookup("VERSUS_002689POPUP_DESCRIPTION_UP");
        break;
    }
    this.txtDescription.SetText(Consts.Lookup("VERSUS_002689POPUP_DESCRIPTION_NAME", (IDictionary) new Hashtable()
    {
      {
        (object) "name",
        (object) name
      }
    }));
    this.txtDescription2.SetText(text);
  }
}
