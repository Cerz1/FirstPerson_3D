using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using Aiv.Fast3D;
using OpenTK;

namespace _80_Lezione_10_06_FirstPerson
{
    static class CameraMngr
    {
        private static Dictionary<string, Tuple<Camera, float>> cameras;

        public static PerspectiveCamera MainCamera;

        public static float CameraSpeed = 5;

        public static void Init()
        {
            MainCamera = new PerspectiveCamera(new Vector3(0, 2.2f, 8), new Vector3(0, 180, 0), 60, 0.1f, 100);
            
            cameras = new Dictionary<string, Tuple<Camera, float>>();
        }

        public static void RotateCamera(Vector3 eulerRot)
        {
            //MainCamera.EulerRotation3 += eulerRot;
        }
    }
}
