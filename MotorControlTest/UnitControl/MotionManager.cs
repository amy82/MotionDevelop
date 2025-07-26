using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorControlTest.UnitControl
{
    public class MotionManager
    {
        public UnitControl.TransferUnit transferUnit;
        public UnitControl.MagazineUnit magazineUnit;
        public UnitControl.LiftUnit liftUnit;
        public UnitControl.SocketUnit socketUnit;

        public MotionManager()
        {
            transferUnit = new TransferUnit();
            magazineUnit = new MagazineUnit();
            liftUnit = new LiftUnit();
            socketUnit = new SocketUnit();
        }

        //여러 클래스가 동일한 역할을 수행해야 할 때	interface
        //공통된 필드와 일부 기본 로직을 공유해야 할 때	abstract class

        //외부에서 구현을 강제하려는 목적 (예: API 작성)	interface
    }
}
