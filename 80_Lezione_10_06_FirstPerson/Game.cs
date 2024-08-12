using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace _80_Lezione_10_06_FirstPerson
{
    static class Game
    {
        public static Window Window;
        public static Scene CurrentScene { get; private set; }
        public static float DeltaTime { get { return Window.DeltaTime; } }

        private static KeyboardController keyboardCtrl;


        public static void Init()
        {
            Window = new Window(1280, 720, "FirstPerson3D");
            Window.SetVSync(false);
            Window.EnableDepthTest();
            Window.SetClearColor(new Vector4(0.2f, 0.2f, 0.6f, 1));

            PlayScene playScene = new PlayScene();
            playScene.NextScene = null;

            CurrentScene = playScene;

            // CONTROLLER

            //create default keys for keyboard controller
            List<KeyCode> keys = new List<KeyCode>();
            keys.Add(KeyCode.W);
            keys.Add(KeyCode.S);
            keys.Add(KeyCode.D);
            keys.Add(KeyCode.A);

            KeysList keyList = new KeysList(keys);

            // Always create a keyboard controller (init at 0 cause we only have 1 keyboard)
            keyboardCtrl = new KeyboardController(0, keyList);
        }

        public static Controller GetController(int index)
        {
            Controller ctrl = keyboardCtrl;

            return ctrl;
        }

        public static void Play()
        {
            CurrentScene.Start();

            while (Window.IsOpened)
            {
                // Show FPS on Window Title Bar
                Window.SetTitle($"FPS: {1f / Window.DeltaTime}");

                // Exit when ESC is pressed
                if (Window.GetKey(KeyCode.Esc))
                {
                    break;
                }

                if (!CurrentScene.IsPlaying)
                {
                    Scene nextScene = CurrentScene.OnExit();

                    if(nextScene != null)
                    {
                        CurrentScene = nextScene;
                        CurrentScene.Start();
                    }
                    else
                    {
                        return;
                    }
                }

                // INPUT
                CurrentScene.Input();

                // UPDATE
                CurrentScene.Update();

                // DRAW
                CurrentScene.Draw();

                Window.Update();
            }
        }
    }
}
