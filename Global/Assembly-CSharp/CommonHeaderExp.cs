// Decompiled with JetBrains decompiler
// Type: CommonHeaderExp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class CommonHeaderExp : CommonHeaderBase
{
  private GameObject popupPlayerStatus;
  [SerializeField]
  private Transform popupState;
  private UIWidget popupStateWidget;
  private TweenAlpha popupAnimation;
  private UILabel nextExp;
  private UILabel nowLv;
  private UILabel UnitCount;
  private UILabel ItemCount;
  private bool createPrefab;

  private void Awake()
  {
    this.nextExp = (UILabel) null;
    this.nowLv = (UILabel) null;
    this.createPrefab = false;
    this.popupStateWidget = ((Component) this.popupState).GetComponent<UIWidget>();
    this.popupAnimation = ((Component) this.popupState).GetComponent<TweenAlpha>();
    this.StartCoroutine(this.CreatePrefab());
  }

  private void Start() => this.Init();

  private void OnPress(bool isDown)
  {
    if (isDown)
    {
      this.SetTextNextExpToNowLv();
      this.AnimSet(1f);
    }
    else
      this.AnimSet(0.0f);
  }

  [DebuggerHidden]
  private IEnumerator CreatePrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CommonHeaderExp.\u003CCreatePrefab\u003Ec__Iterator8CB()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void SetItemCount(int now_itemCount = 0, int max_ItemCount = 0)
  {
    this.ItemCount.SetTextLocalize(Consts.Lookup("HEADER_POPUP_ITEM_COUNT", (IDictionary) new Hashtable()
    {
      {
        (object) "now",
        (object) now_itemCount
      },
      {
        (object) "max",
        (object) max_ItemCount
      }
    }));
  }

  private void SetUnitCount(int now_UnitCount = 0, int max_UnitCount = 0)
  {
    this.UnitCount.SetTextLocalize(Consts.Lookup("HEADER_POPUP_UNIT_COUNT", (IDictionary) new Hashtable()
    {
      {
        (object) "now",
        (object) now_UnitCount
      },
      {
        (object) "max",
        (object) max_UnitCount
      }
    }));
  }

  private void AnimSet(float to)
  {
    if (Object.op_Equality((Object) this.popupAnimation, (Object) null) || Object.op_Equality((Object) this.popupStateWidget, (Object) null))
    {
      Debug.LogWarning((object) "初期化できてない");
    }
    else
    {
      this.popupAnimation.to = to;
      ((Behaviour) this.popupAnimation).enabled = false;
      this.popupAnimation.from = this.popupStateWidget.alpha;
      this.popupAnimation.duration = Mathf.Abs(this.popupAnimation.to - this.popupAnimation.from) / 4f;
      this.popupAnimation.ResetToBeginning();
      ((Behaviour) this.popupAnimation).enabled = true;
    }
  }

  private void SetTextNextExpToNowLv()
  {
    if (Object.op_Equality((Object) this.nextExp, (Object) null) || Object.op_Equality((Object) this.nowLv, (Object) null) || Player.Current == null)
    {
      Debug.LogWarning((object) "初期化できてない");
    }
    else
    {
      this.nextExp.SetTextLocalize(Player.Current.exp_next.ToString());
      this.nowLv.SetTextLocalize(Player.Current.level.ToString());
    }
  }

  protected override void Update()
  {
    if (Object.op_Equality((Object) this.ap, (Object) null) || Object.op_Equality((Object) this.bp, (Object) null) || !this.createPrefab || this.player.Value == null)
      return;
    base.Update();
    this.UpdateApRecoveryTime();
    this.UpdateBpReocveryTime();
    if (this.UpdateUnits() && this.units.Value != null)
      this.SetUnitCount(this.units.Value.Length, this.player.Value.max_units);
    if (this.UpdateItems() && this.items.Value != null)
      this.SetItemCount(this.items.Value.Length, this.player.Value.max_items);
    if (!this.UpdateApGauge() || this.units.Value == null || this.items.Value == null)
      return;
    this.bp.setValue(this.player.Value.bp);
    this.SetUnitCount(this.units.Value.Length, this.player.Value.max_units);
    this.SetItemCount(this.items.Value.Length, this.player.Value.max_items);
  }
}
