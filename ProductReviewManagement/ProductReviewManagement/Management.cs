using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProductReviewManagement
{
    internal class Management
    {
        public readonly DataTable dataTable = new DataTable();
        
        public void TopRecords(List<ProductReview> review)
        {
            var recordedData = (from ProductReview in review
                                orderby ProductReview.Rating descending
                                select ProductReview).Take(3);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID : " + list.ProductID + ", User ID : " + list.UserID + ", Rating :" + list.Rating + ", Review : " + list.Review + ", isLike : " + list.isLike);
            }
        }

    }
}
