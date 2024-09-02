// Decompiled with JetBrains decompiler
// Type: GuildMapGround
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GuildMapGround : MonoBehaviour
{
  [SerializeField]
  private Guild0282Menu menu;

  private void OnPress(bool isDown) => this.menu.OnPress(isDown);

  private void OnDrag(Vector2 delta) => this.menu.OnDrag(delta);
}
