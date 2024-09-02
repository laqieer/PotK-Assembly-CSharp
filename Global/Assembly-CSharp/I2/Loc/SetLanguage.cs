// Decompiled with JetBrains decompiler
// Type: I2.Loc.SetLanguage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace I2.Loc
{
  [AddComponentMenu("I2/Localization/SetLanguage")]
  public class SetLanguage : MonoBehaviour
  {
    public string _Language;

    private void OnClick() => this.ApplyLanguage();

    public void ApplyLanguage()
    {
      if (!LocalizationManager.HasLanguage(this._Language))
        return;
      LocalizationManager.CurrentLanguage = this._Language;
    }
  }
}
