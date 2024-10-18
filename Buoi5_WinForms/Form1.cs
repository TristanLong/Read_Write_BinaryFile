using System.ComponentModel;
//using System.Runtime.Serialization.Formatters.Binary; // Thư viện đọc ghi file nhị phân bản 6.0 

namespace Buoi5_WinForms
{
    // datagridview không liên kết với dictionary 
    public partial class FormStudentManagement : Form
    {
        private List<Student> list;
        public FormStudentManagement()
        {
            InitializeComponent();
        }

        private void FormStudentManagement_Load(object sender, EventArgs e)
        {
            list = new List<Student>();

            //// Read file bản 6.0 
            //FileStream file = new FileStream("student.dat", FileMode.Open);
            //BinaryFormatter binaryFile = new BinaryFormatter(); // Không sai chỉ là 8.0 bị lỗi phải về 6.0
            //list = binaryFile.Deserialize(file) as List<Student>;
            //file.Close();
            //Show();

            // Read file bản 8.0 
            if (File.Exists("student.dat"))
            {
                using (FileStream fs = new FileStream("student.dat", FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    while (fs.Position < fs.Length)
                    {
                        Student student = new Student
                        {
                            ID = reader.ReadString(),
                            Name = reader.ReadString(),
                            Adress = reader.ReadString(),
                            Birthday = DateTime.FromBinary(reader.ReadInt64()), // Đọc từ nhị phân
                            Gender = reader.ReadBoolean()
                        };
                        list.Add(student);
                    }
                }
                Show();
                MessageBox.Show("Binary file read succeeded");
            }
            else
            {
                MessageBox.Show("Binary file not found");
            }
        }

        private void Show()
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

            list.Add(student);
            Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // SelectedRows: trả về dòng được chọn 
            foreach (DataGridViewRow row in dgvList.SelectedRows)
            {
                // Lấy MSSV ở dòng mình chọn (lấy giá trị cột[0])
                string ID = row.Cells[0].Value.ToString();
                Student x = null;
                foreach (Student a in list)
                {
                    if (a.ID == ID)
                    {
                        x = a;
                        break;
                    }
                }

                if (x != null)
                {
                    list.Remove(x);
                    break;
                }
            }
            Show();
        }

        // Dụa vào ID nên không sửa ID được 
        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            // SelectedRows: trả về dòng được chọn 
            foreach (DataGridViewRow row in dgvList.SelectedRows)
            {
                // Lấy MSSV ở dòng mình chọn (lấy giá trị cột[0])
                string ID = row.Cells[0].Value.ToString();
                Student x = null;
                foreach (Student a in list)
                {
                    if (a.ID == ID)
                    {
                        x = a;
                        break;
                    }
                }

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
            string ID = txtID.Text;
            Student x = null;
            foreach (Student a in list)
            {
                if (a.ID == ID)
                {
                    x = a;
                    break;
                }
            }

            if (x != null)
            {
                x.Name = txtName.Text;
                x.Adress = txtAdress.Text;
                x.Gender = rdoMen.Checked;
                x.Birthday = dtpBirthday.Value;

                Show();
            }
        }

        private void btnWriteBinaryFile_Click(object sender, EventArgs e)
        {
            //FileStream file = new FileStream("student.dat", FileMode.Create); // Open => read, Create => write

            //// 8.0 không hỗ trợ nên về 6.0 
            //BinaryFormatter binaryFile = new BinaryFormatter();
            //binaryFile.Serialize(file, list);
            //file.Close();

            //MessageBox.Show("Write Successed");

            using (FileStream fs = new FileStream("student.dat", FileMode.Create, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                foreach (var student in list)
                {
                    writer.Write(student.ID);
                    writer.Write(student.Name);
                    writer.Write(student.Adress);
                    writer.Write(student.Birthday.ToBinary());  // Ghi dưới dạng nhị phân
                    writer.Write(student.Gender);
                }
            }
            MessageBox.Show("Binary file write succeeded");
        }
    }
}
