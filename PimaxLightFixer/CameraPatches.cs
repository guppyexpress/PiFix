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
        private static Matrix4x4 matrixAdditave = new Matrix4x4();
        private static int selectedMatrixIndex = 0;
        private static bool keyDown = false;

        public static void Postfix(Camera.StereoscopicEye eye, ref Matrix4x4 __result)
        {
            //if (Input.GetKey(KeyCode.RightArrow))
            //{
            //    matrixAdditave[selectedMatrixIndex] += 0.01f;
            //    Console.WriteLine($"matrix {selectedMatrixIndex} offset is {matrixAdditave[selectedMatrixIndex] }");
            //}
            //else if (Input.GetKey(KeyCode.LeftArrow))
            //{
            //    matrixAdditave[selectedMatrixIndex] -= 0.01f;
            //    Console.WriteLine($"matrix {selectedMatrixIndex} offset is {matrixAdditave[selectedMatrixIndex] }");
            //}

            //if (Input.anyKey)
            //{
            //    if (!keyDown)
            //    {
            //        if (Input.GetKey(KeyCode.UpArrow))
            //        {
            //            selectedMatrixIndex++;

            //            if (selectedMatrixIndex > 15)
            //                selectedMatrixIndex = 15;

            //            keyDown = true;
            //            Console.WriteLine($"Selected matrix {selectedMatrixIndex}");
            //        }
            //        else if (Input.GetKey(KeyCode.DownArrow))
            //        {
            //            selectedMatrixIndex--;

            //            if (selectedMatrixIndex < 0)
            //                selectedMatrixIndex = 0;

            //            keyDown = true;
            //            Console.WriteLine($"Selected matrix {selectedMatrixIndex}");
            //        }
            //        else if (Input.GetKey(KeyCode.R))
            //        {
            //            matrixAdditave[selectedMatrixIndex] = 0;
            //            keyDown = true;
            //            Console.WriteLine($"reset matrix {selectedMatrixIndex}");
            //        }
            //    }
            //}
            //else if (keyDown)
            //    keyDown = false;
            //for (int i = 0; i < 15; i++)
            //    __result[i] += eye == Camera.StereoscopicEye.Left ? -matrixAdditave[i] : matrixAdditave[i];


            // I need the stupid ground reflections to 300% fix this or im smashing my head into a brick wall doing nothing

            /* Resources.FindObjectsOfTypeAll<MirroredGameNoteController>();
             Resources.FindObjectsOfTypeAll<MirroredBombNoteController>();
             Resources.FindObjectsOfTypeAll<MirroredObstacleController>(); */

            //what is above is the precurser code for the reflections fix. please dont touch it.

           

            //pimax 5k values
            if (Plugin.Config.PimaxType == PiFix.Configuration.PimaxType.FiveK)
            {
                __result[8] += eye == Camera.StereoscopicEye.Right ? 0.4900f : -0.23f;
                __result[8] += eye == Camera.StereoscopicEye.Left ? 0.23f : -0.23f;
            }
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

   // [HarmonyPatch(typeof(TubeBloomPrePassLight))]
   // [HarmonyPatch("FillMeshData", MethodType.Normal)]
  //  public class TubeBloomPrepassPatches
   // {
     //   public static bool Prefix(int lightNum, Vector3[] vertices, Color[] colors, Vector4[] viewPos, Matrix4x4 viewMatrix, Matrix4x4 projectionMatrix, float lineWidth)
     //   {
      //      return true;
      //  }
   // }
}
