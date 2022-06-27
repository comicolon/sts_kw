using AxKHOpenAPILib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATK_01
{
    public class LoginManager
    {
        private readonly AxKHOpenAPILib.AxKHOpenAPI OpenAPI = MainForm.mainForm.axKHOpenAPI1;

        public LoginManager()
        {
            OpenAPI.OnEventConnect += api_OnEventConnect;
        }


        public void Login()
        {
            OpenAPI.CommConnect();
        }
        private void api_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                InstanceManager.bootDataManager.LoginSucces();
            }
            else if (e.nErrCode == 100)
                MessageBox.Show("정보교환 실패");
            else if (e.nErrCode == 101)
                MessageBox.Show("서버접속 실패");
            else if (e.nErrCode == 102)
                MessageBox.Show("버전처리 실패");
            else
                MessageBox.Show("나도 몰라 오류");
        }

    }
}
