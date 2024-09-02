// Decompiled with JetBrains decompiler
// Type: Popup00631Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using UnityEngine;

#nullable disable
public class Popup00631Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScrollMasonry Scroll;

  public void InitGachaDetail(
    string title,
    GachaDescriptionBodies[] bodys,
    Texture2D[] textures,
    GameObject textPrefab,
    GameObject spritePrefab)
  {
    DetailController.Init(this.Scroll, title, bodys, textures, textPrefab, spritePrefab);
  }

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();
}
