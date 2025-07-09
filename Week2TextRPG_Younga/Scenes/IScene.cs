using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2TextRPG_Younga.Scenes
{
    internal interface IScene
    {
        SceneType SceneType { get; set; }

        void LoadScene();
    }
}
