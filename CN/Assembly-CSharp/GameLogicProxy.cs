// Decompiled with JetBrains decompiler
// Type: GameLogicProxy
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using DenaLib;
using UnityEngine;

#nullable disable
public class GameLogicProxy : MonoBehaviour
{
  public GameObject enamy;
  public GameObject uiRoot;
  private Vector3 m_Start = new Vector3(0.0f, 0.0f, 0.0f);

  private void Awake()
  {
    DenaLib.Singleton<GameLogic>.Instance.Init();
    DenaLib.Singleton<GameLogic>.Instance.GetWindowStackManager().Init(this.uiRoot, (IGameLogic) DenaLib.Singleton<GameLogic>.Instance);
  }

  private void Start()
  {
    DenaLib.Singleton<GameLogic>.Instance.GetCallbackCenter().SetCallback(7, new ObjectCallback(this.OnGameStart));
    DenaLib.Singleton<GameLogic>.Instance.GetWindowStackManager().Show("UI/LoginPage", "LoginPage", 0, false, (object[]) null);
  }

  private void Update() => DenaLib.Singleton<GameLogic>.Instance.Update();

  public void OnGameStart(params object[] param)
  {
    if (Object.op_Inequality((Object) this.enamy, (Object) null))
      this.enamy.SetActive(true);
    DenaLib.Singleton<GameLogic>.Instance.GetWindowStackManager().Show("UI/GamePage", "GamePage", 0, true, (object[]) null);
    HFResourceManager resourceManager = DenaLib.Singleton<GameLogic>.Instance.GetResourceManager();
    Object instance = (Object) null;
    for (int index = 0; index < 100; ++index)
    {
      int num = (int) resourceManager.LoadAsync("Model/Optimius", EResType.EResPrefab, false, out instance, new DenaLib.OnLoadFinished(this.OnLoadFinished));
    }
  }

  private void OnLoadFinished(Object obj)
  {
    if (!Object.op_Inequality(obj, (Object) null))
      return;
    GameObject gameObject = DenaLib.Singleton<GameLogic>.Instance.GetResourceManager().DoInstantiate(EResType.EResPrefab, obj) as GameObject;
    if (!Object.op_Inequality((Object) gameObject, (Object) null))
      return;
    gameObject.transform.position = this.m_Start;
    gameObject.transform.parent = this.enamy.transform;
    this.m_Start.x += 2f;
  }
}
