using System.ComponentModel;
//using System.Runtime.Serialization.Formatters.Binary; // Thư viện đọc ghi file nhị phân bản 6.0 

namespace Buoi5_WinForms
{
    // datagridview không liên kết với dictionary 
    public partial class FormStudentManagement : Form
    {
        private List<Student> list;
        CHandleStudent handle;
        public FormStudentManagement()
        {
            InitializeComponent();
        }

        private void FormStudentManagement_Load(object sender, EventArgs e)
        {
            handle = new CHandleStudent();
            if (handle.readData("student.dat") == true)
            {
                Show(handle.getStudentList());
            }
            else
            {
                MessageBox.Show("Can not read data");
            }
        }

        private void Show(List<Student> list)
        {
            // Liên kết giữa dữ liệu đối tượng với giao diện  
            BindingSource bs = new BindingSource();
            bs.DataSource = list; // Liên kết bindingsource với dữ liệu
            dgvList.DataSource = bs;// Liên kết bindingsource với data grid view 

            // Tạo liên kết từng cột bên Winforms 

        }


        // Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show(
                "Do you want to exit",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (exit == DialogResult.Yes)
                Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.ID = txtID.Text;
            student.Name = txtName.Text;
            student.Adress = txtAdress.Text;
            student.Birthday = dtpBirthday.Value;
            student.Gender = rdoMen.Checked;

            if (handle.add(student) == true)
            {
                Show(handle.getStudentList());
            }
            else
            {
                MessageBox.Show("Error when add student");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           foreach(DataGridViewRow row in dgvList.SelectedRows)
            {
                string ID = row.Cells[0].Value.ToString();
                if(handle.remove(ID)==true) break;
            }
            Show(handle.getStudentList());
        }

        // Dụa vào ID nên không sửa ID được 
        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            // SelectedRows: trả về dòng được chọn 
            foreach (DataGridViewRow row in dgvList.SelectedRows)
            {
                // Lấy MSSV ở dòng mình chọn (lấy giá trị cột[0])
                string ID = row.Cells[0].Value.ToString();
                Student x = handle.search(ID);
                
                if (x != null)
                {
                    txtID.Text = x.ID;
                    txtName.Text = x.Name;
                    txtAdress.Text = x.Adress;
                    dtpBirthday.Value = x.Birthday;

                    if (x.Gender)
                        rdoMen.Checked = true;
                    else rdoWomen.Checked = true;

                    break;
                }
            }
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            Student x = new Student();
            x.ID = txtID.Text;
            x.Name = txtName.Text;
            x.Adress = txtAdress.Text;
            x.Gender = rdoMen.Checked;
            x.Birthday = dtpBirthday.Value;

            if (handle.alter(x) == true)
            {
                Show(handle.getStudentList());
            }
        }

        private void btnWriteBinaryFile_Click(object sender, EventArgs e)
        {
            if (handle.writeData("student.dat") == true)
            {
                MessageBox.Show("Successful");
            }
            else
            {
                MessageBox.Show("Can not write data");
            }
        }
    }
}

