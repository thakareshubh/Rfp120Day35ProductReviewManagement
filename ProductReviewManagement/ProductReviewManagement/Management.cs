﻿using System;
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
        /// <summary>
        /// Tops the records.
        /// </summary>
        /// <param name="review">The review.</param>
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

        /// <summary>
        /// Selects  all the records.
        /// </summary>
        /// <param name="review">The review.</param>
        public void SelectRecords(List<ProductReview> review)
        {
            var recordedData = (from ProductReview in review
                                where (ProductReview.ProductID == 1 || ProductReview.ProductID == 4 || ProductReview.ProductID == 9) && (ProductReview.Rating > 3)
                                select ProductReview);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID : " + list.ProductID + ", User ID : " + list.UserID + ", Rating :" + list.Rating + ", Review : " + list.Review + ", isLike : " + list.isLike);
            }
        }
        /// <summary>
        /// Retrieves the count.
        /// </summary>
        /// <param name="review">The review.</param>
        public void RetrieveCount(List<ProductReview> review)
        {
            var recordedData = review.GroupBy(x => x.ProductID).Select(x => new { ProductId = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine("Product Id : " + list.ProductId + ", Count : " + list.Count);
            }
        }

    }
}
