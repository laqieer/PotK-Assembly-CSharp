// Decompiled with JetBrains decompiler
// Type: Quest002171PopupBanner
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest002171PopupBanner : MonoBehaviour
{
  [SerializeField]
  private FloatButton BtnFormation;
  [SerializeField]
  private UI2DSprite IdleSprite;
  [SerializeField]
  private UI2DSprite PressSprite;
  [SerializeField]
  private UIButton button;
  private Quest002171Scroll scrollcomp;

  public void SetBtnFormationEnable(bool active)
  {
    ((Collider) ((Component) this.BtnFormation).GetComponent<BoxCollider>()).enabled = active;
  }

  [DebuggerHidden]
  public IEnumerator InitScroll(
    bool isScroll,
    bool isAtlas,
    PlayerQuestGate gate,
    Quest002171Scroll scrollcomp)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171PopupBanner.\u003CInitScroll\u003Ec__Iterator228()
    {
      scrollcomp = scrollcomp,
      gate = gate,
      \u003C\u0024\u003Escrollcomp = scrollcomp,
      \u003C\u0024\u003Egate = gate,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetSprite(int id, UI2DSprite idle, UI2DSprite press)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171PopupBanner.\u003CSetSprite\u003Ec__Iterator229()
    {
      id = id,
      idle = idle,
      press = press,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Eidle = idle,
      \u003C\u0024\u003Epress = press,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetSprite(int id, UISprite sprite, PlayerQuestGate gate)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171PopupBanner.\u003CSetSprite\u003Ec__Iterator22A()
    {
      gate = gate,
      \u003C\u0024\u003Egate = gate,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateSprite(string path, UI2DSprite obj)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest002171PopupBanner.\u003CCreateSprite\u003Ec__Iterator22B()
    {
      path = path,
      obj = obj,
      \u003C\u0024\u003Epath = path,
      \u003C\u0024\u003Eobj = obj
    };
  }

  private void SetScrollButtonCondition(PlayerQuestGate gate)
  {
    PlayerQuestGate[] tmp = new PlayerQuestGate[1]{ gate };
    EventDelegate.Set(this.BtnFormation.onClick, (EventDelegate.Callback) (() =>
    {
      Singleton<PopupManager>.GetInstance().onDismiss();
      this.scrollcomp.StartQuestReleasePopup(tmp);
    }));
    EventDelegate.Set(this.BtnFormation.onOver, (EventDelegate.Callback) (() => this.onOver(((Component) this).gameObject)));
    EventDelegate.Set(this.BtnFormation.onOut, (EventDelegate.Callback) (() => this.onOut(((Component) this).gameObject)));
  }

  private void onOver(GameObject obj)
  {
    ((Component) obj.GetComponent<Quest002171PopupBanner>().IdleSprite).gameObject.SetActive(false);
    ((Component) obj.GetComponent<Quest002171PopupBanner>().PressSprite).gameObject.SetActive(true);
  }

  private void onOut(GameObject obj)
  {
    ((Component) obj.GetComponent<Quest002171PopupBanner>().IdleSprite).gameObject.SetActive(true);
    ((Component) obj.GetComponent<Quest002171PopupBanner>().PressSprite).gameObject.SetActive(false);
  }
}
