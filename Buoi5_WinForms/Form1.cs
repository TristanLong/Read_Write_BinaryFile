using System.ComponentModel;
//using System.Runtime.Serialization.Formatters.Binary; // Thư viện đọc ghi file nhị phân bản 6.0 

namespace Buoi5_WinForms
{
    // datagridview không liên kết với dictionary 
    public partial class FormStudentManagement : Form
    {
        private Dictionary<string, Student> list;
        public FormStudentManagement()
        {
            InitializeComponent();
        }

        private void FormStudentManagement_Load(object sender, EventArgs e)
        {
            list = new Dictionary<string, Student>();

            //// Read file bản 6.0 
            //FileStream file = new FileStream("student.dat", FileMode.Open);
            //BinaryFormatter binaryFile = new BinaryFormatter(); // Không sai chỉ là 8.0 bị lỗi phải về 6.0
            //list = binaryFile.Deserialize(file) as Dictionary<string, Student>;
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
                        list.Add(student.ID, student);
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
            bs.DataSource = list.Values.ToList(); // Dictionary xử dụng này 
            dgvList.DataSource = bs;

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

            list.Add(student.ID, student);
            Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // SelectedRows: trả về dòng được chọn 
            foreach (DataGridViewRow row in dgvList.SelectedRows)
            {
                // Lấy MSSV ở dòng mình chọn (lấy giá trị cột[0])
                string ID = row.Cells[0].Value.ToString();
                if (list.Remove(ID) == true)
                    break;
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
                Student x = list[ID];
                txtID.Text = x.ID;
                txtName.Text = x.Name;
                txtAdress.Text = x.Adress;
                dtpBirthday.Value = x.Birthday;

                if (x.Gender == true) rdoMen.Checked = true;
                else rdoWomen.Checked = true;
                break;
            }
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            Student x = list[ID];
            
            x.Name = txtName.Text;
            x.Adress = txtAdress.Text;
            x.Gender = rdoMen.Checked;
            x.Birthday = dtpBirthday.Value;
            
            Show();
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
                foreach (var keyValue in list)
                {
                    Student student = keyValue.Value; // Lấy đối tượng Student từ phần Value của KeyValue

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

