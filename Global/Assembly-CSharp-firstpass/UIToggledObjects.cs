// Decompiled with JetBrains decompiler
// Type: UIToggledObjects
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Toggled Objects")]
[ExecuteInEditMode]
public class UIToggledObjects : MonoBehaviour
{
  public List<GameObject> activate;
  public List<GameObject> deactivate;
  [HideInInspector]
  [SerializeField]
  private GameObject target;
  [SerializeField]
  [HideInInspector]
  private bool inverse;

  private void Awake()
  {
    if (Object.op_Inequality((Object) this.target, (Object) null))
    {
      if (this.activate.Count == 0 && this.deactivate.Count == 0)
      {
        if (this.inverse)
          this.deactivate.Add(this.target);
        else
          this.activate.Add(this.target);
      }
      else
        this.target = (GameObject) null;
    }
    EventDelegate.Add(((Component) this).GetComponent<UIToggle>().onChange, new EventDelegate.Callback(this.Toggle));
  }

  public void Toggle()
  {
    bool state = UIToggle.current.value;
    if (!((Behaviour) this).enabled)
      return;
    for (int index = 0; index < this.activate.Count; ++index)
      this.Set(this.activate[index], state);
    for (int index = 0; index < this.deactivate.Count; ++index)
      this.Set(this.deactivate[index], !state);
  }

  private void Set(GameObject go, bool state)
  {
    if (!Object.op_Inequality((Object) go, (Object) null))
      return;
    NGUITools.SetActive(go, state);
  }
}
