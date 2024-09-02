// Decompiled with JetBrains decompiler
// Type: Startup00062Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class Startup00062Menu : MonoBehaviour
{
  [SerializeField]
  protected UILabel TxtDiscription;

  [DebuggerHidden]
  public IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00062Menu.\u003CStart\u003Ec__Iterator191()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void Init(WebAPI.Response.OfficialinfoMaintenance res)
  {
    this.TxtDiscription.SetText(Consts.Format(Consts.GetInstance().MAINTENANCE_WAIT_DISCRIPTION2, (IDictionary) new Hashtable()
    {
      {
        (object) "title",
        (object) res.message_schedule
      },
      {
        (object) "message",
        (object) res.message_body
      }
    }));
    if (res.is_maintenance)
    {
      this.StartCoroutine(this.Request(false));
    }
    else
    {
      CommonRoot instance1 = Singleton<CommonRoot>.GetInstance();
      if (Object.op_Inequality((Object) instance1, (Object) null))
        Object.Destroy((Object) ((Component) instance1).gameObject);
      NGSceneManager instance2 = Singleton<NGSceneManager>.GetInstance();
      if (Object.op_Inequality((Object) instance2, (Object) null))
        Object.Destroy((Object) ((Component) instance2).gameObject);
      SceneManager.LoadScene("startup000_6");
    }
  }

  [DebuggerHidden]
  public IEnumerator Request(bool second = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00062Menu.\u003CRequest\u003Ec__Iterator192()
    {
      second = second,
      \u003C\u0024\u003Esecond = second,
      \u003C\u003Ef__this = this
    };
  }
}
