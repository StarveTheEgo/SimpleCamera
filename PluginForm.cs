// Decompiled with JetBrains decompiler
// Type: SimpleCamera.PluginForm
// Assembly: SimpleCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

using ReplaySeeker;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SimpleCamera
{
  public class PluginForm : Form
  {
    public static float U2C = 1f / 32f;
    private CameraPoint[] bookmarks = new CameraPoint[10];
    private bool active = true;
    private IContainer components;
    private GroupBox groupBox2;
    private Label label8;
    private Label label10;
    private Label label9;
    private Label label13;
    private System.Windows.Forms.Timer tmrWindow;
    private Label label17;
    private CheckBox chkLog;
    private TextBox txtLog;
    private TextBox txtMouseSmoothing;
    private Label label18;
    private Label label19;
    private Label lblStatus;
    private Button btnControls;
    private GroupBox groupBox1;
    private TextBox txtMouseSensitivity;
    private TextBox txtZoomSpeed;
    private TextBox txtFollowSmoothness;
    private TextBox txtMoveSpeed;
    private TextBox txtRotateSpeed;
    private LinkLabel linkThread;
    private Label label1;
    private CheckBox chkInvert;
    private Label label2;
    private IReplayManager replay;
    private ControlsForm controlsForm;
    private CameraManager camera;
    private Thread updateThread;
    private float rotationSpeed;
    private float rotationAcc;
    private float ascendSpeed;
    private float ascendAcc;
    private float forwardSpeed;
    private float forwardAcc;
    private float rightSpeed;
    private float rightAcc;
    private float distanceSpeed;
    private float distanceAcc;
    private Unit followUnit;
    private bool followToggle;
    private bool facingToggle;
    private bool lockFacing;
    private bool FPSToggle;
    private Point lastMouse;
    private float mouseX;
    private float mouseY;
    private bool running;
    private bool focused;
    private bool settingsLoaded;

    public PluginForm()
    {
      this.InitializeComponent();
      this.controlsForm = new ControlsForm();
      Settings.loadSettings();
      this.controlsForm.loadSettings();
      this.txtFollowSmoothness.Text = Settings.getSettingString("txtFollowSmoothness", this.txtFollowSmoothness.Text);
      this.txtMouseSensitivity.Text = Settings.getSettingString("txtMouseSensitivity", this.txtMouseSensitivity.Text);
      this.txtMoveSpeed.Text = Settings.getSettingString("txtMoveSpeed", this.txtMoveSpeed.Text);
      this.txtRotateSpeed.Text = Settings.getSettingString("txtRotateSpeed", this.txtRotateSpeed.Text);
      this.txtZoomSpeed.Text = Settings.getSettingString("txtZoomSpeed", this.txtZoomSpeed.Text);
      this.txtMouseSmoothing.Text = Settings.getSettingString("txtMouseSmoothing", this.txtMouseSmoothing.Text);
      this.chkInvert.Checked = Settings.getSettingBool("chkInvert", this.chkInvert.Checked);
      for (int index = 0; index < 10; ++index)
      {
        string settingString = Settings.getSettingString("bookmark" + (object) index, "");
        if (!settingString.Equals(""))
          this.bookmarks[index] = new CameraPoint(settingString);
      }
      this.controlsForm.activationHotkey.HotkeyClicked += new HotkeyEvent(this.activationHotkey_HotkeyClicked);
      this.settingsLoaded = true;
      this.updateThread = new Thread(new ThreadStart(this.updateLoop));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.groupBox2 = new GroupBox();
      this.chkInvert = new CheckBox();
      this.label2 = new Label();
      this.txtMouseSensitivity = new TextBox();
      this.txtZoomSpeed = new TextBox();
      this.txtFollowSmoothness = new TextBox();
      this.txtMoveSpeed = new TextBox();
      this.txtRotateSpeed = new TextBox();
      this.txtMouseSmoothing = new TextBox();
      this.label18 = new Label();
      this.chkLog = new CheckBox();
      this.label17 = new Label();
      this.label13 = new Label();
      this.label10 = new Label();
      this.label9 = new Label();
      this.label8 = new Label();
      this.tmrWindow = new System.Windows.Forms.Timer(this.components);
      this.txtLog = new TextBox();
      this.label19 = new Label();
      this.lblStatus = new Label();
      this.btnControls = new Button();
      this.groupBox1 = new GroupBox();
      this.linkThread = new LinkLabel();
      this.label1 = new Label();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.groupBox2.Controls.Add((Control) this.chkInvert);
      this.groupBox2.Controls.Add((Control) this.label2);
      this.groupBox2.Controls.Add((Control) this.txtMouseSensitivity);
      this.groupBox2.Controls.Add((Control) this.txtZoomSpeed);
      this.groupBox2.Controls.Add((Control) this.txtFollowSmoothness);
      this.groupBox2.Controls.Add((Control) this.txtMoveSpeed);
      this.groupBox2.Controls.Add((Control) this.txtRotateSpeed);
      this.groupBox2.Controls.Add((Control) this.txtMouseSmoothing);
      this.groupBox2.Controls.Add((Control) this.label18);
      this.groupBox2.Controls.Add((Control) this.label17);
      this.groupBox2.Controls.Add((Control) this.label13);
      this.groupBox2.Controls.Add((Control) this.label10);
      this.groupBox2.Controls.Add((Control) this.label9);
      this.groupBox2.Controls.Add((Control) this.label8);
      this.groupBox2.Location = new Point(12, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(189, 212);
      this.groupBox2.TabIndex = 19;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Settings";
      this.chkInvert.AutoSize = true;
      this.chkInvert.Location = new Point(129, 180);
      this.chkInvert.Name = "chkInvert";
      this.chkInvert.Size = new Size(15, 14);
      this.chkInvert.TabIndex = 27;
      this.chkInvert.UseVisualStyleBackColor = true;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(13, 180);
      this.label2.Name = "label2";
      this.label2.Size = new Size(100, 13);
      this.label2.TabIndex = 36;
      this.label2.Text = "Invert mouse (FPS):";
      this.txtMouseSensitivity.Location = new Point(119, 125);
      this.txtMouseSensitivity.Name = "txtMouseSensitivity";
      this.txtMouseSensitivity.Size = new Size(60, 20);
      this.txtMouseSensitivity.TabIndex = 35;
      this.txtMouseSensitivity.Text = "250";
      this.txtZoomSpeed.Location = new Point(119, 99);
      this.txtZoomSpeed.Name = "txtZoomSpeed";
      this.txtZoomSpeed.Size = new Size(60, 20);
      this.txtZoomSpeed.TabIndex = 34;
      this.txtZoomSpeed.Text = "50";
      this.txtFollowSmoothness.Location = new Point(119, 73);
      this.txtFollowSmoothness.Name = "txtFollowSmoothness";
      this.txtFollowSmoothness.Size = new Size(60, 20);
      this.txtFollowSmoothness.TabIndex = 33;
      this.txtFollowSmoothness.Text = "100";
      this.txtMoveSpeed.Location = new Point(119, 47);
      this.txtMoveSpeed.Name = "txtMoveSpeed";
      this.txtMoveSpeed.Size = new Size(60, 20);
      this.txtMoveSpeed.TabIndex = 32;
      this.txtMoveSpeed.Text = "50";
      this.txtRotateSpeed.Location = new Point(119, 21);
      this.txtRotateSpeed.Name = "txtRotateSpeed";
      this.txtRotateSpeed.Size = new Size(60, 20);
      this.txtRotateSpeed.TabIndex = 31;
      this.txtRotateSpeed.Text = "50";
      this.txtMouseSmoothing.Location = new Point(119, 151);
      this.txtMouseSmoothing.Name = "txtMouseSmoothing";
      this.txtMouseSmoothing.Size = new Size(60, 20);
      this.txtMouseSmoothing.TabIndex = 0;
      this.txtMouseSmoothing.Text = "35";
      this.label18.AutoSize = true;
      this.label18.Location = new Point(20, 154);
      this.label18.Name = "label18";
      this.label18.Size = new Size(93, 13);
      this.label18.TabIndex = 30;
      this.label18.Text = "Mouse smoothing:";
      this.chkLog.AutoSize = true;
      this.chkLog.Location = new Point(225, 188);
      this.chkLog.Name = "chkLog";
      this.chkLog.Size = new Size(70, 17);
      this.chkLog.TabIndex = 29;
      this.chkLog.Text = "Show log";
      this.chkLog.UseVisualStyleBackColor = true;
      this.chkLog.Visible = false;
      this.chkLog.CheckedChanged += new EventHandler(this.chkLog_CheckedChanged);
      this.label17.AutoSize = true;
      this.label17.Location = new Point(23, 128);
      this.label17.Name = "label17";
      this.label17.Size = new Size(90, 13);
      this.label17.TabIndex = 28;
      this.label17.Text = "Mouse sensitivity:";
      this.label13.AutoSize = true;
      this.label13.Location = new Point(44, 102);
      this.label13.Name = "label13";
      this.label13.Size = new Size(69, 13);
      this.label13.TabIndex = 25;
      this.label13.Text = "Zoom speed:";
      this.label10.AutoSize = true;
      this.label10.Location = new Point(14, 76);
      this.label10.Name = "label10";
      this.label10.Size = new Size(99, 13);
      this.label10.TabIndex = 21;
      this.label10.Text = "Follow smoothness:";
      this.label9.AutoSize = true;
      this.label9.Location = new Point(44, 50);
      this.label9.Name = "label9";
      this.label9.Size = new Size(69, 13);
      this.label9.TabIndex = 20;
      this.label9.Text = "Move speed:";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(39, 24);
      this.label8.Name = "label8";
      this.label8.Size = new Size(74, 13);
      this.label8.TabIndex = 19;
      this.label8.Text = "Rotate speed:";
      this.tmrWindow.Interval = 500;
      this.tmrWindow.Tick += new EventHandler(this.tmrWindow_Tick);
      this.txtLog.Location = new Point(10, 365);
      this.txtLog.Multiline = true;
      this.txtLog.Name = "txtLog";
      this.txtLog.Size = new Size(668, 217);
      this.txtLog.TabIndex = 20;
      this.txtLog.Visible = false;
      this.label19.AutoSize = true;
      this.label19.Location = new Point(6, 16);
      this.label19.Name = "label19";
      this.label19.Size = new Size(40, 13);
      this.label19.TabIndex = 21;
      this.label19.Text = "Status:";
      this.lblStatus.AutoSize = true;
      this.lblStatus.Location = new Point(6, 29);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new Size(56, 13);
      this.lblStatus.TabIndex = 22;
      this.lblStatus.Text = "Not active";
      this.btnControls.Location = new Point(207, 12);
      this.btnControls.Name = "btnControls";
      this.btnControls.Size = new Size(121, 23);
      this.btnControls.TabIndex = 23;
      this.btnControls.Text = "Configure controls";
      this.btnControls.UseVisualStyleBackColor = true;
      this.btnControls.Click += new EventHandler(this.btnControls_Click);
      this.groupBox1.Controls.Add((Control) this.lblStatus);
      this.groupBox1.Controls.Add((Control) this.label19);
      this.groupBox1.Location = new Point(207, 41);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(121, 48);
      this.groupBox1.TabIndex = 24;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Info";
      this.linkThread.AutoSize = true;
      this.linkThread.Location = new Point(213, 147);
      this.linkThread.Name = "linkThread";
      this.linkThread.Size = new Size(99, 13);
      this.linkThread.TabIndex = 25;
      this.linkThread.TabStop = true;
      this.linkThread.Text = "Online forum thread";
      this.linkThread.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkThread_LinkClicked);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(213, 128);
      this.label1.Name = "label1";
      this.label1.Size = new Size(102, 13);
      this.label1.TabIndex = 26;
      this.label1.Text = "Author: DonTomaso";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(337, 236);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.linkThread);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.btnControls);
      this.Controls.Add((Control) this.txtLog);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.chkLog);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "PluginForm";
      this.ShowIcon = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Simple Camera";
      this.FormClosing += new FormClosingEventHandler(this.Form_FormClosing);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    [DllImport("user32.dll")]
    public static extern int FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    public static extern int GetForegroundWindow();

    private void activationHotkey_HotkeyClicked(object sender)
    {
      this.active = !this.active;
      if (this.active)
      {
        this.StartUpdate();
      }
      else
      {
        this.StopUpdate();
        this.controlsForm.startActivation();
      }
    }

    private void updateLoop()
    {
      CameraPoint cameraPoint = new CameraPoint(this.camera);
      this.log("System - Loop started");
      try
      {
        int num1 = 0;
        while (this.camera != null)
        {
          ++num1;
          if (num1 % 5000 == 0)
            this.log("System - 5000 update");
          int result1 = 0;
          int.TryParse(this.txtRotateSpeed.Text, out result1);
          int result2 = 0;
          int.TryParse(this.txtMoveSpeed.Text, out result2);
          int result3 = 0;
          int.TryParse(this.txtFollowSmoothness.Text, out result3);
          int result4 = 0;
          int.TryParse(this.txtZoomSpeed.Text, out result4);
          int result5 = 0;
          int.TryParse(this.txtMouseSensitivity.Text, out result5);
          int result6 = 0;
          int.TryParse(this.txtMouseSmoothing.Text, out result6);
          if (this.controlsForm.isHotkeyPressed("hbCtrl"))
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.controlsForm.isHotkeyPressed("hb" + (object) index))
                this.bookmarks[index] = cameraPoint.copy();
            }
          }
          else
          {
            for (int index = 0; index < 10; ++index)
            {
              if (this.bookmarks[index] != null && this.controlsForm.isHotkeyPressed("hb" + (object) index))
                cameraPoint = this.bookmarks[index].copy();
            }
          }
          this.camera.fogMinDistance = 5000f;
          this.camera.fogMaxDistance = 20000f;
          this.camera.distanceMax = 1000000f;
          this.camera.viewMaxDistance = 1000000f;
          this.rotationAcc = !this.controlsForm.isHotkeyPressed("hbRotateRight") ? (!this.controlsForm.isHotkeyPressed("hbRotateLeft") ? 0.0f : (float) -result1 / 200f) : (float) result1 / 200f;
          this.rotationSpeed += this.rotationAcc / 2000f;
          this.rotationSpeed *= 0.98f;
          cameraPoint.rotate(CameraAxis.Yaw, this.rotationSpeed, CameraOrigin.Target);
          if (!this.controlsForm.isHotkeyPressed("hbFollow"))
            this.followToggle = false;
          if (this.controlsForm.isHotkeyPressed("hbFollow") && !this.followToggle)
          {
            this.followUnit = !(this.followUnit == (Unit) null) ? (Unit) null : this.camera.getSelectedUnit();
            this.followToggle = true;
          }
          if (!this.controlsForm.isHotkeyPressed("hbFacing"))
            this.facingToggle = false;
          if (this.controlsForm.isHotkeyPressed("hbFacing") && !this.facingToggle)
          {
            this.lockFacing = !this.lockFacing;
            this.facingToggle = true;
          }
          if (!this.controlsForm.isHotkeyPressed("hbFPS"))
            this.FPSToggle = false;
          if (this.controlsForm.isHotkeyPressed("hbFPS") && !this.FPSToggle)
          {
            this.FPSToggle = true;
            if (cameraPoint.mode == CameraMode.Default)
            {
              cameraPoint.mode = CameraMode.FirstPerson;
              cameraPoint.origin = CameraOrigin.Eye;
            }
            else
            {
              cameraPoint.mode = CameraMode.Default;
              cameraPoint.origin = CameraOrigin.Target;
            }
            this.lastMouse = Cursor.Position;
            this.resetMouseCoords();
          }
          this.ascendAcc = !this.controlsForm.isHotkeyPressed("hbAscend") ? (!this.controlsForm.isHotkeyPressed("hbDescend") ? 0.0f : (float) -result2 / 50f) : (float) result2 / 50f;
          this.ascendSpeed += this.ascendAcc / 300f;
          this.ascendSpeed *= 0.98f;
          cameraPoint.move(CameraDirection.Up, this.ascendSpeed);
          this.forwardAcc = !this.controlsForm.isHotkeyPressed("hbMoveForward") ? (!this.controlsForm.isHotkeyPressed("hbMoveBackward") ? 0.0f : (float) -result2 / 50f) : (float) result2 / 50f;
          this.forwardSpeed += this.forwardAcc / 300f;
          this.forwardSpeed *= 0.98f;
          cameraPoint.move(CameraDirection.Forward, this.forwardSpeed);
          this.rightAcc = !this.controlsForm.isHotkeyPressed("hbMoveRight") ? (!this.controlsForm.isHotkeyPressed("hbMoveLeft") ? 0.0f : (float) -result2 / 50f) : (float) result2 / 50f;
          this.rightSpeed += this.rightAcc / 400f;
          this.rightSpeed *= 0.98f;
          cameraPoint.move(CameraDirection.Right, this.rightSpeed);
          if (this.followUnit != (Unit) null && cameraPoint.mode != CameraMode.FirstPerson)
          {
            float x = (this.followUnit.x + 8192f) * PluginForm.U2C;
            float y = (this.followUnit.y + 8192f) * PluginForm.U2C;
            cameraPoint.setPosition(x, y, CameraOrigin.Target, result3);
            if (this.lockFacing)
            {
              float face = this.followUnit.face;
              cameraPoint.setRotation(CameraAxis.Yaw, this.angleSmooth(cameraPoint.getYaw(), face, 100));
            }
          }
          this.distanceAcc = !this.controlsForm.isHotkeyPressed("hbDistanceIncrease") ? (!this.controlsForm.isHotkeyPressed("hbDistanceDecrease") ? 0.0f : (float) -result4 / 50f) : (float) result4 / 50f;
          this.distanceSpeed += this.distanceAcc / 20f * PluginForm.U2C;
          this.distanceSpeed *= 0.98f;
          cameraPoint.setDistance(cameraPoint.getDistance() + this.distanceSpeed);
          if (cameraPoint.mode == CameraMode.FirstPerson)
          {
            float factor = 1f - (float) Math.Pow(0.9, (double) result6);
            float mouseXdiffSmooth = this.getMouseXDiffSmooth(factor);
            cameraPoint.rotate(CameraAxis.Yaw, (float) ((double) mouseXdiffSmooth / 1000.0 * (double) result5 / 150.0 * (1.0 - (double) factor)));
            float num2 = this.getMouseYDiffSmooth(factor);
            if (this.chkInvert.Checked)
              num2 = -num2;
            cameraPoint.rotate(CameraAxis.Pitch, (float) ((double) num2 / 1000.0 * (double) result5 / 150.0 * (1.0 - (double) factor)));
            this.resetMouseCoords();
          }
          cameraPoint.apply(this.camera);
          Thread.Sleep(1);
        }
      }
      catch (ThreadAbortException ex)
      {
      }
      this.log("System - Loop ended");
    }

    private void resetMouseCoords()
    {
      Cursor.Position = this.lastMouse;
    }

    private int getMouseXDiff()
    {
      int num = Screen.PrimaryScreen.WorkingArea.Width / 2;
      return this.lastMouse.X - Cursor.Position.X;
    }

    private int getMouseYDiff()
    {
      int num = Screen.PrimaryScreen.WorkingArea.Height / 2;
      return this.lastMouse.Y - Cursor.Position.Y;
    }

    private float getMouseXDiffSmooth(float factor)
    {
      float num = this.mouseX += (float) this.getMouseXDiff();
      this.mouseX *= factor;
      return num;
    }

    private float getMouseYDiffSmooth(float factor)
    {
      float num = this.mouseY += (float) this.getMouseYDiff();
      this.mouseY *= factor;
      return num;
    }

    private float angleSmooth(float old, float towards, int amount)
    {
      float num;
      if ((double) Math.Abs(towards - old) < Math.PI)
      {
        num = (old * (float) amount + towards) / (float) (amount + 1);
      }
      else
      {
        if ((double) old < (double) towards)
          old += 6.283185f;
        else
          towards += 6.283185f;
        num = (old * (float) amount + towards) / (float) (amount + 1);
        while ((double) num > 2.0 * Math.PI)
          num -= 6.283185f;
      }
      return num;
    }

    private void Form_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing)
      {
        e.Cancel = true;
        this.Hide();
      }
      this.log("System - Form closing");
      this.StopUpdate();
      this.SaveSettings();
      Settings.saveSettings();
    }

    internal void SetReplay(IReplayManager replay)
    {
      this.replay = replay;
      if (replay != null)
      {
        this.log("System - Replay found/Start");
        this.camera = CameraManager.FromProcess(replay.Memory);
        if (this.camera == null)
        {
          this.lblStatus.Text = "Error " + (object) CameraManager.found;
          this.log("Camera not found.");
        }
        else
        {
          this.lblStatus.Text = "Working";
          this.camera.distanceMax = this.camera.viewMaxDistance = 1000000f;
          int num = this.Visible ? 1 : 0;
          this.tmrWindow.Enabled = true;
        }
      }
      else
      {
        this.log("System - Stop");
        this.StopUpdate();
        this.camera = (CameraManager) null;
        this.tmrWindow.Enabled = false;
      }
    }

    public void StopUpdate()
    {
      this.log("System - Deactivating hotkeys");
      this.running = false;
      this.updateThread.Abort();
      this.controlsForm.stopAll();
    }

    public void StartUpdate()
    {
      if (this.running)
        return;
      this.StopUpdate();
      this.log("System - Activating hotkeys");
      if (this.camera == null)
        return;
      this.active = true;
      this.controlsForm.startAll();
      this.updateThread = new Thread(new ThreadStart(this.updateLoop));
      this.running = true;
      this.updateThread.Start();
    }

    private void hbActivateToggle_HotkeyClicked(object sender)
    {
      if (this.running)
      {
        this.log("Hotkey - Deactivating hotkeys");
        this.StopUpdate();
      }
      else
      {
        this.log("Hotkey - Activating hotkeys");
        this.StartUpdate();
      }
    }

    private void tmrWindow_Tick(object sender, EventArgs e)
    {
      bool flag = PluginForm.GetForegroundWindow() == PluginForm.FindWindow((string) null, "Warcraft III");
      if (this.camera == null)
      {
        this.StopUpdate();
        this.log("Resetting camera");
        this.SetReplay(this.replay);
      }
      else
      {
        if (flag == this.focused && this.tmrWindow.Tag != null || !this.Visible)
          return;
        this.tmrWindow.Tag = (object) "only once";
        if (flag)
        {
          this.log("Window - Focused. Starting loop");
          this.StartUpdate();
          this.focused = flag;
        }
        else
        {
          if (flag)
            return;
          this.log("Window - Not focused. Stopping loop");
          this.StopUpdate();
          this.focused = flag;
        }
      }
    }

    private void log(string str)
    {
      if (!this.txtLog.Visible)
        return;
      this.txtLog.Text = str + "\r\n" + this.txtLog.Text;
    }

    private void chkLog_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkLog.Checked)
        this.Height = 505;
      else
        this.Height = 272;
    }

    private void SaveSettings()
    {
      if (!this.settingsLoaded)
        return;
      this.controlsForm.saveSettings();
      Settings.setSetting("txtFollowSmoothness", this.txtFollowSmoothness.Text);
      Settings.setSetting("txtMouseSensitivity", this.txtMouseSensitivity.Text);
      Settings.setSetting("txtMoveSpeed", this.txtMoveSpeed.Text);
      Settings.setSetting("txtRotateSpeed", this.txtRotateSpeed.Text);
      Settings.setSetting("txtZoomSpeed", this.txtZoomSpeed.Text);
      Settings.setSetting("txtMouseSmoothing", this.txtMouseSmoothing.Text);
      Settings.setSetting("chkInvert", this.chkInvert.Checked);
      for (int index = 0; index < 10; ++index)
      {
        if (this.bookmarks[index] != null)
          Settings.setSetting("bookmark" + (object) index, this.bookmarks[index].StoreToString());
      }
      this.controlsForm.saveSettings();
    }

    private void btnControls_Click(object sender, EventArgs e)
    {
      this.controlsForm.Show((IWin32Window) this);
    }

    private void linkThread_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start("http://forums.dota-allstars.com/index.php?showtopic=217814");
    }
  }
}
