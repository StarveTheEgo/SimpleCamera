// Decompiled with JetBrains decompiler
// Type: SimpleCamera.Plugin
// Assembly: SimpleCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

using ReplaySeeker;
using ReplaySeeker.Plugins;
using System;

namespace SimpleCamera
{
  public class Plugin : IReplaySeekerPlugin
  {
    private PluginForm form;
    private IReplaySeekerCore core;
    private IReplayManager replay;

    public string Name
    {
      get
      {
        return "Deer Camera v4";
      }
    }

    public string Description
    {
      get
      {
        return "Adds functionality to the ingame camera";
      }
    }

    public bool Initialize(IReplaySeekerCore Core)
    {
      this.core = Core;
      this.core.ReplayFound += new ReplayEventHandler(this.Core_ReplayFound);
      this.core.ReplayNotFound += new ReplayEventHandler(this.core_ReplayNotFound);
      this.core.AppClose += new EventHandler(this.core_AppClose);
      this.form = new PluginForm();
      this.form.Owner = Core.AppForm;
      return true;
    }

    private void Core_ReplayFound(IReplayManager replay)
    {
      this.replay = replay;
      this.form.SetReplay(replay);
    }

    private void core_ReplayNotFound(IReplayManager replay)
    {
      this.replay = (IReplayManager) null;
      this.form.SetReplay((IReplayManager) null);
    }

    private void core_AppClose(object sender, EventArgs e)
    {
      this.form.StopUpdate();
      this.form = (PluginForm) null;
    }

    public void OnClick()
    {
      this.form.StartUpdate();
      this.form.Show();
    }
  }
}
