// Decompiled with JetBrains decompiler
// Type: UISoundVolume
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[RequireComponent(typeof (UISlider))]
[AddComponentMenu("NGUI/Interaction/Sound Volume")]
public class UISoundVolume : MonoBehaviour
{
  private UISlider mSlider;

  private void Awake()
  {
    this.mSlider = ((Component) this).GetComponent<UISlider>();
    this.mSlider.value = NGUITools.soundVolume;
    EventDelegate.Add(this.mSlider.onChange, new EventDelegate.Callback(this.OnChange));
  }

  private void OnChange() => NGUITools.soundVolume = UIProgressBar.current.value;
}
