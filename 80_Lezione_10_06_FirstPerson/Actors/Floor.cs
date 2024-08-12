using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast3D;

namespace _80_Lezione_10_06_FirstPerson
{
    class Floor : GameObject3D
    {
        public Floor(Vector3 position,DrawLayer layer = DrawLayer.Background) : base(layer)
        {
            meshes = new Mesh3[1];
            meshes[0] = new Plane();
            meshes[0].Rotation3 = new Vector3(-MathHelper.PiOver2, 0, 0);
            meshes[0].Position3 = position;
            meshes[0].Scale3 = new Vector3(40, 40, 0);

            SetUVMul(0, 10);

            AddTexture("grass",true,true);
        }
    }
}
