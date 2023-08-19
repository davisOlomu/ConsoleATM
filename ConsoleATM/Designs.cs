using System;

namespace ConsoleATM
{
    internal static class Designs
    {
        /// <summary>
        /// Position text central to the console window.
        /// </summary>
        /// <param name="SpacesToAdd"></param>
        /// <param name="Msg"></param>
        /// <param name="Alignment"></param>
        /// <returns></returns>
        public static string AlignText(int SpacesToAdd, string Msg, string Alignment = "R")
        {
            if (Alignment == "L")
                Msg = Msg.PadLeft(SpacesToAdd + Msg.Length);
            else
            {
                Msg = Msg.PadLeft(SpacesToAdd + Msg.Length);
                Msg = Msg.PadRight((98 - Msg.Length) + Msg.Length);
            }
            return Msg;
        }
    }
}
