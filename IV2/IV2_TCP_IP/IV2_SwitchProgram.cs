using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using JabilTest;

namespace IV2_TCP_IP
{
    class IV2_SwitchProgram : JabilTest.Test
    {
        public IV2_SwitchProgram(ScriptVariableSpace varSpace, object otherParamaters) :
            base(varSpace, otherParamaters)
        {

        }
        public override TestResult Execute()
        {
            try
            {
                Object myClient = this.GetObjectVariable("Argument0", "IV2_Client");
                TcpClient IV2_Client = (TcpClient)myClient;

                String programNumber = this.GetStringVariable("Argument1", "Program_Number");

                String programSwitchCommand = "PW," + programNumber + "\r";
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(programSwitchCommand);

                NetworkStream stream = IV2_Client.GetStream();

                stream.Write(data, 0, data.Length);

                data = new byte[256];

                string responseData = String.Empty;

                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

                testResult.Status = TestStatus.Pass;

            }
            catch (System.Exception e)
            {
                testResult.ErrorMessage = e.Message;
                testResult.Status = TestStatus.Fail;
            }

            return testResult;
        }
    }
}
