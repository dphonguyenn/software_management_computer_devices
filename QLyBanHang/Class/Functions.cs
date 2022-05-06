using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms; // su dung doi tuong MessageBox
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLyBanHang.Class
{
    class Functions
    {
        public static SqlConnection Connection;  //Khai báo đối tượng kết nối        

        public static void Connect()
        {
            Connection = new SqlConnection();   //Khởi tạo đối tượng
            Connection.ConnectionString = Properties.Settings.Default.QLyBanHangConnectionString;
            
            //Kiểm tra kết nối
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();              //Mở kết nối
                MessageBox.Show("Kết nối thành công chương trình");
            }
            else MessageBox.Show("Không thể kết nối với dữ liệu");

        }
        public static void Disconnect()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();   	//Đóng kết nối
                Connection.Dispose(); 	//Giải phóng tài nguyên
                Connection = null;
            }
        }

        // Phương thức thực thi câu lệnh select lấy dữ liệu
        public static DataTable GetDataToTable(string sql)
        {
            DataTable dtTable = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(sql, Connection);
            dap.Fill(dtTable);
            return dtTable;
        }
    }
}
