using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SmartMedPharmacy.Models;

namespace SmartMedPharmacy.DAL
{
    public class PromotionDAL
    {
        public List<Promotion> GetAll()
        {
            var list = new List<Promotion>();
            using (var conn = DbConnection.GetConnection())
            {
                string query = "SELECT * FROM Promotions ORDER BY CreatedAt DESC";
                var cmd = new SqlCommand(query, conn);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read()) list.Add(MapReader(reader));
            }
            return list;
        }

        // Only valid (active + not expired) promos for customer view
        public List<Promotion> GetActivePromos()
        {
            var list = new List<Promotion>();
            using (var conn = DbConnection.GetConnection())
            {
                string query = @"SELECT * FROM Promotions
                                 WHERE IsActive = 1 AND ExpiryDate >= CAST(GETDATE() AS DATE)
                                 ORDER BY DiscountAmount DESC";
                var cmd = new SqlCommand(query, conn);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read()) list.Add(MapReader(reader));
            }
            return list;
        }

        // Validate a code against an order total — returns promo if eligible, null if not
        public Promotion ValidateCode(string code, decimal orderTotal)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string query = @"SELECT * FROM Promotions
                                 WHERE Code = @Code
                                   AND IsActive = 1
                                   AND ExpiryDate >= CAST(GETDATE() AS DATE)
                                   AND MinOrderAmount <= @Total";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Code",  code.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@Total", orderTotal);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                    if (reader.Read()) return MapReader(reader);
            }
            return null;
        }

        public bool Add(Promotion p)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string query = @"INSERT INTO Promotions
                                 (Code, Description, MinOrderAmount, DiscountAmount, ExpiryDate, IsActive)
                                 VALUES (@Code, @Description, @MinOrder, @Discount, @Expiry, @Active)";
                var cmd = new SqlCommand(query, conn);
                BindParams(cmd, p);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(Promotion p)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string query = @"UPDATE Promotions
                                 SET Code=@Code, Description=@Description,
                                     MinOrderAmount=@MinOrder, DiscountAmount=@Discount,
                                     ExpiryDate=@Expiry, IsActive=@Active
                                 WHERE PromoId=@PromoId";
                var cmd = new SqlCommand(query, conn);
                BindParams(cmd, p);
                cmd.Parameters.AddWithValue("@PromoId", p.PromoId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int promoId)
        {
            using (var conn = DbConnection.GetConnection())
            {
                string query = "DELETE FROM Promotions WHERE PromoId = @PromoId";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PromoId", promoId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void BindParams(SqlCommand cmd, Promotion p)
        {
            cmd.Parameters.AddWithValue("@Code",        p.Code.Trim().ToUpper());
            cmd.Parameters.AddWithValue("@Description", p.Description);
            cmd.Parameters.AddWithValue("@MinOrder",    p.MinOrderAmount);
            cmd.Parameters.AddWithValue("@Discount",    p.DiscountAmount);
            cmd.Parameters.AddWithValue("@Expiry",      p.ExpiryDate.Date);
            cmd.Parameters.AddWithValue("@Active",      p.IsActive);
        }

        private Promotion MapReader(SqlDataReader r) => new Promotion
        {
            PromoId        = (int)r["PromoId"],
            Code           = r["Code"].ToString(),
            Description    = r["Description"].ToString(),
            MinOrderAmount = (decimal)r["MinOrderAmount"],
            DiscountAmount = (decimal)r["DiscountAmount"],
            ExpiryDate     = (DateTime)r["ExpiryDate"],
            IsActive       = (bool)r["IsActive"],
            CreatedAt      = (DateTime)r["CreatedAt"]
        };
    }
}
