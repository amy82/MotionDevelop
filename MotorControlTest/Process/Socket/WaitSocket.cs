using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotorControlTest.Process.Socket
{
    public class WaitSocket
    {
        private enumStep eStep;
        private int nRetStep = 0;
        private int m_nStartStep = 0;

        private string[] socketName = {"X - Socket","XY - socket" };
        private enum enumStep
        {
            Start = 1,
            Wait,
            X_WriteSocket_Move,
            X_WriteSocket_Move_Check,
            X_VerifySocket_Move,
            X_VerifySocket_Move_Check,
            //
            Xy_WriteSocket_Move,
            Xy_WriteSocket_Move_Check,
            Xy_VerifySocket_Move,
            Xy_VerifySocket_Move_Check,
            //
            Wirte_Test_End_Check,
            Verify_Test_End_Check,
            End
        }
        public WaitSocket()
        {

        }
        public void setNext(int pSleep = 0)
        {
            if (pSleep > 0)
                Thread.Sleep(pSleep);

            eStep++;
            nRetStep = (int)eStep + m_nStartStep;
        }

        public void setStep(int pStep, int pSleep = 0)
        {
            if (pSleep > 0)
                Thread.Sleep(pSleep);

            eStep = (enumStep)pStep;
            nRetStep = (int)eStep + m_nStartStep;
        }
        public int FlowRun(int nStep)                 //  원점(1000 ~ 2000)
        {
            string szLog = "";
            //bool bRtn = false;

            nRetStep = nStep;


            eStep = (enumStep) nStep;
            switch (eStep)
            {
                case enumStep.Start:
                    setStep((int)enumStep.Wait);
                    break;

                case enumStep.Wait:
                    szLog = $"[Wait] Step - {eStep}";
                    Console.WriteLine(szLog);

                    if (GlobalClass.threadManager.socketx.IsTesting == true && GlobalClass.threadManager.socketxy.IsTesting == true)
                    {
                        break;
                    }
                    //if(GlobalClass.motionManager.socketMachine.

                    if (GlobalClass.threadManager.socketx.IsTesting == false)
                    {
                        if (GlobalClass.threadManager.hybridThreadManager._socket1.CurrentState == Process.SocketState.ReqLoad)
                        {
                            setStep((int)enumStep.X_VerifySocket_Move);
                            break;
                        }
                        else if (GlobalClass.threadManager.hybridThreadManager._socket1.CurrentState == Process.SocketState.Write_Complete)
                        {
                            setStep((int)enumStep.X_VerifySocket_Move);
                            break;
                        }
                    }
                    if (GlobalClass.threadManager.socketxy.IsTesting == false)
                    {
                        if (GlobalClass.threadManager.hybridThreadManager._socket2.CurrentState == Process.SocketState.Ready)
                        {
                            setStep((int)enumStep.Xy_WriteSocket_Move);
                            break;
                        }
                        else if (GlobalClass.threadManager.hybridThreadManager._socket2.CurrentState == Process.SocketState.Write_Complete)
                        {
                            setStep((int)enumStep.Xy_VerifySocket_Move);
                            break;
                        }
                    }
                    break;

                case enumStep.X_WriteSocket_Move:
                    Console.WriteLine($"[WaitSocket] {socketName[0]} Write Pos Move - {nStep}");    //3
                    setNext();
                    break;

                case enumStep.X_WriteSocket_Move_Check:
                    GlobalClass.threadManager.hybridThreadManager._socket1.CurrentState = Process.SocketState.Req_Write;
                    Console.WriteLine($"[WaitSocket] {socketName[0]} Write Pos Move Complete - {nStep}");   //4
                    setStep((int)enumStep.End);
                    break;

                case enumStep.X_VerifySocket_Move:
                    Console.WriteLine($"[WaitSocket] {socketName[0]} Verify Pos Move - {nStep}");
                    setNext();
                    break;

                case enumStep.X_VerifySocket_Move_Check:
                    GlobalClass.threadManager.hybridThreadManager._socket1.CurrentState = Process.SocketState.Req_Verify;
                    Console.WriteLine($"[WaitSocket] {socketName[0]} Verify Pos Move Complete - {nStep}");
                    setStep((int)enumStep.End);
                    break;

                case enumStep.Xy_WriteSocket_Move:
                    Console.WriteLine($"[WaitSocket] {socketName[1]} Write Pos Move - {nStep}");
                    setNext();
                    break;

                case enumStep.Xy_WriteSocket_Move_Check:
                    GlobalClass.threadManager.hybridThreadManager._socket2.CurrentState = Process.SocketState.Req_Write;
                    Console.WriteLine($"[WaitSocket] {socketName[1]} Write Pos Move Complete - {nStep}");
                    setStep((int)enumStep.End);
                    break;

                case enumStep.Xy_VerifySocket_Move:
                    Console.WriteLine($"[WaitSocket] {socketName[1]} Verify Pos Move - {nStep}");
                    setNext();
                    break;

                case enumStep.Xy_VerifySocket_Move_Check:
                    GlobalClass.threadManager.hybridThreadManager._socket2.CurrentState = Process.SocketState.Req_Verify;
                    Console.WriteLine($"[WaitSocket] {socketName[1]} Verify Pos Move Complete - {nStep}");
                    setStep((int)enumStep.End);
                    break;

                case enumStep.Wirte_Test_End_Check:
                    //검사 종료됐는지 확인 후 배출
                    if (true)
                    {
                        //어떤 소켓인지 체크 필요 (1 or 2)
                    }
                    Console.WriteLine($"[WaitSocket] {socketName[1]} Wirte_Test_End_Check - {nStep}");
                    break;
                case enumStep.Verify_Test_End_Check:
                    if (true)
                    {
                        //어떤 소켓인지 체크 필요 (1 or 2)
                    }
                    Console.WriteLine($"[WaitSocket] {socketName[1]} Verify_Test_End_Check - {nStep}");
                    break;

                case enumStep.End:
                    nRetStep = (int)enumStep.Wait;
                    break;
                default:
                    //[ORIGIN] STEP ERR
                    nRetStep = -1;
                    break;
            }
            return nRetStep;
        }
    }
}
