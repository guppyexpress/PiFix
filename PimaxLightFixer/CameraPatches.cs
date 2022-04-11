using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace PiFix

{
    [HarmonyPatch(typeof(Camera), new Type[] { typeof(Camera.StereoscopicEye) })]
    [HarmonyPatch("GetStereoProjectionMatrix", MethodType.Normal)]
    public class CameraPatches

    

    {

        public static void Postfix(Camera.StereoscopicEye eye, ref Matrix4x4 __result)
           
        {

           

            //pimax 5k values
            if (Plugin.Config.PimaxType == PiFix.Configuration.PimaxType.FiveK)
            {
                __result[8] += eye == Camera.StereoscopicEye.Right ? 0.4900f : -0.23f;
                __result[8] += eye == Camera.StereoscopicEye.Left ? 0.23f : -0.23f;


            }

            //somehow the exact same code but mentioning only the left eye can mess with reflections and idk how that works but sure thing!

        /*    if (Plugin.Config.PimaxType == PiFix.Configuration.PimaxType.FiveK)
            {
                __result[8] += eye == Camera.StereoscopicEye.Left ? 0.00f : -0.137f;
                     __result[8] += eye == Camera.StereoscopicEye.Right ? 0.00f : -0.1250f;
             
              
            }
        */
            //pimax 8k values
            else if (Plugin.Config.PimaxType == PiFix.Configuration.PimaxType.EightK)
            {
                __result[8] += eye == Camera.StereoscopicEye.Right ? 0.1660f : -0.00f;
            }
            //pimax 12k values
            else if (Plugin.Config.PimaxType == PiFix.Configuration.PimaxType.TwelveK)
            {
                __result[8] += eye == Camera.StereoscopicEye.Right ? 0.05120f : -0.443f;
                __result[8] += eye == Camera.StereoscopicEye.Left ? 0.443f : -0.443f;
           }
        }

    }

}
/*personal note: the reason why reflections are on the left is because i shifted lighting to the left. 
 * which not only alligned the reflections. but also moved all reflections to the left its not crosseye'd anymore (thank goodness) but
 it isnt in the middle perfectly*/