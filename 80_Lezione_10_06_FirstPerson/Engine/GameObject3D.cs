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
    class GameObject3D : GameObject
    {
        protected Mesh3[] meshes;
        protected List<Texture> textures;

        public GameObject3D(DrawLayer layer = DrawLayer.Playground) : base("", layer)
        {
            textures = new List<Texture>();
            IsActive = true;
        }

        public virtual void AddTexture(string textureName, bool repeatX=false, bool repeatY = false)
        {
            Texture t = GfxMngr.GetTexture(textureName);
            t.SetRepeatX(repeatX);
            t.SetRepeatY(repeatY);
            textures.Add(t);
        }

        protected virtual void SetPosition(Vector3 position)
        {
            for (int i = 0; i < meshes.Length; i++)
            {
                meshes[i].Position3 = position;
            }
        }

        public virtual void AssignObj(string filePath,Vector3 scale)
        {
            meshes = SceneImporter.LoadMesh(filePath, scale);
        }

        public override void Draw()
        {
            if (IsActive)
            {
                for (int i = 0; i < meshes.Length; i++)
                {
                    Texture t = i > textures.Count - 1 ? textures[0] : textures[i];
                    meshes[i].DrawPhong(t, ((PlayScene)Game.CurrentScene).DirectionalLight, ((PlayScene)Game.CurrentScene).AmbientColor);
                }
            }
        }

        public virtual void SetUVMul(int meshIndex,float numRepeats)
        {
            for (int i = 0; i < meshes[meshIndex].uv.Length; i++)
            {
                meshes[meshIndex].uv[i] *= numRepeats;
            }
            meshes[meshIndex].UpdateUV();
        }

        public override void Update()
        {
            //meshes[0].EulerRotation3 += new Vector3(0, 0, 30 * Game.Window.DeltaTime);
        }
    }
}
