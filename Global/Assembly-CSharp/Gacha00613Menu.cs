// Decompiled with JetBrains decompiler
// Type: Gacha00613Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Gacha00613Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  public Gacha00613Scene Scene;
  public List<Transform> SpriteList;
  public List<GameObject> IconList;
  private bool isBtnAction = true;

  public bool IsBtnAction => this.isBtnAction;

  public void BtnActionEnable(bool enable)
  {
    this.isBtnAction = enable;
    foreach (GameObject icon in this.IconList)
    {
      Transform child = icon.transform.FindChild("button");
      if (Object.op_Inequality((Object) child, (Object) null))
        ((Component) child).gameObject.SetActive(enable);
    }
    Singleton<CommonRoot>.GetInstance().SetFooterEnable(this.isBtnAction);
  }

  public void IbtnBack()
  {
    if (!this.isBtnAction || this.IsPushAndSet())
      return;
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  [DebuggerHidden]
  public IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00613Menu.\u003ConEndSceneAsync\u003Ec__Iterator361()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator CreateGetListAsync(GachaResultData.ResultData resultData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00613Menu.\u003CCreateGetListAsync\u003Ec__Iterator362()
    {
      resultData = resultData,
      \u003C\u0024\u003EresultData = resultData,
      \u003C\u003Ef__this = this
    };
  }

  public void SetEvent(UnitIcon UI, MonoBehaviour target)
  {
    UI.button.onLongPress.Clear();
    UI.button.onLongPress.Add(new EventDelegate(target, "IbtnIcon"));
    UI.button.onClick.Clear();
    UI.button.onClick.Add(new EventDelegate(target, "IbtnIcon"));
  }

  public void SetEvent(ItemIcon II, MonoBehaviour target)
  {
    II.gear.button.onLongPress.Clear();
    II.gear.button.onLongPress.Add(new EventDelegate(target, "IbtnIcon"));
    II.gear.button.onClick.Clear();
    II.gear.button.onClick.Add(new EventDelegate(target, "IbtnIcon"));
  }
}
