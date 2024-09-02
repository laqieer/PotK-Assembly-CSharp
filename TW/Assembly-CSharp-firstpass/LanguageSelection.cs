// Decompiled with JetBrains decompiler
// Type: LanguageSelection
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[RequireComponent(typeof (UIPopupList))]
[AddComponentMenu("NGUI/Interaction/Language Selection")]
public class LanguageSelection : MonoBehaviour
{
  private UIPopupList mList;

  private void Start()
  {
    this.mList = ((Component) this).GetComponent<UIPopupList>();
    if (Localization.knownLanguages != null)
    {
      this.mList.items.Clear();
      int index = 0;
      for (int length = Localization.knownLanguages.Length; index < length; ++index)
        this.mList.items.Add(Localization.knownLanguages[index]);
      this.mList.value = Localization.language;
    }
    EventDelegate.Add(this.mList.onChange, new EventDelegate.Callback(this.OnChange));
  }

  private void OnChange() => Localization.language = UIPopupList.current.value;
}
