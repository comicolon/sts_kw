using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ATK_01
{
    public class Condition
    {
        public int Index { get; set; }                      // 조건식 번호
        public string Name { get; set; }                    // 조건식 이름
        public string screenNum;                            // 화면번호
        public List<string> itemCode = new List<string>();  //조건식에 들어온 아이템코드 리스트
        public int ComboBoxNum { get; set; }                //조건식이 선택된 콤보박스 번호
        public int GridNum { get; set; }                    //조건식이 선택된 그리드 번호
        public DataGridView dataGridView { get; set; }      //조건식이 선택된 그리드
        public ComboBox comboBox { get; set; }              // 조건식이 선택된 콤보박스
        public bool isSelected = false;                     // 선택되었는지 여부


        public Condition(int index, string name)
        {
            this.Index = index;
            this.Name = name;
        }
    }
}
