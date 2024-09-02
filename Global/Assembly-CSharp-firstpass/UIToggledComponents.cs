// Decompiled with JetBrains decompiler
// Type: UIToggledComponents
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[RequireComponent(typeof (UIToggle))]
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Toggled Components")]
public class UIToggledComponents : MonoBehaviour
{
  public List<MonoBehaviour> activate;
  public List<MonoBehaviour> deactivate;
  [SerializeField]
  [HideInInspector]
  private MonoBehaviour target;
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
        this.target = (MonoBehaviour) null;
    }
    EventDelegate.Add(((Component) this).GetComponent<UIToggle>().onChange, new EventDelegate.Callback(this.Toggle));
  }

  public void Toggle()
  {
    if (!((Behaviour) this).enabled)
      return;
    for (int index = 0; index < this.activate.Count; ++index)
      ((Behaviour) this.activate[index]).enabled = UIToggle.current.value;
    for (int index = 0; index < this.deactivate.Count; ++index)
      ((Behaviour) this.deactivate[index]).enabled = !UIToggle.current.value;
  }
}
