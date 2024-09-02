// Decompiled with JetBrains decompiler
// Type: GuildMapGround
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GuildMapGround : MonoBehaviour
{
  [SerializeField]
  private Guild0282Menu menu;

  private void OnPress(bool isDown) => this.menu.OnPress(isDown);

  private void OnDrag(Vector2 delta) => this.menu.OnDrag(delta);
}
