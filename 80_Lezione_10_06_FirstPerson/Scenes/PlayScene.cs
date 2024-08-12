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
    class PlayScene : Scene
    {
        // Lights
        public DirectionalLight DirectionalLight;
        public Vector3 AmbientColor;

        Player player;

        public PlayScene() : base()
        {

        }

        public override void Start()
        {
            LoadAssets();

            CameraMngr.Init();

            DirectionalLight = new DirectionalLight(new Vector3(0, 0, 3).Normalized());
            AmbientColor = new Vector3(0.9f);

            // Player
            player = new Player(Game.GetController(0), 0);

            // Controllers
            Controller controller = Game.GetController(1);

            if (controller is KeyboardController)
            {
                List<KeyCode> keys = new List<KeyCode>();
                keys.Add(KeyCode.Up);
                keys.Add(KeyCode.Down);
                keys.Add(KeyCode.Right);
                keys.Add(KeyCode.Left);
                

                KeysList keyList = new KeysList(keys);
                controller = new KeyboardController(1, keyList);
            }

            // 3D Objects
            Floor floor = new Floor(Vector3.Zero);

            GameObject3D storm = new GameObject3D(DrawLayer.Playground);
            storm.AddTexture("Stormtrooper", true, true);
            storm.AssignObj("Assets/Stormtrooper.obj", Vector3.One);

            base.Start();
        }

        private static void LoadAssets()
        {
            GfxMngr.AddTexture("grass", "Assets/cartoon_grass.png");
            GfxMngr.AddTexture("checker", "Assets/checker.png");
            GfxMngr.AddTexture("Stormtrooper", "Assets/Stormtrooper.png");
        }

        public override void Input()
        {
            if (player.IsAlive)
            {
                player.Input();
            }
        }

        public override void Update()
        {
            UpdateMngr.Update();
        }

        public override Scene OnExit()
        {
            UpdateMngr.ClearAll();
            DrawMngr.ClearAll();
            GfxMngr.ClearAll();

            return base.OnExit();
        }

        public override void Draw()
        {
            DrawMngr.Draw();
        }

        public virtual void OnPlayerDies()
        {
            IsPlaying = false;
        }
    }
}
