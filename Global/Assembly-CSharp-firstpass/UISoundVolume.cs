// Decompiled with JetBrains decompiler
// Type: UISoundVolume
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

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
