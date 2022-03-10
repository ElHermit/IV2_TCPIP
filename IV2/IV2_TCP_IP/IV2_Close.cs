using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using JabilTest;


namespace IV2_TCP_IP
{
    class IV2_Close : JabilTest.Test
    {
        public IV2_Close(ScriptVariableSpace varSpace, object otherParamaters): 
            base (varSpace, otherParamaters)
        {

        }

        public override TestResult Execute()
        {
            try
            {
                Object myClient = this.GetObjectVariable("Argument0", "IV2_Client");

                TcpClient IV2_Client = (TcpClient)myClient;

                IV2_Client.Close();

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
