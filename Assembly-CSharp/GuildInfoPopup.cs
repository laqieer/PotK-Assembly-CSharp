// Decompiled with JetBrains decompiler
// Type: GuildInfoPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class GuildInfoPopup
{
  public GameObject guildInfoPopup;
  public GameObject guildSendRequestPopup;
  public GameObject guildSendRequestResultPopup;
  public GameObject guildCancelRequestPopup;
  public GameObject guildCancelRequestResultPopup;
  public GameObject guildStatementPopup;
  public GameObject guildNgWordPopup;
  public GameObject guildFriendListPopup;
  public GameObject guildFriendListParts;
  private System.Action sendRequestCallback;
  private System.Action cancelRequestCallback;
  private System.Action requestMaintenanceCallback;
  private System.Action requestAlreadyGuildCallback;

  public IEnumerator ResourceLoad()
  {
    Future<GameObject> fgObj;
    IEnumerator e;
    if ((UnityEngine.Object) this.guildInfoPopup == (UnityEngine.Object) null)
    {
      fgObj = Res.Prefabs.popup.popup_028_1_1_4__anim_popup01.Load<GameObject>();
      e = fgObj.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.guildInfoPopup = fgObj.Result;
      fgObj = (Future<GameObject>) null;
    }
    if ((UnityEngine.Object) this.guildSendRequestPopup == (UnityEngine.Object) null)
    {
      fgObj = Res.Prefabs.popup.popup_028_1_1_5__anim_popup01.Load<GameObject>();
      e = fgObj.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.guildSendRequestPopup = fgObj.Result;
      fgObj = (Future<GameObject>) null;
    }
    if ((UnityEngine.Object) this.guildSendRequestResultPopup == (UnityEngine.Object) null)
    {
      fgObj = Res.Prefabs.popup.popup_028_1_1_5_1__anim_popup01.Load<GameObject>();
      e = fgObj.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.guildSendRequestResultPopup = fgObj.Result;
      fgObj = (Future<GameObject>) null;
    }
    if ((UnityEngine.Object) this.guildCancelRequestPopup == (UnityEngine.Object) null)
    {
      fgObj = Res.Prefabs.popup.popup_028_1_1_6__anim_popup01.Load<GameObject>();
      e = fgObj.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.guildCancelRequestPopup = fgObj.Result;
      fgObj = (Future<GameObject>) null;
    }
    if ((UnityEngine.Object) this.guildCancelRequestResultPopup == (UnityEngine.Object) null)
    {
      fgObj = Res.Prefabs.popup.popup_028_1_1_6_1__anim_popup01.Load<GameObject>();
      e = fgObj.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.guildCancelRequestResultPopup = fgObj.Result;
      fgObj = (Future<GameObject>) null;
    }
    if ((UnityEngine.Object) this.guildStatementPopup == (UnityEngine.Object) null)
    {
      fgObj = Res.Prefabs.popup.popup_028_1_1_7__anim_popup01.Load<GameObject>();
      e = fgObj.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.guildStatementPopup = fgObj.Result;
      fgObj = (Future<GameObject>) null;
    }
    if ((UnityEngine.Object) this.guildNgWordPopup == (UnityEngine.Object) null)
    {
      fgObj = Res.Prefabs.popup.popup_028_guild_ng_word__anim_popup01.Load<GameObject>();
      e = fgObj.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.guildNgWordPopup = fgObj.Result;
      fgObj = (Future<GameObject>) null;
    }
    int num1 = (UnityEngine.Object) this.guildFriendListPopup == (UnityEngine.Object) null ? 1 : 0;
    int num2 = (UnityEngine.Object) this.guildFriendListParts == (UnityEngine.Object) null ? 1 : 0;
  }

  public System.Action SendRequestCallback => this.sendRequestCallback;

  public System.Action CancelRequeestCallback => this.cancelRequestCallback;

  public void SetSendRequestCallback(System.Action action) => this.sendRequestCallback = action;

  public void SetCancelRequestCallback(System.Action action) => this.cancelRequestCallback = action;

  public System.Action RequestMaintenanceCallback => this.requestMaintenanceCallback;

  public void SetRequestMaintenanceCallback(System.Action action) => this.requestMaintenanceCallback = action;

  public System.Action RequestAlreadyGuildCallback => this.requestAlreadyGuildCallback;

  public void SetRequestAlreadyGuildCallback(System.Action action) => this.requestAlreadyGuildCallback = action;
}
