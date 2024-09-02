// Decompiled with JetBrains decompiler
// Type: Guild02841Popup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild02841Popup : BackButtonMenuBase
{
  private System.Action act;
  private int titleID;
  [SerializeField]
  private UILabel popupTitle;
  [SerializeField]
  private UILabel description;
  [SerializeField]
  private UI2DSprite titleImage;
  [SerializeField]
  private GameObject objUnknown;
  [SerializeField]
  private GameObject btnSetTitle;
  [SerializeField]
  private GameObject btnRemoveTitle;
  [SerializeField]
  private GameObject btnClose;
  [SerializeField]
  private GameObject slc_Popupbox;
  [SerializeField]
  [Header("Dlg size")]
  private Vector2 standardDlgSize;
  [SerializeField]
  private Vector2 noDecideBtnDlgSize;

  [DebuggerHidden]
  public IEnumerator Initialize(int id, string txt, bool hasEmblem, bool isCur, System.Action act)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02841Popup.\u003CInitialize\u003Ec__Iterator6DE()
    {
      act = act,
      id = id,
      txt = txt,
      hasEmblem = hasEmblem,
      isCur = isCur,
      \u003C\u0024\u003Eact = act,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Etxt = txt,
      \u003C\u0024\u003EhasEmblem = hasEmblem,
      \u003C\u0024\u003EisCur = isCur,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator EmblemSetAPI(int ID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02841Popup.\u003CEmblemSetAPI\u003Ec__Iterator6DF()
    {
      ID = ID,
      \u003C\u0024\u003EID = ID,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator EmblemUnsetAPI()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02841Popup.\u003CEmblemUnsetAPI\u003Ec__Iterator6E0()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateSprite()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02841Popup.\u003CCreateSprite\u003Ec__Iterator6E1()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();

  public void onChangeTitleButton() => this.StartCoroutine(this.EmblemSetAPI(this.titleID));

  public void onRemoveButton() => this.StartCoroutine(this.EmblemUnsetAPI());
}
