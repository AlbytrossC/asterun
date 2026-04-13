using System;
using System.Collections;
using UnityEngine;


    public static class AX_Xtra
    {
        /// <summary>
        /// Executes the <paramref name="function"/> after <paramref name="s"/> seconds
        /// </summary>
        /// <param name="function"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static IEnumerator ExecuteAfterSeconds(Action function, float s)
        {
        Debug.Log("ExecAfterSec");
            yield return new WaitForSeconds(s);
            function.Invoke();
            yield return new WaitForEndOfFrame();
        }
        /// <summary>
        /// Executes the <paramref name="function"/> after <paramref name="s"/> seconds in Realtime
        /// </summary>
        /// <param name="function"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static IEnumerator ExecuteAfterSecondsRealtime(Action function, float s)
        {
            yield return new WaitForSecondsRealtime(s);
            function.Invoke();
        }
}

