// Decompiled with JetBrains decompiler
// Type: IconPrefabBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public abstract class IconPrefabBase : MonoBehaviour
{
  protected bool gray;

  public void SetSize(int width, int height)
  {
    UIWidget component = this.GetComponent<UIWidget>();
    component.transform.localScale = new Vector3((float) width / (float) component.width, (float) height / (float) component.height);
  }

  public void SetBasedOnHeight(int height)
  {
    UIWidget component = this.GetComponent<UIWidget>();
    float num = (float) height / (float) component.height;
    component.transform.localScale = new Vector3(num, num);
  }

  public void SetBasedOnWidth(int width)
  {
    UIWidget component = this.GetComponent<UIWidget>();
    float num = (float) width / (float) component.width;
    component.transform.localScale = new Vector3(num, num);
  }

  public virtual bool Gray
  {
    get => this.gray;
    set => this.gray = value;
  }
}
