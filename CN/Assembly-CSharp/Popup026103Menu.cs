﻿// Decompiled with JetBrains decompiler
// Type: Popup026103Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using UnityEngine;

#nullable disable
public class Popup026103Menu : NGMenuBase
{
  [SerializeField]
  private UILabel title;
  [SerializeField]
  private UILabel message;
  [SerializeField]
  private UILabel message2;

  public void Init()
  {
    Player player = SMManager.Get<Player>();
    this.title.SetTextLocalize(Consts.GetInstance().PVP_CLASS_MATCH_POPUP_103_TITLE);
    this.message.SetTextLocalize(Consts.GetInstance().PVP_CLASS_MATCH_POPUP_103_MESSAGE);
    this.message2.SetTextLocalize(string.Format(Consts.GetInstance().PVP_CLASS_MATCH_POPUP_103_MESSAGE2, (object) player.mp, (object) player.mp_max));
  }

  public virtual void IbtnOk()
  {
    GameObject gameObject = GameObject.Find("Versus02610Versus02610Scene UI Root");
    if (Object.op_Inequality((Object) gameObject, (Object) null))
      gameObject.GetComponent<Versus02610Menu>().StartSceneUpdate();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }
}
