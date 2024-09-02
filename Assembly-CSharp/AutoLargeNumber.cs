// Decompiled with JetBrains decompiler
// Type: AutoLargeNumber
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AutoLargeNumber : MonoBehaviour
{
  private UILabel textbox;

  private void Awake() => this.textbox = this.GetComponent<UILabel>();

  private void Start()
  {
  }

  private void Update() => this.textbox.SetTextLocalize(this.textbox.text);
}
