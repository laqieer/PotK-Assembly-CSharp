// Decompiled with JetBrains decompiler
// Type: GuildBankRateButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GuildBankRateButton : MonoBehaviour
{
  [SerializeField]
  private Guild0287Menu menu;

  private void Start()
  {
  }

  private void Update()
  {
  }

  private void OnDragOut(GameObject draggedObject) => this.menu.SetRateButtonColor();
}
