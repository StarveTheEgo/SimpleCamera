// Decompiled with JetBrains decompiler
// Type: SimpleCamera.CameraManager
// Assembly: SimpleCamera, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

using ReplaySeeker;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace SimpleCamera
{
    public class CameraManager
    {
        private IProcessMemory pMemory;
        private int memoryBlockPosition;
        private int memoryBlockOther;
        private int memoryUnitPointer;
        private int memoryBlockFog;
        public static int found;

        public float cameraX
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockPosition + 272);
            }
        }

        public float cameraY
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockPosition + 276);
            }
        }

        public float targetX
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockPosition + 432);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockPosition + 432, value);
            }
        }

        public float targetY
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockPosition + 436);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockPosition + 436, value);
            }
        }

        public float distance
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockOther + 832);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockOther + 832, value);
            }
        }

        public float distanceMin
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockOther + 840);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockOther + 840, value);
            }
        }

        public float distanceMax
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockOther + 844);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockOther + 844, value);
            }
        }

        public float viewMaxDistance
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockOther + 972);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockOther + 972, value);
                this.pMemory.WriteFloat32(this.memoryBlockOther + 984, value);
            }
        }

        public float viewMinDistance
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockOther + 1124);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockOther + 1124, value);
            }
        }

        public float fov
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockOther + 1252);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockOther + 1252, value);
            }
        }

        public float fovMin
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockOther + 1260);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockOther + 1260, value);
            }
        }

        public float fovMax
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockOther + 1264);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockOther + 1264, value);
            }
        }

        public float roll
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockOther + 1392);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockOther + 1392, value);
            }
        }

        public float yaw
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockOther + 1532);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockOther + 1532, value);
            }
        }

        public float pitch
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockOther + 1672);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockOther + 1672, value);
            }
        }

        public float zOffset
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockOther + 1812);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockOther + 1812, value);
            }
        }

        public float fogDensity
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockFog + 476);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockFog + 476, value);
            }
        }

        public float fogMinDistance
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockFog + 508);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockFog + 508, value);
            }
        }

        public float fogMaxDistance
        {
            get
            {
                return this.pMemory.ReadFloat32(this.memoryBlockFog + 540);
            }
            set
            {
                this.pMemory.WriteFloat32(this.memoryBlockFog + 540, value);
            }
        }

        public CameraManager(IProcessMemory pMemory, int memoryBlockPosition, int memoryBlockOther, int memoryUnitPointer, int memoryBlockFog)
        {
            this.pMemory = pMemory;
            this.memoryBlockPosition = memoryBlockPosition;
            this.memoryBlockOther = memoryBlockOther;
            this.memoryUnitPointer = memoryUnitPointer;
            this.memoryBlockFog = memoryBlockFog;
        }

        public static int GetDLLBase(IProcessMemory pMemory, int address)
        {
            Process[] processesByName = Process.GetProcessesByName("war3");
            ProcessModule processModule = (ProcessModule)null;
            string text = "";
            if (processesByName.Length > 0)
            {
                foreach (ProcessModule module in (ReadOnlyCollectionBase)Process.GetProcessById(processesByName[0].Id).Modules)
                {
                    text = text + "\n" + module.BaseAddress.ToString("X") + " -> " + module.ModuleName;
                    if (address > module.BaseAddress.ToInt32() && (processModule == null || module.BaseAddress.ToInt32() > processModule.BaseAddress.ToInt32()))
                        processModule = module;
                }
            }
            Clipboard.SetText(text);
            int num1 = (int)MessageBox.Show(text ?? "");
            int num2 = (int)MessageBox.Show(address.ToString() + "\n\n" + processModule.ModuleName + " -> " + processModule.BaseAddress.ToString());
            return 0;
        }

        private static void GetMemoryLocationsForReplayData(IProcessMemory pMemory, out int memPosition, out int memOther, out int memUnitPointer, out int memFog)
        {
            memPosition = 0;
            memOther = 0;
            memUnitPointer = 0;
            memFog = 0;
            for (int index = 0; index <= 12288; ++index)
            {
                pMemory.OpenProcess();
                if (memOther == 0)
                {
                    int num1 = (index << 16) + 9472;
                    if (pMemory.ReadProcessInt32(num1 + 832 + 44) == 1080)
                    {
                        memOther = num1;
                        memPosition = pMemory.ReadProcessInt32(num1 + 1868) & -65536;
                    }
                    int num2 = index << 16;
                    if (pMemory.ReadProcessInt32(num2 + 832 + 44) == 1080)
                    {
                        memOther = num2;
                        memPosition = pMemory.ReadProcessInt32(num2 + 1868) & -65536;
                    }
                    int num3 = (index << 16) + 9536;
                    if (pMemory.ReadProcessInt32(num3 + 832 + 44) == 1148)
                    {
                        memOther = num3;
                        memPosition = pMemory.ReadProcessInt32(num3 + 1868) & -65536;
                    }
                }
                if (memUnitPointer == 0)
                {
                    int num = index << 16;
                    if (pMemory.ReadProcessInt32(num + 164) == 1767994469)
                        memUnitPointer = num + 476;
                }
                if (memFog == 0)
                {
                    int num = index << 16;
                    if (pMemory.ReadProcessInt32(num + 108) == 1196377672)
                        memFog = num;
                }
            }
            try
            {
                pMemory.CloseHandle();
            }
            catch
            {
                int num = (int)MessageBox.Show("Error in memory handler!");
            }
        }

        public static CameraManager FromProcess(IProcessMemory process)
        {
            int memPosition = 0;
            int memOther = 0;
            int memUnitPointer = 0;
            int memFog = 0;
            CameraManager.GetMemoryLocationsForReplayData(process, out memPosition, out memOther, out memUnitPointer, out memFog);
            if (memPosition != 0 && memOther != 0 && (memUnitPointer != 0 && memFog != 0))
                return new CameraManager(process, memPosition, memOther, memUnitPointer, memFog);
            if (memPosition == 0)
                CameraManager.found |= 1;
            if (memOther == 0)
                CameraManager.found |= 2;
            if (memUnitPointer == 0)
                CameraManager.found |= 4;
            if (memFog == 0)
                CameraManager.found |= 8;
            return (CameraManager)null;
        }

        public CameraState getCurrentState()
        {
            return new CameraState((double)this.targetX, (double)this.targetY, (double)this.yaw, (double)this.pitch, (double)this.roll, (double)this.distance);
        }

        public void setState(CameraState state)
        {
            this.targetX = (float)state.tarx;
            this.targetY = (float)state.tary;
            this.yaw = (float)state.yaw;
            this.pitch = (float)state.pitch;
            this.roll = (float)state.roll;
            this.distance = (float)state.distance;
        }

        public Unit getSelectedUnit()
        {
            int memoryPosition = this.pMemory.ReadInt32(this.memoryUnitPointer);
            if (memoryPosition != 0)
                return new Unit(memoryPosition, this.pMemory);
            return (Unit)null;
        }
    }
}
