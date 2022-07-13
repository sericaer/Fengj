using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.MyUIExtentions
{
#if UNITY_EDITOR
    public static class MyUIExtention
    {
        [MenuItem("GameObject/UI/MyUIExtentions/DialogPanel")]
        public static void AddDialogPanel(MenuCommand menuCommand)
        {
            DialogPanel.CreateGameObject(menuCommand.context as GameObject);
        }

        [MenuItem("GameObject/UI/MyUIExtentions/TimeSpeedControl")]
        public static void AddTimeSpeedControl(MenuCommand menuCommand)
        {
            TimeSpeedControl.CreateGameObject(menuCommand.context as GameObject);
        }

        [MenuItem("GameObject/UI/MyUIExtentions/DragDropContainer")]
        public static void AddDragDropContainer(MenuCommand menuCommand)
        {
            DragDropContainer.CreateGameObject(menuCommand.context as GameObject);
        }
    }

#endif
}
