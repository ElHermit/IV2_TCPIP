using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using JabilTest;


namespace IV2_TCP_IP
{
    public class IV2_Open : JabilTest.Test
    {
        public IV2_Open(ScriptVariableSpace varSpace, object otherParameters):
            base (varSpace, otherParameters)
        {

        }
        public override TestResult Execute()
        {
            string ipAddress = this.GetStringVariable("Argument0", "ipAddress");
            int portNumber = this.GetIntegerVariable("Argument1", "portNumber");

            try
            {
                TcpClient IV2_Client = new TcpClient(ipAddress, portNumber);

                ScriptVariable svReturn = new ScriptVariable("ReturnValue0", VariableType.Object, IV2_Client);
                VariableSpace.setVariable(svReturn);
                testResult.Status = TestStatus.Pass;
            }
            catch (ArgumentNullException e)
            {
                ScriptVariable sv = new ScriptVariable("ReturnValue0", VariableType.Object, null);
                VariableSpace.setVariable(sv);
                VariableSpace.UpdateStatusText(e.Message);
                testResult.ErrorMessage = e.Message;
                testResult.Status = TestStatus.Fail;
            }
            catch (SocketException e)
            {
                ScriptVariable sv = new ScriptVariable("ReturnValue0", VariableType.Object, null);
                VariableSpace.setVariable(sv);
                VariableSpace.UpdateStatusText(e.Message);
                testResult.ErrorMessage = e.Message;
                testResult.Status = TestStatus.Fail;
            }
            return testResult;
        }
    }
}
