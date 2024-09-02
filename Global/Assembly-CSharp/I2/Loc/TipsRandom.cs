// Decompiled with JetBrains decompiler
// Type: I2.Loc.TipsRandom
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace I2.Loc
{
  public class TipsRandom : MonoBehaviour
  {
    public void OnModifyLocalization()
    {
      if (!LocalizationPreset.Instance.EnableLocalization)
        return;
      string[] strArray = Localize.MainTranslation.Split('\n');
      Localize.MainTranslation = strArray[Random.Range(0, strArray.Length)];
    }
  }
}
