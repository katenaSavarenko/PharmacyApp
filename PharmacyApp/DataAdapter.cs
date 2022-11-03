using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace PharmacyApp
{
    class DataAdapter
    {
        static MySqlConnection Connection;
        MySqlCommand cmd;
        public DataAdapter()
        {
            Connection = new MySqlConnection();
        }
        public void Connect()
        {
            

            Connection.ConnectionString = "Server=s2.kts.tu-bryansk.ru"
                                        + ";port=3306"
                                        + ";User Id=17IAS-AMISI.SavarenkoEI"
                                        + ";password=KE+DPuFM>YsD+Y1n"
                                        + ";Database=17IAS-AMISI_SavarenkoEI"
                                        + ";CharSet=utf8";
            Connection.Open();
        }

        public void Disconnect()
        {
            Connection.Close();
        }

        public void AddPharmacy(Pharmacy pharmacy)
        {
            string query = "Insert into pharmacy (name, address, telephone) values ( '" + 
                            pharmacy.Name + "', '" + pharmacy.Address + "', '" + pharmacy.Telephone + "'); ";
            cmd = new MySqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
        }

        public void DeletePharmacy(Pharmacy pharmacy)
        {
            string query = "Delete from pharmacy ph where ph.name = '" + pharmacy.Name + "';";
            cmd = new MySqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
        }

        public void AddProduct(Product product)
        {
            string query = "Insert into product (name) values ( '" + product.Name +  "'); ";
            cmd = new MySqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
        }

        public void DeleteProduct(Product product)
        {
            string query = "Delete from product pd where pd.name = '" + product.Name + "';";
            cmd = new MySqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
        }

        public void AddWarehouse(Warehouse warehouse)
        {
            string query = "Insert into warehouse (id_Pharmacy, name) " +
                           "Select ph.id, '" + warehouse.Name +
                           "' from Pharmacy ph Where ph.name = '" + warehouse.NamePharmacy + "'; ";
            cmd = new MySqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
        }

        public void DeleteWarehouse(Warehouse warehouse)
        {
            string query = "Delete from warehouse wh where wh.name = '" + warehouse.Name + "';";
            cmd = new MySqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
        }

        public void AddParty(Party party)
        {
            string query = "Insert into party (id_Product, id_Warehouse, Qty, Name) " +
                           "Select pd.id, " +
                           "       (Select wh.id From Warehouse wh where wh.name = '" + party.NameWareHouse + "' ), " +
                           + party.Qty + ", '"
                           + party.Name +
                           "' from Product pd Where pd.name = '" + party.NameProduct + "'; ";
            cmd = new MySqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
        }

        public void DeleteParty(Party party)
        {
            string query = "Delete from party pt where pt.name = '" + party.Name + "';";
            cmd = new MySqlCommand(query, Connection);
            cmd.ExecuteNonQuery();
        }

        public List<string> ShowProducts(Pharmacy pharmacy)
        {
            string query = "Select CONVERT(CONCAT(pd.name, ' ', SUM(pt.Qty)), char) " +
                             "from Product pd " +
                               " inner join Party pt ON pt.id_product = pd.id " +
                               " inner join Warehouse wh on wh.id = pt.id_warehouse " +
                               " inner join Pharmacy pm on pm.id = wh.id_Pharmacy " +
                          " Where pm.name = '" + pharmacy.Name + "'; ";
            cmd = new MySqlCommand(query, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> productArray = new List<string>();
            while (reader.Read())
            {

                productArray.Add(reader[0].ToString());
            }
            reader.Close();
            return productArray;
        }
    }
}
