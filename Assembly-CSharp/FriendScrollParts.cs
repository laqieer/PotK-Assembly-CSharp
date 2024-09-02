// Decompiled with JetBrains decompiler
// Type: FriendScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class FriendScrollParts : FriendScrollBar
{
  [SerializeField]
  private UILabel ApplicationAt;
  [HideInInspector]
  public Friend0085Menu menu85;
  [SerializeField]
  private SpreadColorButton yesButton;
  [SerializeField]
  private SpreadColorButton noButton;

  public void Set(Friend0085Menu menu)
  {
    this.SetApplication(this.ApplicationAt);
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || !((UnityEngine.Object) this.menu85 == (UnityEngine.Object) null))
      return;
    this.menu85 = menu;
    EventDelegate.Set(this.yesButton.onClick, new EventDelegate.Callback(this.onAccept));
    EventDelegate.Set(this.noButton.onClick, new EventDelegate.Callback(this.onDeny));
  }

  private IEnumerator openPopup0087()
  {
    FriendScrollParts friendScrollParts = this;
    Future<GameObject> prefabF = Res.Prefabs.popup.popup_008_7__anim_popup01.Load<GameObject>();
    IEnumerator e = prefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject result = prefabF.Result;
    Singleton<PopupManager>.GetInstance().open(result).GetComponent<Friend0087Menu>().Init0087PopUp(friendScrollParts.Friend.target_player_id, new System.Action(friendScrollParts.menu85.ResetScrollEvent));
  }

  public void onAccept()
  {
    if ((UnityEngine.Object) this.yesButton != (UnityEngine.Object) null)
      this.yesButton.ReturnToNormal();
    if ((UnityEngine.Object) this.noButton != (UnityEngine.Object) null)
      this.noButton.ReturnToNormal();
    if ((UnityEngine.Object) this.menu != (UnityEngine.Object) null)
    {
      if (this.menu.IsPushAndSet())
        return;
      this.StartCoroutine(this.openPopup0087());
    }
    else
      this.StartCoroutine(this.openPopup0087());
  }

  public void onDeny()
  {
    if ((UnityEngine.Object) this.yesButton != (UnityEngine.Object) null)
      this.yesButton.ReturnToNormal();
    if ((UnityEngine.Object) this.noButton != (UnityEngine.Object) null)
      this.noButton.ReturnToNormal();
    if ((UnityEngine.Object) this.menu != (UnityEngine.Object) null)
    {
      if (this.menu.IsPushAndSet())
        return;
      this.StartCoroutine(this.openPopup0089());
    }
    else
      this.StartCoroutine(this.openPopup0089());
  }

  private IEnumerator openPopup0089()
  {
    FriendScrollParts friendScrollParts = this;
    Future<GameObject> prefabF = Res.Prefabs.popup.popup_8_9__anim_popup01.Load<GameObject>();
    IEnumerator e = prefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject result = prefabF.Result;
    Friend0089Menu component = Singleton<PopupManager>.GetInstance().open(result).GetComponent<Friend0089Menu>();
    component.InitPopup(friendScrollParts.Friend.target_player_id, new System.Action(friendScrollParts.menu85.ResetScrollEvent));
    component.SetBack(false);
  }
}
