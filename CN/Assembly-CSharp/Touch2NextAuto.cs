// Decompiled with JetBrains decompiler
// Type: Touch2NextAuto
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Touch2NextAuto : MonoBehaviour
{
  public GameObject touch2Next;

  private void Awake()
  {
    this.touch2Next = Object.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/CommonUI/slc_TouchToNext"));
    string name = ((Object) ((Component) this).gameObject).name;
    if (((Object) ((Component) this).gameObject).name == "unit004812unit004812Scene UI Root")
    {
      GameObject gameObject = GameObject.Find("unit004812unit004812Scene UI Root/MainPanel/Bottom");
      if (Object.op_Implicit((Object) gameObject))
      {
        this.touch2Next.transform.parent = gameObject.transform ?? this.touch2Next.transform.parent;
        this.touch2Next.transform.localScale = Vector3.one;
        Vector3 vector3;
        // ISSUE: explicit constructor call
        ((Vector3) ref vector3).\u002Ector(164.3f, 15.6f, 0.0f);
        this.touch2Next.transform.localPosition = vector3;
        this.touch2Next.transform.localRotation = Quaternion.identity;
      }
      this.touch2Next.SetActive(false);
    }
    else if (((Object) ((Component) this).gameObject).name == "Bugu00539Bugu00539Scene UI Root")
    {
      GameObject gameObject = GameObject.Find("Bugu00539Bugu00539Scene UI Root/MainPanel/Bottom");
      if (Object.op_Implicit((Object) gameObject))
      {
        this.touch2Next.transform.parent = gameObject.transform ?? this.touch2Next.transform.parent;
        this.touch2Next.transform.localScale = Vector3.one;
        Vector3 vector3;
        // ISSUE: explicit constructor call
        ((Vector3) ref vector3).\u002Ector(164.3f, 15.6f, 0.0f);
        this.touch2Next.transform.localPosition = vector3;
        this.touch2Next.transform.localRotation = Quaternion.identity;
      }
      this.touch2Next.SetActive(false);
    }
    else if (((Object) ((Component) this).gameObject).name == "Bugu005415Bugu005415Scene UI Root")
    {
      GameObject gameObject = GameObject.Find("Bugu005415Bugu005415Scene UI Root/MainPanel/Bottom");
      if (Object.op_Implicit((Object) gameObject))
      {
        this.touch2Next.transform.parent = gameObject.transform ?? this.touch2Next.transform.parent;
        this.touch2Next.transform.localScale = Vector3.one;
        Vector3 vector3;
        // ISSUE: explicit constructor call
        ((Vector3) ref vector3).\u002Ector(164.3f, 15.6f, 0.0f);
        this.touch2Next.transform.localPosition = vector3;
        this.touch2Next.transform.localRotation = Quaternion.identity;
      }
      this.touch2Next.SetActive(false);
    }
    else if (((Object) ((Component) this).gameObject).name == "Shop00720Shop00720Scene UI Root")
    {
      GameObject gameObject = GameObject.Find("Shop00720Shop00720Scene UI Root/MainPanel/Bottom");
      if (Object.op_Implicit((Object) gameObject))
      {
        this.touch2Next.transform.parent = gameObject.transform ?? this.touch2Next.transform.parent;
        this.touch2Next.transform.localScale = Vector3.one;
        Vector3 vector3;
        // ISSUE: explicit constructor call
        ((Vector3) ref vector3).\u002Ector(167f, 79.5f, 0.0f);
        this.touch2Next.transform.localPosition = vector3;
        this.touch2Next.transform.localRotation = Quaternion.identity;
      }
      this.touch2Next.SetActive(false);
    }
    else if (((Object) ((Component) this).gameObject).name == "BattleUI05Scene UI Root")
    {
      GameObject gameObject = GameObject.Find("BattleUI05Scene UI Root/MainPanel/Bottom");
      if (Object.op_Implicit((Object) gameObject))
      {
        this.touch2Next.transform.parent = gameObject.transform ?? this.touch2Next.transform.parent;
        this.touch2Next.transform.localScale = Vector3.one;
        Vector3 vector3;
        // ISSUE: explicit constructor call
        ((Vector3) ref vector3).\u002Ector(203f, -446f, 0.0f);
        this.touch2Next.transform.localPosition = vector3;
        this.touch2Next.transform.localRotation = Quaternion.identity;
        ((Object) this.touch2Next).name = "slc_TouchToNextNoFun";
      }
      this.touch2Next.SetActive(false);
    }
    else if (((Object) ((Component) this).gameObject).name == "Gacha006EffectGacha006EffectScene UI Root")
    {
      GameObject gameObject = GameObject.Find("Gacha006EffectGacha006EffectScene UI Root/MainPanel/Bottom");
      if (Object.op_Implicit((Object) gameObject))
      {
        this.touch2Next.transform.parent = gameObject.transform ?? this.touch2Next.transform.parent;
        this.touch2Next.transform.localScale = Vector3.one;
        Vector3 vector3;
        // ISSUE: explicit constructor call
        ((Vector3) ref vector3).\u002Ector(164.3f, 5f, 0.0f);
        this.touch2Next.transform.localPosition = vector3;
        this.touch2Next.transform.localRotation = Quaternion.identity;
      }
      this.touch2Next.SetActive(false);
    }
    else if (((Object) ((Component) this).gameObject).name.Contains("UnitLevelUpPrefab"))
    {
      GameObject gameObject = GameObject.Find("UnitLevelUpPrefab(Clone)/Bottom");
      if (Object.op_Implicit((Object) gameObject))
      {
        this.touch2Next.transform.parent = gameObject.transform ?? this.touch2Next.transform.parent;
        this.touch2Next.transform.localScale = Vector3.one;
        Vector3 vector3;
        // ISSUE: explicit constructor call
        ((Vector3) ref vector3).\u002Ector(203f, -446f, 0.0f);
        this.touch2Next.transform.localPosition = vector3;
        this.touch2Next.transform.localRotation = Quaternion.identity;
      }
      this.touch2Next.SetActive(false);
    }
    else if (((Object) ((Component) this).gameObject).name.Contains("PlayerLevelUpPrefab"))
    {
      GameObject gameObject = GameObject.Find("PlayerLevelUpPrefab(Clone)/Bottom");
      if (Object.op_Implicit((Object) gameObject))
      {
        this.touch2Next.transform.parent = gameObject.transform ?? this.touch2Next.transform.parent;
        this.touch2Next.transform.localScale = Vector3.one;
        Vector3 vector3;
        // ISSUE: explicit constructor call
        ((Vector3) ref vector3).\u002Ector(203f, -446f, 0.0f);
        this.touch2Next.transform.localPosition = vector3;
        this.touch2Next.transform.localRotation = Quaternion.identity;
      }
      this.touch2Next.SetActive(false);
    }
    else if (((Object) ((Component) this).gameObject).name == "unit00497unit00497Scene UI Root")
    {
      GameObject gameObject = GameObject.Find("unit00497unit00497Scene UI Root/MainPanel/Bottom");
      if (Object.op_Implicit((Object) gameObject))
      {
        this.touch2Next.transform.parent = gameObject.transform ?? this.touch2Next.transform.parent;
        this.touch2Next.transform.localScale = Vector3.one;
        Vector3 vector3;
        // ISSUE: explicit constructor call
        ((Vector3) ref vector3).\u002Ector(164.4f, 5f, 0.0f);
        this.touch2Next.transform.localPosition = vector3;
        this.touch2Next.transform.localRotation = Quaternion.identity;
      }
      this.touch2Next.SetActive(false);
    }
    else
      this.touch2Next.SetActive(false);
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
