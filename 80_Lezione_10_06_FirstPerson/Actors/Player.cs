using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _80_Lezione_10_06_FirstPerson
{
    class Player: IUpdatable
    {
        protected Controller controller;
        protected float speed = 10;
        protected Vector3 velocity;

        protected Vector2 mouseRawPosition;

        

        public int PlayerID { get; protected set; }

        public bool IsAlive;


        public Player(Controller ctrl, int playerID)
        {
            IsAlive = true;

            PlayerID = playerID;

            controller = ctrl;

            UpdateMngr.AddItem(this);

            mouseRawPosition = Game.Window.RawMousePosition;
        }

        public virtual void Input()
        {
            //camera movement
            float directionX = controller.GetHorizontal();
            float directionZ = -controller.GetVertical();

            Vector3 newVelocity = new Vector3(0);

            newVelocity += CameraMngr.MainCamera.Right * directionX * speed;
            newVelocity += CameraMngr.MainCamera.Forward * directionZ * speed;

            if(newVelocity.Length > speed)
            {
                newVelocity = newVelocity.Normalized() * speed;
            }

            velocity = newVelocity;

            //camera rotation
            Vector2 deltaMouse = (Game.Window.RawMousePosition - mouseRawPosition)* speed * Game.Window.DeltaTime;
            mouseRawPosition = Game.Window.RawMousePosition;

            CameraMngr.RotateCamera(new Vector3(-deltaMouse.Y*2,deltaMouse.X,0));
            
        }

        public void Update()
        {
            CameraMngr.MainCamera.Position3 += velocity * Game.Window.DeltaTime;
        }

        

        

        public void OnDie()
        {
            IsAlive = false;
            ((PlayScene)Game.CurrentScene).OnPlayerDies();
        }
    }
}
