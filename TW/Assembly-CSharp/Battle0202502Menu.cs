// Decompiled with JetBrains decompiler
// Type: Battle0202502Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle0202502Menu : NGMenuBase
{
  private const float LINK_WIDTH = 136f;
  private const float LINK_DEFWIDTH = 136f;
  private const float scale = 1f;
  [SerializeField]
  protected UILabel TxtFriendName;
  [SerializeField]
  protected UILabel TxtGetPoint;
  [SerializeField]
  protected UILabel TxtPopuptitle26;
  [SerializeField]
  private GameObject linkChar;
  [SerializeField]
  public UIButton OK;
  [SerializeField]
  protected UI2DSprite Emblem;
  [SerializeField]
  protected GameObject slc_Friend;
  [SerializeField]
  protected GameObject slc_Guild;

  [DebuggerHidden]
  public IEnumerator Init(PlayerHelper helper, int incr_friend_point)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle0202502Menu.\u003CInit\u003Ec__Iterator901()
    {
      helper = helper,
      incr_friend_point = incr_friend_point,
      \u003C\u0024\u003Ehelper = helper,
      \u003C\u0024\u003Eincr_friend_point = incr_friend_point,
      \u003C\u003Ef__this = this
    };
  }

  public void SetText(string name, int point)
  {
    this.TxtFriendName.SetTextLocalize(name);
    this.TxtGetPoint.SetTextLocalize(Consts.Format(Consts.GetInstance().FRIEND_REQUEST_POPUPBASE, (IDictionary) new Hashtable()
    {
      {
        (object) nameof (point),
        (object) point
      }
    }));
  }

  public virtual void IbtnPopupOk() => Singleton<PopupManager>.GetInstance().dismiss();

  [DebuggerHidden]
  private IEnumerator SetEmblem(int emblemId)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle0202502Menu.\u003CSetEmblem\u003Ec__Iterator902()
    {
      emblemId = emblemId,
      \u003C\u0024\u003EemblemId = emblemId,
      \u003C\u003Ef__this = this
    };
  }
}
