// Decompiled with JetBrains decompiler
// Type: AnchorResetter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AnchorResetter : MonoBehaviour
{
  private bool firstEnable = true;

  private void Awake() => this.firstEnable = true;

  private void OnEnable()
  {
    if (!this.firstEnable)
      return;
    this.firstEnable = false;
    UIRect component = this.GetComponent<UIRect>();
    if (!((Object) component != (Object) null))
      return;
    component.ResetAnchors();
    component.Update();
  }
}
