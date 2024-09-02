// Decompiled with JetBrains decompiler
// Type: UILocalize
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[RequireComponent(typeof (UIWidget))]
[AddComponentMenu("NGUI/UI/Localize")]
[ExecuteInEditMode]
public class UILocalize : MonoBehaviour
{
  public string key;
  private bool mStarted;

  public string value
  {
    set
    {
      if (string.IsNullOrEmpty(value))
        return;
      UIWidget component = ((Component) this).GetComponent<UIWidget>();
      UILabel uiLabel = component as UILabel;
      UISprite uiSprite = component as UISprite;
      if (Object.op_Inequality((Object) uiLabel, (Object) null))
      {
        UIInput inParents = NGUITools.FindInParents<UIInput>(((Component) uiLabel).gameObject);
        if (Object.op_Inequality((Object) inParents, (Object) null) && Object.op_Equality((Object) inParents.label, (Object) uiLabel))
          inParents.defaultText = value;
        else
          uiLabel.text = value;
      }
      else
      {
        if (!Object.op_Inequality((Object) uiSprite, (Object) null))
          return;
        uiSprite.spriteName = value;
        uiSprite.MakePixelPerfect();
      }
    }
  }

  private void OnEnable()
  {
    if (!this.mStarted)
      return;
    this.OnLocalize();
  }

  private void Start()
  {
    this.mStarted = true;
    this.OnLocalize();
  }

  private void OnLocalize()
  {
    if (string.IsNullOrEmpty(this.key))
    {
      UILabel component = ((Component) this).GetComponent<UILabel>();
      if (Object.op_Inequality((Object) component, (Object) null))
        this.key = component.text;
    }
    if (string.IsNullOrEmpty(this.key))
      return;
    this.value = Localization.Get(this.key);
  }
}
