﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace KittyInnovaton.Iot.Platfrom.WCF.Server
{
    /**************************
     Author:hezp
     Time:2017/8/27 14:44:48
     Desc：
    ***************************/
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ProductService : IProductService
    {
        /// <summary>
        /// 获取商品集
        /// </summary>
        /// <returns>商品集</returns>
        public string GetProducts()
        {
            Console.WriteLine("Hello World");
            return "Hello World";
        }

        /// <summary>
        /// 创建商品
        /// </summary>
        /// <param name="productName">商品名称</param>
        /// <returns>商品Id</returns>
        public Guid CreateProduct(string productName)
        {
            Console.WriteLine(productName);
            return Guid.NewGuid();
        }
    }
}
