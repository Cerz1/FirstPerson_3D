﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;

namespace _80_Lezione_10_06_FirstPerson
{
    class KeyboardController : Controller
    {
        protected KeysList keysConfig;

        public KeyboardController(int ctrlIndex, KeysList keys) : base(ctrlIndex)
        {
            keysConfig = keys;
        }

        public override float GetHorizontal()
        {
            float direction = 0.0f;

            if(Game.Window.GetKey(keysConfig.GetKey(KeyName.Right)))
            {
                direction = 1;
            }
            else if(Game.Window.GetKey(keysConfig.GetKey(KeyName.Left)))
            {
                direction = -1;
            }

            return direction;
        }

        public override float GetVertical()
        {
            float direction = 0.0f;

            if (Game.Window.GetKey(keysConfig.GetKey(KeyName.Up)))
            {
                direction = -1;
            }
            else if (Game.Window.GetKey(keysConfig.GetKey(KeyName.Down)))
            {
                direction = 1;
            }

            return direction;
        }
    }
}
