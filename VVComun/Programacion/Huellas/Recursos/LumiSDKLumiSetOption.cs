/***************************************************************************************/
// ©Copyright 2016 HID Global Corporation/ASSA ABLOY AB. ALL RIGHTS RESERVED.
//
// For a list of applicable patents and patents pending, visit www.hidglobal.com/patents/
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS 
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER 
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN 
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//
/***************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace ValleVerdeComun.Programacion.Huellas.Recursos
{
    public static class LumiSDKLumiSetOption
    {
        // LumiAPI.dll is loaded in the Main() function of the Program.cs for the 
        // CSharpExample.exe
        // LumiSetOption declared for the Override trigger int pointer
        [DllImport(LumiSDKWrapper.LUMI_API_DLL)]
        static extern LumiSDKWrapper.LumiStatus LumiSetOption(uint hHandle,
                                                    LumiSDKWrapper.LUMI_OPTIONS option,
                                                    ref int pArgument,
                                                    uint nArgumentSize);

        public static LumiSDKWrapper.LumiStatus OverrideTrigger(uint handle, bool overrideTrigger)
        {
            int argument = 0;
            if (overrideTrigger) argument = 1;
            return LumiSetOption(handle, LumiSDKWrapper.LUMI_OPTIONS.LUMI_OPTION_SET_OVERRIDE_HEARTBEAT_DISPLAY, ref argument, sizeof(int));  
        }

        public static LumiSDKWrapper.LumiStatus SetPresenceDetectionMode(uint handle, LumiSDKWrapper.LUMI_PRES_DET_MODE pdMode)
        {
            int argument = (int)pdMode;
            return LumiSetOption(handle, LumiSDKWrapper.LUMI_OPTIONS.LUMI_OPTION_SET_PRESENCE_DET_MODE, ref argument, sizeof(int));  
        }

        public static LumiSDKWrapper.LumiStatus SetPresenceDetectionThreshold(uint handle, LumiSDKWrapper.LUMI_PRES_DET_THRESH thresh)
        {
            int argument = (int)thresh;
            return LumiSetOption(handle, LumiSDKWrapper.LUMI_OPTIONS.LUMI_OPTION_SET_PRESENCE_DET_THRESH, ref argument, sizeof(int)); 
        }
    }
}
