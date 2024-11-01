using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary; // Thư viện đọc ghi file bản cũ 

namespace Buoi5_WinForms
{
    public class CHandleStudent
    {
        private Dictionary<string, Student> list;

        //  Phương thức tạo lập 
        public CHandleStudent()
        {
            list = new Dictionary<string, Student>();
        }

        // Vì có truy cập nên không cần set 
        public List<Student> getStudentList() { return list.Values.ToList(); } // Đổi dictionary qua list để nhập dgv 

        // Các thành phần dùng để truy cập dữ liệu 
        public bool readData(string fileName)
        {
            try
            {
                //// Read file bản 6.0 
                //FileStream file = new FileStream("fileName", FileMode.Open);
                //BinaryFormatter binaryFile = new BinaryFormatter(); // Không sai chỉ là 8.0 bị lỗi phải về 6.0
                //list = binaryFile.Deserialize(file) as Dictionary<strig, Student>;
                //file.Close();

                // Read file bản 8.0 
                if (File.Exists("fileName"))
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
                }
                return true;
            }
            catch (Exception) { return false; } // Bắt hết mọi lỗi 
        }

        public bool writeData(string fileName)
        {
            try
            {
                //FileStream file = new FileStream("fileName", FileMode.Create); // Open => read, Create => write

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
                return true;
            }
            catch (Exception) { return false; } // Bắt hết mọi lỗi 
        }

        // Dictionary là bảng băm nên không tìm tuần tự nha 
        public Student search(string ID)
        {
            try
            {
                return list[ID];
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public bool add(Student student)
        {
            if(student == null) return false;
            try
            {
                list.Add(student.ID, student);
                return true;
            } catch (Exception) { return false; }
            
        }

        public bool remove(string ID)
        {
            try
            {
                return list.Remove(ID);
            }catch (Exception) { return false; }
        }

        public bool alter(Student student)
        {
            if(student == null) return false;
            Student h = search(student.ID);
            if (h == null) return false;
            h.Name = student.Name;
            h.Adress = student.Adress;
            h.Birthday = student.Birthday;
            h.Gender = student.Gender;
            return true;
        }
    }
}
