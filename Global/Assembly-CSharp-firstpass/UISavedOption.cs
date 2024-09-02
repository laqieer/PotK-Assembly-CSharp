// Decompiled with JetBrains decompiler
// Type: UISavedOption
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Saved Option")]
public class UISavedOption : MonoBehaviour
{
  public string keyName;
  private UIPopupList mList;
  private UIToggle mCheck;

  private string key
  {
    get
    {
      return string.IsNullOrEmpty(this.keyName) ? "NGUI State: " + ((Object) this).name : this.keyName;
    }
  }

  private void Awake()
  {
    this.mList = ((Component) this).GetComponent<UIPopupList>();
    this.mCheck = ((Component) this).GetComponent<UIToggle>();
  }

  private void OnEnable()
  {
    if (Object.op_Inequality((Object) this.mList, (Object) null))
      EventDelegate.Add(this.mList.onChange, new EventDelegate.Callback(this.SaveSelection));
    if (Object.op_Inequality((Object) this.mCheck, (Object) null))
      EventDelegate.Add(this.mCheck.onChange, new EventDelegate.Callback(this.SaveState));
    if (Object.op_Inequality((Object) this.mList, (Object) null))
    {
      string str = PlayerPrefs.GetString(this.key);
      if (string.IsNullOrEmpty(str))
        return;
      this.mList.value = str;
    }
    else if (Object.op_Inequality((Object) this.mCheck, (Object) null))
    {
      this.mCheck.value = PlayerPrefs.GetInt(this.key, 1) != 0;
    }
    else
    {
      string str = PlayerPrefs.GetString(this.key);
      UIToggle[] componentsInChildren = ((Component) this).GetComponentsInChildren<UIToggle>(true);
      int index = 0;
      for (int length = componentsInChildren.Length; index < length; ++index)
      {
        UIToggle uiToggle = componentsInChildren[index];
        uiToggle.value = ((Object) uiToggle).name == str;
      }
    }
  }

  private void OnDisable()
  {
    if (Object.op_Inequality((Object) this.mCheck, (Object) null))
      EventDelegate.Remove(this.mCheck.onChange, new EventDelegate.Callback(this.SaveState));
    if (Object.op_Inequality((Object) this.mList, (Object) null))
      EventDelegate.Remove(this.mList.onChange, new EventDelegate.Callback(this.SaveSelection));
    if (!Object.op_Equality((Object) this.mCheck, (Object) null) || !Object.op_Equality((Object) this.mList, (Object) null))
      return;
    UIToggle[] componentsInChildren = ((Component) this).GetComponentsInChildren<UIToggle>(true);
    int index = 0;
    for (int length = componentsInChildren.Length; index < length; ++index)
    {
      UIToggle uiToggle = componentsInChildren[index];
      if (uiToggle.value)
      {
        PlayerPrefs.SetString(this.key, ((Object) uiToggle).name);
        break;
      }
    }
  }

  private void SaveSelection() => PlayerPrefs.SetString(this.key, UIPopupList.current.value);

  private void SaveState() => PlayerPrefs.SetInt(this.key, !UIToggle.current.value ? 0 : 1);
}
